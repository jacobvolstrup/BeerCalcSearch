using System;
using System.Collections.Generic;
using BeerCalcDataModel.Model;
using BeerCalcDataSync.WebDao;

namespace BeerCalcSyncGui
{
    static class Program
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            Logger.Info("INFO");
            Logger.Error("ERROR");
            Logger.Debug("DEBUG");

            BeerstyleWebDao beerstyleDao = new BeerstyleWebDao();
            BeerstyleGroup bsg = new BeerstyleGroup() { BeerstyleGroupKey = "dbj2011" };
            beerstyleDao.GetBeerstyles(bsg);


            IndexCrawlerWebDao indexCrawler = new IndexCrawlerWebDao();
            List<IndexItem> indexItems = indexCrawler.GetIndexItems(2, 0, 25);
			RecipeWebDao recipeDao = new RecipeWebDao();
			List<BeerstyleGroup> beerstyleGroups = recipeDao.GetBeerstyleGroups (indexItems [0]);
			beerstyleDao.GetBeerstyles (beerstyleGroups);
            List<Hop> hopList = recipeDao.GetHops(indexItems[0]);
            List<Malt> maltList = recipeDao.GetMalts(indexItems[0]);
			List<Yeast> yeastList = recipeDao.GetYeasts(indexItems[0]);
            List<Recipe> recipes = recipeDao.GetRecipes(indexItems);
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */
        }
    }
}
