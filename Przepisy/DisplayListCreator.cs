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
        enum comments { Perfect = 100, NearlyPerfect = 90, CloseEnough = 80, Good = 70, Fine = 60, Ok = 50, ShoppingNeeded = 40, YouNeedMuchMore = 30, NotReally = 20, IDontThinkSo = 10, Hmm = -1 }
        public DisplayListCreator(dbDataSet dataSet)
        {
            this.dataSet = dataSet;


        }



        public List<DisplayItem> display()
        {
            DataTable dt = dataSet.Recipe;
            List<string> title = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                title.Add(row[1].ToString());
            }
            List<DisplayItem> displayItemList = new List<DisplayItem>();
            foreach (string s in title)
            {
                DisplayItem item = new DisplayItem();
                item.name = s;
                item.fitness = recommendation(-1);
                displayItemList.Add(item);
            }

            return displayItemList;
        }



        public List<DisplayItem> display(string unparsedFilter)
        {
            DataTable dt = dataSet.Recipe;
            IngredientSearcher search = new IngredientSearcher(unparsedFilter, dataSet);
            Dictionary<int, double> recipeDict = search.dict;

          /*  foreach (var v in recipeDict)
            {
                Console.WriteLine(v.Key + "      " + v.Value);
            }
            */
           List<DisplayItem> recommendationList = new List<DisplayItem>();
          

            foreach (int id in recipeDict.Keys)
            {
                foreach (DataRow row in dt.Rows)
                {

                    if (id == (int)row[0])
                    {
                        DisplayItem item = new DisplayItem();
                        item.name= (string)row[1];
                        
                        item.fitness = recommendation(recipeDict[id]);
                        recommendationList.Add(item);

                    }
                }
            }

        //  recommendationList.ForEach(i => Console.Write("{0}\n", i.name+" "+i.fitness));
            

           
        
            return recommendationList;


            //search.dict.ToList().ForEach(x => Console.WriteLine(x.Key + " " + x.Value));

            

        }





        private string recommendation(double percentage)
        {

            string answear = ((comments)percentage).ToString();

            return answear;
        }

    }
}
