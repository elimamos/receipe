using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Przepisy
{
    public partial class Form2 : Form
    {
        dbDataSet dataSet;
        public Form2( int id, dbDataSet dataSet)
        {
            InitializeComponent();
            this.dataSet = dataSet;
            DataRow recipeRow = null;
            foreach (DataRow row in dataSet.Recipe.Rows)
            {
                if ((int)row[0] == id)
                {
                    recipeRow = row;
                }

            }
            textBox2.Text = (string)recipeRow[1];
            textBox2.TextAlign = HorizontalAlignment.Center;
        
            richTextBox1.Text = (string)recipeRow[2];
            
            List<int> idList= new List<int>();
            foreach (DataRow r in dataSet.ThingsUneed.Rows) {
                if ((int)r[1] == id) {
                    idList.Add((int)r[0]);
                }
            }
            string ingredients="";
            foreach (int item in idList)
            {
                foreach (DataRow r in dataSet.Ingredient.Rows) {
                    if ((int)r[0] == item) {
                        ingredients += r[1].ToString() + ", ";
                    }
                }
            }
            ingredients = ingredients.Remove(ingredients.Length - 2);
            textBox3.Text = ingredients;

        }

       
       

    }
}
