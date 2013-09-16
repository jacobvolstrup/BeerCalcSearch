using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BeerCalcDataSync.WebDao;
using BeerCalcDataModel;

namespace BeerCalcSyncGui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            BeerstyleWebDao beerstyleDao = new BeerstyleWebDao();
            BeerstyleGroup bsg = new BeerstyleGroup() { BeerstyleGroupKey = "dbj2011" };
            beerstyleDao.GetBeerstyles(bsg);



            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */
        }
    }
}
