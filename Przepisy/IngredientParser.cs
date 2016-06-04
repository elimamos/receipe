using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przepisy
{
    class IngredientParser
    {
        protected dbDataSetTableAdapters.IngredientTableAdapter ingredientTableAdapter;
        protected dbDataSet dataSet;
        protected List<string> ingredientsList;

       public IngredientParser(string unparsedingrediance, dbDataSet dataSet)
        {
          
            this.dataSet = dataSet;
            this.ingredientTableAdapter = new Przepisy.dbDataSetTableAdapters.IngredientTableAdapter();
            ingredientsList = parseIngrediance(unparsedingrediance);       
        }

        public List<string> parseIngrediance(string unparsedingrediance)
        {
            unparsedingrediance = unparsedingrediance.ToLower();
            List<string> ingrediancelist = unparsedingrediance.Split(',').ToList();
            return ingrediancelist;
        }
    }
 
}

