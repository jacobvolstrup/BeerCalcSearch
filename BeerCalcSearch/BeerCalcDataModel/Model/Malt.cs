using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerCalcDataModel.Model
{
    public class Malt : BeerCalcModel
    {
        public int MaltID { get; set; }

        public string MaltName { get; set; }
        public int EBC { get; set; }
        public int MaltIndexValue { get; set; }

        public override string ToString()
        {
            return MaltName;
        }
    }
}
