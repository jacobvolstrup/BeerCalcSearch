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

        public BeerCalcWebDao()
        {
            WebClient = new WebClient();
        }

        protected string GetContent(string uri)
        {
            return WebClient.DownloadString(uri);
        }
    }
}
