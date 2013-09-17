using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerCalcDataModel.Model
{
    public class HopIngredientItem
    {
        public int HopIngredientIndex { get; set; }
        public int HopValue { get; set; }
        public double Acid { get; set; }
        public int Weight { get; set; }
        public string BoilTime { get; set; }
    }
}
