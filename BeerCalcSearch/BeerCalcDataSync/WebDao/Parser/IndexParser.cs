using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeerCalcDataModel.ExtensionMethods;
using BeerCalcDataModel.Model;

namespace BeerCalcDataSync.WebDao.Parser
{
    public class IndexParser : BeerCalcWebParser
    {
        public List<IndexItem> Parse(string content)
        {
            List<IndexItem> results = new List<IndexItem>();

            List<string> recipes = content.Substrings("<a href=\"/cgi-bin/beercalc.cgi", "</tr>");
            foreach (string recipeContent in recipes)
            {
                results.Add(ParseIndexRecipe(recipeContent));
            }

            return results;
        }

        private IndexItem ParseIndexRecipe(string recipeContent)
        {
            IndexItem result = new IndexItem();

            result.PickName = recipeContent.Substring("?pick=", "&amp;mine=");
            result.BeerName = recipeContent.Substring("\">", "</a>").Trim();
            List<string> details = recipeContent.Substrings("<td colspan=\"1\">", "</td>");
            if (details.Count() == 7)
            {
                result.Style = details[0];
                result.OG = details[1];
                result.Alcohol = details[2];
                result.EBC = details[3];
                result.IBU = details[4];
                result.Brewer = details[5];
                result.Date = details[6];
            }
            result.Rating = recipeContent.Substring("<td align=\"center\" colspan=\"1\">", "</td>").Replace("&nbsp;", " ").Trim();
            result.UsefulComment = recipeContent.Substring("<td align=\"center\">", "</td>").Replace("&nbsp;", " ").Trim();

            return result;
        }
    }
}
