using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerCalcDataModel.Model
{
    public class Hop : BeerCalcModel
    {
        public string HopName { get; set; }
        public double Acid { get; set; }
        public int HopIndexValue { get; set; }

        public override string ToString()
        {
            return HopName;
        }
    }
}
