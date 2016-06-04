using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace Przepisy
{

    class RecipeEditor
    {
        private dbDataSet dataSet;
        private dbDataSetTableAdapters.RecipeTableAdapter recipeTableAdapter;
        private dbDataSetTableAdapters.ThingsUneedTableAdapter thingsUneedTableAdapter;
        
        private System.Windows.Forms.BindingSource recipeBindingSource;
        
        public RecipeEditor(dbDataSet dataSet,dbDataSetTableAdapters.RecipeTableAdapter recipeTableAdapter,System.Windows.Forms.BindingSource recipeBindingSource) {
            this.dataSet = dataSet;
            this.recipeTableAdapter = recipeTableAdapter;
            this.recipeBindingSource = recipeBindingSource;
            this.thingsUneedTableAdapter = new Przepisy.dbDataSetTableAdapters.ThingsUneedTableAdapter();
           
         }
        private bool intermediateTabelFiller(List<int> ingredientIdList, int recipeID)
        {
            foreach (int value in ingredientIdList)
            {
                dbDataSet.ThingsUneedRow TUNrow = this.dataSet.ThingsUneed.NewThingsUneedRow() ;
                TUNrow.IDingredient = value;
                TUNrow.IDrecipe = recipeID;
                this.dataSet.ThingsUneed.Rows.Add(TUNrow);
                                       
            }
            this.thingsUneedTableAdapter.Update(this.dataSet.ThingsUneed);
            return true;
        }

        public bool adding(string title, string howTo, string unparsedingrediance)
        {
            dbDataSet.RecipeRow newRecipe = this.dataSet.Recipe.NewRecipeRow();
            newRecipe.HowTo = howTo;
            newRecipe.Title = title;

            this.dataSet.Recipe.Rows.Add(newRecipe);
            this.recipeTableAdapter.Update(this.dataSet.Recipe);
            int recipeID = newRecipe.Id;

            IngredientChecker checker = new IngredientChecker(unparsedingrediance,dataSet);
            List<int> ingredientIdList = checker.idList;
            intermediateTabelFiller(ingredientIdList, recipeID);
                /*for (int i = 0; i < foundRows.Length; i++)
            {
                Console.WriteLine(foundRows[i][0]);}*/
            

            //addIngredient("Bodzio");
            
            return true;



        }
       
       
    }
}
