using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerCalcDataModel.Model
{
    public class IndexItem : BeerCalcModel
    {
        public string PickName { get; set; }
        public string BeerName { get; set; }
        public string Style { get; set; }
        public string OG { get; set; }
        public string Alcohol { get; set; }
        public string EBC { get; set; }
        public string IBU { get; set; }
        public string Brewer { get; set; }
        public string Date { get; set; }
        public string Rating { get; set; }
        public string UsefulComment { get; set; }

        public override string ToString()
        {
            return BeerName;
        }
    }
}
