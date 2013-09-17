using System.Collections.Generic;

namespace BeerCalcDataModel.Model
{
    public class BeerstyleGroup : BeerCalcModel
    {
        public int BeerstyleGroupID { get; set; }
        public string BeerstyleGroupKey { get; set; }
        public string BeerstyleGroupName { get; set; }
        public string BeerstyleGroupTitle { get; set; }

        public List<Beerstyle> Beerstyles { get; set; }

        public override string ToString()
        {
            return BeerstyleGroupName;
        }
    }
}
