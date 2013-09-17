using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeerCalcDataModel.Model;
using BeerCalcDataSync.WebDao.Parser;

namespace BeerCalcDataSync.WebDao
{
    public class IndexCrawlerWebDao : BeerCalcWebDao
    {
        private IndexParser IndexParser { get; set; }

        public IndexCrawlerWebDao()
        {
            IndexParser = new IndexParser();
        }

        public List<IndexItem> GetIndexItems(int numberOfPages, int indexStart = 0, int pageSize = 100)
        {
            var startTime = TimetrackingStart();
            List<IndexItem> results = new List<IndexItem>();

            for (int i = 0; i < numberOfPages; i++)
            {
                var itemStartTime = TimetrackingStart();
                int startItem = indexStart + (i * pageSize);

                string content = GetContent(string.Format("http://www.haandbryg.dk/cgi-bin/beercalc.cgi?startshow={0}&numshow={1}", startItem, pageSize));
                results.AddRange(IndexParser.Parse(content));
                TimeSpan itemDuration = TimetrackingEnd(itemStartTime);
                Logger.Debug(string.Format("Hentede side {0} af {1} på {2}", i+1, numberOfPages, itemDuration.ToString()));
            }

            TimeSpan duration = TimetrackingEnd(startTime);
            Logger.Debug(string.Format("Hentede {0} sider på {1}", numberOfPages, duration.ToString()));
            return results;
        }
    }
}
