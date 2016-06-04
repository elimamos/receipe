using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przepisy
{
    class IngredientSearcher : IngredientParser
    {
        public List<int> recipeID { get; set; }

        public IngredientSearcher(string unparsedIngrediance, dbDataSet dataSet)
            : base(unparsedIngrediance, dataSet)
        {
            List<int> ingredientIDlist = getIngredientID(ingredientsList);
            Dictionary<int,int> suggestionList=createSuggestionList(ingredientIDlist);
            var sortedDict = from entry in suggestionList orderby entry.Value descending select entry;
            sortedDict.ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));
        }

        private List<int> getIngredientID(List<string> ingredient)
        {
            List<int> IDlist = new List<int>();
            foreach (string value in ingredient)
            {
                DataRow[] foundRows = this.dataSet.Ingredient.Select("Name = '" + value + "'");
                if (foundRows.Length == 1)
                {
                    IDlist.Add((int)foundRows[0][0]);
                }
                else if (foundRows.Length > 1)
                {
                    throw new System.ApplicationException("Ingriedient table incosistanncy", null);
                }
                
            }
            return IDlist;
        }
        private Dictionary<int, int> updateSuggestionsList(Dictionary<int, int> suggestionList, int ingredientID)
        {
            DataRow[] foundRows = this.dataSet.ThingsUneed.Select("IDingredient = '" + ingredientID + "'");
            foreach (DataRow r in foundRows)
            {
                if (suggestionList.ContainsKey((int)r[1]))
                {
                    suggestionList[(int)r[1]]++;
                }
                else {
                    suggestionList.Add((int)r[1], 1);

                }
            }
            return suggestionList;
        }
        private Dictionary<int, int> createSuggestionList(List<int> ingredientID)
        {
            Dictionary<int, int> suggestionList = new Dictionary<int, int>();
            foreach (int i in ingredientID)
            {
                suggestionList = updateSuggestionsList(suggestionList, i);
            }
            //suggestionList.ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));
            
            return suggestionList;
        }


        }
    }

