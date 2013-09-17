using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeerCalcDataModel.ExtensionMethods;
using BeerCalcDataModel.Model;

namespace BeerCalcDataSync.WebDao.Parser
{
    public class YeastParser : BeerCalcWebParser
    {
        /// <summary>
        /// Will return a list of yeasts from any pagecontent with a BeerCalc recipe.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public List<Yeast> Parse(string content)
        {
            List<Yeast> results = new List<Yeast>();

            List<string> yeastSelectItems = content.Substring("do_drop('yeast',0", "</select>").Substrings("<option ", "</option>");
            foreach (string yeastItem in yeastSelectItems)
            {
                string name = yeastItem.Substring(">");
                int value = int.Parse(yeastItem.Substring("value=\"", "\""));

                if (value > 0 && !string.IsNullOrEmpty(name))
                {
                    Yeast yeast = new Yeast();
                    yeast.YeastIndexValue = value;
                    yeast.YeastName = name;

                    results.Add(yeast);
                }
            }

            return results;
        }
    }
}
