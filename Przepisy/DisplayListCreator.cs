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

        public List<StringBuilder> display()
        {
            var foundRows = dataSet.Recipe.ToList();
           
            //Console.WriteLine(foundRows.AsEnumerable().Count());


          //  List<string> displayItemList = foundRows.ToList();
            //Console.WriteLine(displayItemList.Count);
           // displayItemList.ForEach(i => Console.Write("{0}\n", i));

            StringBuilder output = new StringBuilder();
            foreach (DataRow rows in dataSet.Recipe.Rows)
            {
                foreach (DataColumn col in dataSet.Recipe.Columns)
                {
                    output.AppendFormat("{0} ", rows[col]);
                }

                output.AppendLine();
            }

            var r = new List<StringBuilder> { output };
            r.ForEach(i => Console.Write("{0}\n", i));
            /*  List<DisplayItem> displayItemList = new List<DisplayItem>();
               foreach (string r in output)
               {
                   DisplayItem item = new DisplayItem();
                   item.name = (string)r[1];
                   item.fitness = recommendation(-1); 
                   displayItemList.Add(item);
                
               }
         */
            
            
            return r;
        }

        public List<DisplayItem> display(string unparsedFilter)
        {
            IngredientSearcher search = new IngredientSearcher(unparsedFilter,dataSet);

           search.dict.ToList().ForEach(x => Console.WriteLine(x.Key+" "+x.Value));

            return null; 

        }

        
}
}
