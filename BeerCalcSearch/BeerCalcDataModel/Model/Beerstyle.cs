namespace BeerCalcDataModel.Model
{
    public class Beerstyle : BeerCalcModel
    {
        public int BeerstyleID { get; set; }
        public int FK_BeerstyleGroupID { get; set; }
        public string BeerstyleKey { get; set; }
        public string BeerstyleName { get; set; }

        public double? EgenskabOGMinimum { get; set; }
        public double? EgenskabOGMaximum { get; set; }
        public double? EgenskabFGMinimum { get; set; }
        public double? EgenskabFGMaximum { get; set; }
        public int? EgenskabEBCMinimum { get; set; }
        public int? EgenskabEBCMaximum { get; set; }
        public int? EgenskabIBUMinimum { get; set; }
        public int? EgenskabIBUMaximum { get; set; }
        public double? EgenskabAlkoholMinimum { get; set; }
        public double? EgenskabAlkoholMaximum { get; set; }

        public string BeskrivelseGenereltIndtryk { get; set; }
        public string BeskrivelseUdseende { get; set; }
        public string BeskrivelseAroma { get; set; }
        public string BeskrivelseSmag { get; set; }
        public string BeskrivelseKrop { get; set; }
        public string BeskrivelseEksempler { get; set; }

        public override string ToString()
        {
            return BeerstyleName;
        }
    }
}
