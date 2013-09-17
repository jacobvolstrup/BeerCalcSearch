using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeerCalcDataModel.Model
{
    public class Recipe : BeerCalcModel
    {
        public int RecipeID { get; private set; }
        public int FK_BrewerID { get; private set; }
        public int FK_BeerstyleID { get; private set; }
        public string Recipename { get; set; }
        public string PickName { get; set; }
        public string DescriptionTaste { get; set; }
        public int Volume { get; set; }
        public int Efficiency { get; set; }
        public string MashSchedule { get; set; }
        public string Comment { get; set; }
        public bool CommentUseful { get; set; }

        /// <summary>
        /// Constructor til brug for repository.
        /// </summary>
        /// <param name="OpskriftID"></param>
        /// <param name="FK_BryggerID"></param>
        /// <param name="FK_StilartID"></param>
        public Recipe(int recipeID, int fk_BrewerID, int fk_BeerstyleID)
        {
            RecipeID = recipeID;
            FK_BrewerID = fk_BrewerID;
            FK_BeerstyleID = fk_BeerstyleID;
        }

        public Recipe()
        {

        }

        public override string ToString()
        {
            return Recipename;
        }
    }
}
