using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeerCalcDataModel.ExtensionMethods;
using BeerCalcDataModel.Model;

namespace BeerCalcDataSync.WebDao.Parser
{
    public class MaltParser : BeerCalcWebParser
    {
        public List<Malt> Parse(string content)
        {
            List<Malt> results = new List<Malt>();

            string maltEbcContent = content.Substring("malt_ebcs", ");");
            List<string> maltEbcValues = maltEbcContent.Substrings("\"", "\"");

            List<string> maltSelectItems = content.Substring("do_drop('malt',0", "</select>").Substrings("<option ", "</option>");
            foreach (string maltItem in maltSelectItems)
            {
                string name = maltItem.Substring(">");
                int value = int.Parse(maltItem.Substring("value=\"", "\""));
                if (value > 0 && !string.IsNullOrEmpty(name))
                {
                    Malt malt = new Malt();
                    malt.MaltIndexValue = value;
                    malt.MaltName = name;
                    string ebcValue = maltEbcValues[value];
                    if (!string.IsNullOrEmpty(ebcValue))
                    {
                        malt.EBC = int.Parse(ebcValue);
                    }

                    results.Add(malt);
                }
            }

            return results;
        }
    }
}
