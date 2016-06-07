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
        public Dictionary<int,double> dict { get; set; }
        public int ingredientCount{get; set;}
        public IngredientSearcher(string unparsedIngrediance, dbDataSet dataSet)
            : base(unparsedIngrediance, dataSet)
        {
            List<int> ingredientIDlist = getIngredientID(ingredientsList);
            ingredientCount = ingredientIDlist.Count;
            Dictionary<int, int> suggestionList = createSuggestionList(ingredientIDlist);
            var sortedDict = from entry in suggestionList orderby entry.Value descending select entry;
            dict=new Dictionary<int,double>();

            foreach (var entry in sortedDict)
            {
                this.dict.Add(entry.Key, countPercentage( entry.Value));
                
               
            }
        }

       private double countPercentage(double value)
        {
            double percentage;
            percentage = Math.Ceiling(value * 100 / ingredientCount);
            double percentageToTen = (Math.Ceiling(percentage / 10.0d) * 10);

            return percentageToTen;
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
            return suggestionList;
        }


        }
    }

