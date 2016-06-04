using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;


namespace Przepisy
{
    public partial class Form1 : Form
    {
        private List<DisplayItem> itemList;
        private DisplayListCreator displayListCreator;
        public Form1()
        {
            InitializeComponent();
            this.displayListCreator = new DisplayListCreator(dbDataSet1);
            //this.itemList = new List<DisplayItem>();
            //this.itemList.Add(new DisplayItem("test","80"));
            //this.itemList.Add(new DisplayItem("test2","100"));
            itemList=displayListCreator.display("kapary,woda");
            var bindingList = new BindingList<DisplayItem>(itemList);
            var source = new BindingSource(bindingList,null);
            dataGridView4.DataSource = source;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet1.ThingsUneed' table. You can move, or remove it, as needed.
            this.thingsUneedTableAdapter.Fill(this.dbDataSet1.ThingsUneed);
            // TODO: This line of code loads data into the 'dbDataSet1.Ingredient' table. You can move, or remove it, as needed.
            this.ingredientTableAdapter.Fill(this.dbDataSet1.Ingredient);
            this.recipeTableAdapter.Fill(this.dbDataSet1.Recipe);  
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            RecipeEditor editor = new RecipeEditor(dbDataSet1);
           // editor.adding("Solos z kaparami","HOW TO","losos,kapary");
    
            /*CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
            currencyManager1.SuspendBinding();
           
            
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                r.Visible = false;
            }


            
            int rowIndex = -1;
            
            DataGridViewRow row = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Where(r => r.Cells["Id"].Value.ToString().Equals("5"))
                .First();

            rowIndex = row.Index;
            dataGridView1.Rows[rowIndex].Visible = true*/

           // IngredientSearcher searcher = new IngredientSearcher("losos,kapary,chmiel", dbDataSet1);
            DisplayListCreator display = new DisplayListCreator(dbDataSet1);
            display.display("woda,chmiel,kapary");

            
            
       
    }
       
        private void button2_Click(object sender, EventArgs e)
        {
       
          
        }
    }
}
