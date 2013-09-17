using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerCalcDataModel.Model
{
    public class Yeast : BeerCalcModel
    {
        public string YeastName { get; set; }
        public int YeastIndexValue { get; set; }

        public override string ToString()
        {
            return YeastName;
        }
    }
}
