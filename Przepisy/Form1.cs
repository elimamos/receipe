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
           // this.itemList.Add(new DisplayItem("test","80"));
           // this.itemList.Add(new DisplayItem("test2","100"));
            
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet1.ThingsUneed' table. You can move, or remove it, as needed.
            this.thingsUneedTableAdapter.Fill(this.dbDataSet1.ThingsUneed);
            // TODO: This line of code loads data into the 'dbDataSet1.Ingredient' table. You can move, or remove it, as needed.
            this.ingredientTableAdapter.Fill(this.dbDataSet1.Ingredient);
            this.recipeTableAdapter.Fill(this.dbDataSet1.Recipe);

           this.itemList = displayListCreator.display();
           //Console.WriteLine(itemList.Count);
            // itemList.ForEach(i => Console.Write("{0}\n", i));
             BindingList<DisplayItem> bindingList = new BindingList<DisplayItem>(itemList);
           var source = new BindingSource(bindingList,null);
           //Console.WriteLine(source.Current);
          dataGridView4.DataSource = source;
     
          // dataGridView4.Show();

          // Console.WriteLine(source.Current);
         //   BindGrid();
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
            //DisplayListCreator display = new DisplayListCreator(dbDataSet1);
           // display.display();

            
            
       
    }
       
        private void button2_Click(object sender, EventArgs e)
        {
           displayListCreator.display();
         //  BindGrid();
        }
      /*  private void BindGrid()
{
    dataGridView4.AutoGenerateColumns = false;

    //create the column programatically
    DataGridViewCell cell = new DataGridViewTextBoxCell();
    DataGridViewTextBoxColumn colFileName = new DataGridViewTextBoxColumn()
    {
        CellTemplate = cell, 
        Name = "Value",
        HeaderText = "File Name",
        DataPropertyName = "" // Tell the column which property of FileName it should use
     };

   dataGridView4.Columns.Add(colFileName);
            
    var filelist =  displayListCreator.display();
    var filenamesList = new BindingList<StringBuilder>(filelist); // <-- BindingList
            
    //Bind BindingList directly to the DataGrid, no need of BindingSource
   // dataGridView4.DataSource = filenamesList;
}*/
    }
}
