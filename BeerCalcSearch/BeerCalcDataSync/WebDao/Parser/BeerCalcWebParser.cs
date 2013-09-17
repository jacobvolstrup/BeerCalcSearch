using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerCalcDataSync.WebDao.Parser
{
    public abstract class BeerCalcWebParser
    {
        protected static double AsDouble(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return 0.0;
            }
            return Double.Parse(input);
        }
    }
}
