using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerCalcDataSync.WebDao.Parser
{
    class MinMaxValueElement
    {
        private string MaxValue { get; set; }
        private string MinValue { get; set; }

        public MinMaxValueElement(string minMaxString)
        {
            string[] minMaxSplittedString = minMaxString.Split('-');
            MinValue = minMaxSplittedString[0].Trim();
            MaxValue = minMaxSplittedString[1].Trim();
        }

        private int? AsIntValue(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return int.Parse(input.Replace('+', ' '));
            }
            else
            {
                return null;
            }
        }

        private double? AsDoubleValue(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return double.Parse(input.Replace('.', ',').Replace('+', ' '));
            }
            else
            {
                return null;
            }
        }

        public int? MaxIntValue { get { return AsIntValue(MaxValue); } }
        public int? MinIntValue { get { return AsIntValue(MinValue); } }
        public double? MaxDoubleValue { get { return AsDoubleValue(MaxValue); } }
        public double? MinDoubleValue { get { return AsDoubleValue(MinValue); } }
    }
}
