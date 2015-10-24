using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeerCalcDataModel.Model;
using BeerCalcDataSync.WebDao.Parser;

namespace BeerCalcDataSync.WebDao
{
    public class RecipeWebDao : BeerCalcWebDao
    {
        private RecipeParser RecipeParser { get; set; }
        private HopParser HopParser { get; set; }
		private MaltParser MaltParser { get; set; }
		private YeastParser YeastParser { get; set; }
		private BeerstyleGroupParser BeerstyleGroupParser { get; set; }

        public RecipeWebDao()
        {
            RecipeParser = new RecipeParser();
            HopParser = new HopParser();
            MaltParser = new MaltParser();
            YeastParser = new YeastParser();
			BeerstyleGroupParser = new BeerstyleGroupParser ();

            /*
            List<Hop> hopList = hopParser.Parse(content);
            List<Malt> maltList = maltParser.Parse(content);
            List<Yeast> yeastList = yeastParser.Parse(content);
             * */
        }

        public List<Recipe> GetRecipes(List<IndexItem> indexItems)
        {
            var startTime = TimetrackingStart();
            List<Recipe> results = new List<Recipe>();
            foreach (IndexItem indexItem in indexItems)
            {
                results.Add(GetRecipe(indexItem.PickName));
            }
            Logger.Debug(string.Format("Hentede liste med {0} opskrifter på {1}", results.Count(), TimetrackingEnd(startTime)));

            return results;
        }

        public Recipe GetRecipe(string pickName)
        {
            var startTime = TimetrackingStart();
            string content = GetRecipeContent(pickName);
            Recipe opskrift = RecipeParser.Parse(content);
            Logger.Debug(string.Format("Hentede opskrift [{0}] på {1}", pickName, TimetrackingEnd(startTime)));

            return opskrift;
        }

        private string GetRecipeContent(string pickName)
        {
            return GetContent(string.Format("http://www.haandbryg.dk/cgi-bin/beercalc.cgi?pick={0}", pickName));
        }

        public List<Hop> GetHops(IndexItem indexItem)
        {
            var startTime = TimetrackingStart();
            string content = GetRecipeContent(indexItem.PickName);
            List<Hop> results = HopParser.Parse(content);
            Logger.Debug(string.Format("Hentede liste med {0} humleelementer på {1}", results.Count(), TimetrackingEnd(startTime)));

            return results;
        }

        public List<Malt> GetMalts(IndexItem indexItem)
        {
            var startTime = TimetrackingStart();
            string content = GetRecipeContent(indexItem.PickName);
            List<Malt> results = MaltParser.Parse(content);
            Logger.Debug(string.Format("Hentede liste med {0} maltelementer på {1}", results.Count(), TimetrackingEnd(startTime)));

            return results;
        }

        public List<Yeast> GetYeasts(IndexItem indexItem)
        {
            var startTime = TimetrackingStart();
            string content = GetRecipeContent(indexItem.PickName);
            List<Yeast> results = YeastParser.Parse(content);
            Logger.Debug(string.Format("Hentede liste med {0} gærelementer på {1}", results.Count(), TimetrackingEnd(startTime)));

            return results;
        }

		public List<BeerstyleGroup> GetBeerstyleGroups(IndexItem indexItem) {
			var startTime = TimetrackingStart();
			string content = GetRecipeContent(indexItem.PickName);
			List<BeerstyleGroup> results = BeerstyleGroupParser.Parse(content);
			Logger.Debug(string.Format("Hentede liste med {0} stilarter på {1}", results.Count(), TimetrackingEnd(startTime)));

			return results;
		}
    }
}
