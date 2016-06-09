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
            List<DisplayItem> displayItemList = new List<DisplayItem>();
            foreach (DataRow row in dt.Rows)
            {
                DisplayItem item = new DisplayItem();
                item.name=row[1].ToString();
                item.fitness = recommendation(-1);
                item.id = (int) row[0];
                displayItemList.Add(item);
              
            }
            
            return displayItemList;
        }



        public List<DisplayItem> display(string unparsedFilter)
        {
            DataTable dt = dataSet.Recipe;
            IngredientSearcher search = new IngredientSearcher(unparsedFilter, dataSet);
            Dictionary<int, double> recipeDict = search.dict;

           List<DisplayItem> recommendationList = new List<DisplayItem>();
          

            foreach (int id in recipeDict.Keys)
            {
                foreach (DataRow row in dt.Rows)
                {

                    if (id == (int)row[0])
                    {
                        DisplayItem item = new DisplayItem();
                        item.name= (string)row[1];
                        item.id = (int)row[0];
                        item.fitness = recommendation(recipeDict[id]);
                        recommendationList.Add(item);

                    }
                }
            }
            return recommendationList;

        }





        private string recommendation(double percentage)
        {

            string answear = ((comments)percentage).ToString();

            return answear;
        }

    }
}
