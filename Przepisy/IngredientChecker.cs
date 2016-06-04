using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przepisy
{
    class IngredientChecker:IngredientParser
    {
        
        public List<int> idList { get; set; }
        

        public IngredientChecker(string unparsedingrediance, dbDataSet dataSet) :base(unparsedingrediance,dataSet)
        {
                      
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
            //idList.ForEach(Print);
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
