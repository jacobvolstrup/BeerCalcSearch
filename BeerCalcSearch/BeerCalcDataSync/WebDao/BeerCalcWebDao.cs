using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace BeerCalcDataSync.WebDao
{
    public abstract class BeerCalcWebDao
    {
        private WebClient WebClient { get; set; }

        protected static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BeerCalcWebDao()
        {
            WebClient = new WebClient();
        }

        protected string GetContent(string uri)
        {
            return WebClient.DownloadString(uri);
        }

        protected DateTime TimetrackingStart()
        {
            return DateTime.UtcNow;
        }

        protected TimeSpan TimetrackingEnd(DateTime startTime)
        {
            TimeSpan spendedTime = DateTime.UtcNow - startTime;
            return spendedTime;
        }
    }
}
