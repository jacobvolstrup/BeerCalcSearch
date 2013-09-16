using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeerCalcDataModel.ExtensionMethods;
using BeerCalcDataModel;

namespace BeerCalcDataSync.WebDao.Parser
{
    public class BeerstyleParser
    {
        public List<Beerstyle> Parse(string content)
        {
            List<Beerstyle> result = new List<Beerstyle>();

            List<string> stilarter = content.Substrings("<table ", "</table>");
            foreach (string stilart in stilarter)
            {
                result.Add(ParseStilart(stilart));
            }

            return result;
        }

        private Beerstyle ParseStilart(string content)
        {
            //TODO: medtag StilartGruppe i constructor
            Beerstyle result = new Beerstyle();

            result.BeerstyleKey = content.GetStringBetween("<td class=\"stylehdr\">", "</td>");
            result.BeerstyleName = content.GetStringBetween("<td class=\"stylehdr\" align=\"right\" colspan=\"5\">", "</td>");

            result.BeskrivelseGenereltIndtryk = ParseBeskrivelse(content, "generelt indtryk");
            result.BeskrivelseUdseende = ParseBeskrivelse(content, "udseende");
            result.BeskrivelseAroma = ParseBeskrivelse(content, "aroma");
            result.BeskrivelseSmag = ParseBeskrivelse(content, "smag");
            result.BeskrivelseKrop = ParseBeskrivelse(content, "krop");
            result.BeskrivelseEksempler = ParseBeskrivelse(content, "eksempler");

            List<string> egenskaberListe = content.GetListOfStringBetween("<tr bgcolor=\"white\" align=\"center\">", "</tr>");
            if (egenskaberListe.Count == 2)
            {
                ParseEgenskaber(result, egenskaberListe[1]);
            }

            return result;
        }

        private void ParseEgenskaber(Beerstyle result, string egenskaberContent)
        {

            List<string> egenskaber = egenskaberContent.GetListOfStringBetween("<td>", "</td>");
            if (egenskaber.Count == 5)
            {
                MinMaxValueElement minMaxOG = new MinMaxValueElement(egenskaber[0]);
                result.EgenskabOGMaximum = minMaxOG.MaxDoubleValue;
                result.EgenskabOGMinimum = minMaxOG.MinDoubleValue;

                MinMaxValueElement minMaxFG = new MinMaxValueElement(egenskaber[1]);
                result.EgenskabFGMaximum = minMaxFG.MaxDoubleValue;
                result.EgenskabFGMinimum = minMaxFG.MinDoubleValue;

                MinMaxValueElement minMaxEBC = new MinMaxValueElement(egenskaber[2]);
                result.EgenskabEBCMaximum = minMaxEBC.MaxIntValue;
                result.EgenskabEBCMinimum = minMaxEBC.MinIntValue;

                MinMaxValueElement minMaxIBU = new MinMaxValueElement(egenskaber[3]);
                result.EgenskabIBUMaximum = minMaxIBU.MaxIntValue;
                result.EgenskabIBUMinimum = minMaxIBU.MinIntValue;

                MinMaxValueElement minMaxAlkohol = new MinMaxValueElement(egenskaber[4]);
                result.EgenskabAlkoholMaximum = minMaxAlkohol.MaxDoubleValue;
                result.EgenskabAlkoholMinimum = minMaxAlkohol.MinDoubleValue;
            }
        }

        private string[] ParseMinMax(string minMaxString)
        {
            string[] result = new string[2];

            string[] minMaxSplittedString = minMaxString.Split('-');
            result[0] = minMaxSplittedString[0].Trim();
            result[1] = minMaxSplittedString[1].Trim();

            return result;
        }

        private string ParseBeskrivelse(string content, string beskrivelseNavn)
        {
            string result = content.GetStringBetween(string.Format("<td>{0}</td>", beskrivelseNavn), "</td>").RemoveTags("td").Trim();

            return result;
        }
    }
}
