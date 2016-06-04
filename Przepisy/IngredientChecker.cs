using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przepisy
{
    class IngredientChecker
    {
        private dbDataSetTableAdapters.IngredientTableAdapter ingredientTableAdapter;
        dbDataSet dataSet;
        public List<int> idList { get; set; }
        

        public IngredientChecker(string unparsedingrediance, dbDataSet dataSet)
        {
          
            this.dataSet = dataSet;
            this.ingredientTableAdapter = new Przepisy.dbDataSetTableAdapters.IngredientTableAdapter();
            List<string> ingredientsList = parseIngrediance(unparsedingrediance);
            this.idList= getIngredientIDlist(ingredientsList);
        
        }
        private static void Print(int s)
        {
            Console.WriteLine(s);
        }

        private List<int> getIngredientIDlist(List<string> ingredientsList) {
            List<int> idList = new List<int>();
            foreach (string value in ingredientsList){
               idList.Add(checkList(value));
            }
            idList.ForEach(Print);
            return idList;
        } 

        private int addIngredient(String name)
        {
            dbDataSet.IngredientRow ingredientRow = this.dataSet.Ingredient.NewIngredientRow();
            ingredientRow.Name = name;
            this.dataSet.Ingredient.Rows.Add(ingredientRow);
            this.ingredientTableAdapter.Update(this.dataSet.Ingredient);    
            return ingredientRow.Id;
         }


        private List<string> parseIngrediance(string unparsedingrediance)
        {
            unparsedingrediance = unparsedingrediance.ToLower();
            List<string> ingrediancelist = unparsedingrediance.Split(',').ToList();
            return ingrediancelist;
        }


        private int checkList(string name)
        {
            DataRow[] foundRows = this.dataSet.Ingredient.Select("Name = '" + name + "'");
            if (foundRows.Length == 1)
            {
                return (int)foundRows[0][0];
            }
            else if (foundRows.Length == 0)
            {
                return addIngredient(name);
            }
            else {
                throw new System.ApplicationException("Ingriedient table incosistanncy",null);
            }
        }
    }
}
