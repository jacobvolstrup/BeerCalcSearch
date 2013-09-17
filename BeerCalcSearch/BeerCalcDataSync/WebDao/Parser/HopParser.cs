using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeerCalcDataModel.ExtensionMethods;
using BeerCalcDataModel.Model;

namespace BeerCalcDataSync.WebDao.Parser
{
    public class HopParser : BeerCalcWebParser
    {
        /// <summary>
        /// Will parse hops from any pagecontent with a BeerCalc recipe.
        /// </summary>
        /// <param name="content">pagecontent for a BeerCalc recipe</param>
        /// <returns></returns>
        public List<Hop> Parse(string content)
        {
            List<Hop> results = new List<Hop>();

            string acidContent = content.Substring("acids", ");");
            List<string> acidValues = acidContent.Substrings("\"", "\"");

            List<string> hopSelectItems = content.Substring("do_drop('hop',0", "</select>").Substrings("<option ", "</option>");
            foreach (string hopItem in hopSelectItems)
            {
                string name = hopItem.Substring(">");
                int value = int.Parse(hopItem.Substring("value=\"", "\""));
                if (value > 0 && !string.IsNullOrEmpty(name))
                {
                    Hop hop = new Hop();
                    hop.HopIndexValue = value;
                    hop.HopName = name;
                    string acidValue = acidValues[value];
                    if (!string.IsNullOrEmpty(acidValue))
                    {
                        hop.Acid = double.Parse(acidValue);
                    }

                    results.Add(hop);
                }
            }

            return results;
        }
    }
}
