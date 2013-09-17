using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeerCalcDataModel.ExtensionMethods;
using BeerCalcDataModel.Model;

namespace BeerCalcDataSync.WebDao.Parser
{
    public class RecipeParser : BeerCalcWebParser
    {
        public Recipe Parse(string content)
        {
            Recipe result = new Recipe();

            result.Recipename = content.Substring("Name: <b>", "</b>").Trim();
            string brygger = content.Substring("Brewer: ", "</td>").Trim();

            string stilartNoegle = ParsePickList(content, "Beer Style");
            string stilartGruppeNoegle = ParsePickList(content, "Style Guide");

            string volumen = content.Substring("Volume:", "/>").Substring("value=\"", "\"");
            result.Volume = int.Parse(volumen);

            string efficiency = content.Substring("Efficiency:", "/>").Substring("value=\"", "\"");
            result.Efficiency = int.Parse(efficiency);

            result.MashSchedule = content.Substring("Mash schedule:", "/>").Substring("value=\"", "\"");
            result.Comment = content.Substring("name=comments>", "</textarea>");
            result.CommentUseful = content.Substring("Useful", "/>").Substring("value=\"", "\"") == "1" ? true : false;

            List<MaltIngredientItem> maltIngredients = ParseMalts(content);
            List<HopIngredientItem> hopIngredients = ParseHops(content);

            return result;
        }

        private List<HopIngredientItem> ParseHops(string content)
        {
            List<string> hops = content.Substrings("do_drop('hop'", "</tr>");

            List<HopIngredientItem> hopIngredients = new List<HopIngredientItem>();
            foreach (string hopContent in hops)
            {
                HopIngredientItem item = ParseHop(hopContent);
                if (item.HopValue != 0)
                {
                    hopIngredients.Add(item);
                }
            }

            return hopIngredients;
        }

        private HopIngredientItem ParseHop(string hopContent)
        {
            HopIngredientItem item = new HopIngredientItem();

            item.HopIngredientIndex = int.Parse(hopContent.Substring(",", ")"));
            item.HopValue = int.Parse(ParseSelectedDropdownValue(hopContent));
            item.Acid = AsDouble(hopContent.Substring("acid\"  onchange=\"calc()\" value=\"", "\"").Replace(".", ","));
            item.Weight = int.Parse(hopContent.Substring("hopw\"  onchange=\"calc()\" value=\"", "\""));
            item.BoilTime = ParseSelectedDropdownValue(hopContent.Substring("boil", "</td>"), true);

            return item;
        }

        private List<MaltIngredientItem> ParseMalts(string content)
        {
            List<string> malts = content.Substrings("do_drop('malt'", "</tr>");

            List<MaltIngredientItem> maltIngredients = new List<MaltIngredientItem>();
            foreach (string malt in malts)
            {
                MaltIngredientItem item = ParseMalt(malt);

                // 0 == NONE
                if (item.MaltValue != 0)
                {
                    maltIngredients.Add(item);
                }
            }

            return maltIngredients;
        }

        private MaltIngredientItem ParseMalt(string maltContent)
        {
            MaltIngredientItem item = new MaltIngredientItem();

            item.MaltIngredientIndex = int.Parse(maltContent.Substring(",", ")"));
            item.MaltValue = int.Parse(ParseSelectedDropdownValue(maltContent));
            item.Weight = int.Parse(maltContent.Substring("weight\"  onchange=\"calc()\" value=\"", "\""));
            item.EBC = int.Parse(maltContent.Substring("col\" value=\"", "\""));

            return item;
        }

        private string ParseSelectedDropdownValue(string selectContent, bool returnText = false)
        {
            List<string> options = selectContent.Substrings("<option", "</option>");

            string value = null;
            foreach (string option in options)
            {
                if (option.IndexOf("selected") != -1)
                {
                    if (returnText)
                    {
                        value = option.Substring(">");
                    }
                    else
                    {
                        value = option.Substring("value=\"", "\" selected");
                    }
                    break;
                }
            }

            return value;
        }

        private string ParsePickList(string pageContent, string PickListName)
        {
            string pickListContent = pageContent.Substring(string.Format("{0}:", PickListName), "</select>");
            return ParseSelectedDropdownValue(pickListContent);
        }
    }
}
