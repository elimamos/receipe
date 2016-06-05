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
        public List<string> display()
        {
            IEnumerable<string> foundRows = dataSet.Recipe.Select(Recipe => Recipe.Title);

            Console.WriteLine(foundRows.AsEnumerable().Count());


            List<string> displayItemList = foundRows.ToList();
            Console.WriteLine(displayItemList.Count);
           // displayItemList.ForEach(i => Console.Write("{0}\n", i));



            /*   Console.WriteLine(displayItemList.Count);
               List<DisplayItem> displayItemList = new List<DisplayItem>();
               foreach (DataRow r in foundRows)
               {
                   DisplayItem item = new DisplayItem();
                   item.name = (string)r[1];
                   item.fitness = recommendation(-1);
                   displayItemList.Add(item);
                   return displayItemList;
               }
         
            
               // return displayItemList;*/
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
