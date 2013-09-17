using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerCalcDataSync.WebDao.Parser
{
    public class MaltIngredientItem
    {
        public int MaltIngredientIndex { get; set; }
        public int MaltValue { get; set; }
        public int EBC { get; set; }
        public int Weight { get; set; }
        public int Percent { get; set; }
        public int Gravity { get; set; }
        public double Colour { get; set; }
    }
}
