using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeerCalcDataModel.ExtensionMethods;
using BeerCalcDataModel.Model;

namespace BeerCalcDataSync.WebDao.Parser
{
	public class BeerstyleGroupParser : BeerCalcWebParser
	{
		public List<BeerstyleGroup> Parse(string content)
		{
			List<BeerstyleGroup> results = new List<BeerstyleGroup> ();

			String styleContent = content.Substring ("Style Guide:", "</select>");

			List<string> styleValues = styleContent.Substrings("<option", "</option>");

			foreach (string styleValue in styleValues)
			{
				string name = styleValue.Substring(">");
				string value = styleValue.Substring ("value=\"", "\"");

				if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
				{
					BeerstyleGroup bsg = new BeerstyleGroup () {
						BeerstyleGroupName = name,
						BeerstyleGroupKey = value
					};
					results.Add (bsg);
				}
			}

			return results;
		}
	}
}

