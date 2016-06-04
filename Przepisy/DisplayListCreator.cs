using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przepisy
{
    class DisplayListCreator
    {
        private dbDataSet dataSet;
        enum comments { Perfect = 90, Ok = 80, Hmm=-1}
        public DisplayListCreator(dbDataSet dataSet)
        {
            this.dataSet = dataSet;

        }

        private string recommendation(int percentage)
        {

            string answear = ((comments)percentage).ToString();

            return answear;
        }
        public List<DisplayItem> display()
        {
            DataRow[] foundRows = this.dataSet.Recipe.Select(null, null, DataViewRowState.OriginalRows);
            Console.WriteLine(foundRows.Length); 
            List<DisplayItem> displayItemList= new List<DisplayItem>();
            foreach (DataRow r in foundRows) {
                DisplayItem item = new DisplayItem();
                item.name = (string)r[1];
                item.fitness = recommendation(-1);
                displayItemList.Add(item);
            }

            return displayItemList;
        }

        public List<DisplayItem> display(string unparsedFilter)
        {
            IngredientSearcher search = new IngredientSearcher(unparsedFilter,dataSet);

           search.dict.ToList().ForEach(x => Console.WriteLine(x.Key+" "+x.Value));

            return null; 

        }

        
    }
}
