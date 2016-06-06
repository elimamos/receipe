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

            List<string> title = getTitle();
            title.ForEach(i => Console.Write("{0}\n", i));

          //  List<DataRow> foundRows=new List<DataRow>();
            //foundRows.Add(dataSet.Recipe.Rows.ToString());
           //int length= dataSet.Recipe.Count;
           //Console.WriteLine(length);
           List<DisplayItem> displayItemList = new List<DisplayItem>();

            foreach(string s in title){
                DisplayItem item = new DisplayItem();
                item.name = s;
                item.fitness = recommendation(-1); 
                displayItemList.Add(item);
                Console.WriteLine(item.name);
            }

           
          //  string k = dataSet.Recipe.Rows.ToString();
          //  Console.WriteLine(k);

            /*for (int i = 0; i < 2 ; i++)
			{
                foundRows[1] = dataSet.Recipe.Rows[i];
                Console.WriteLine(foundRows[i]);
			 
			}


            foreach (DataRow r in foundRows)
            {
                
            }

            //DataSet[]foundRows = dataSet.Recipe.Select(bool o => o = true);           
            //Console.WriteLine(foundRows.AsEnumerable().Count());


          //  List<string> displayItemList = foundRows.ToList();
            //Console.WriteLine(displayItemList.Count);
           // displayItemList.ForEach(i => Console.Write("{0}\n", i));

           /* StringBuilder output = new StringBuilder();
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


            return displayItemList;
        }

        public List<DisplayItem> display(string unparsedFilter)
        {
            IngredientSearcher search = new IngredientSearcher(unparsedFilter,dataSet);

           search.dict.ToList().ForEach(x => Console.WriteLine(x.Key+" "+x.Value));

            return null; 

        }

        public List<string> getTitle()
        {
            DataTable dt = dataSet.Recipe;
            List<string> title = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                title.Add(row[1].ToString());
            }
            return title; // Ultimately to get a string list.
        }
        
}
}
