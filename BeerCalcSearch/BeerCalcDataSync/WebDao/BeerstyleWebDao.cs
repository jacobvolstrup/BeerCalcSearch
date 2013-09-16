using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeerCalcDataModel;
using BeerCalcDataSync.WebDao.Parser;

namespace BeerCalcDataSync.WebDao
{
    public class BeerstyleWebDao : BeerCalcWebDao
    {
        private BeerstyleParser BeerstyleParser { get; set; }

        public BeerstyleWebDao()
        {
            BeerstyleParser = new BeerstyleParser();
        }

        public void GetBeerstyles(List<BeerstyleGroup> beerstyleGroups)
        {
            foreach (BeerstyleGroup beerstyleGroup in beerstyleGroups)
            {
                GetBeerstyles(beerstyleGroup);
            }
        }

        public void GetBeerstyles(BeerstyleGroup beerstyleGroup)
        {
            beerstyleGroup.Beerstyles = GetBeerstyles(beerstyleGroup.BeerstyleGroupKey);
        }

        private List<Beerstyle> GetBeerstyles(string beerstyleGroupKey)
        {
            string content = GetContent(string.Format("http://www.haandbryg.dk/cgi-bin/styles.cgi?set={0}", beerstyleGroupKey));

            List<Beerstyle> beerstyles = BeerstyleParser.Parse(content);

            return beerstyles;
        }
    }
}
