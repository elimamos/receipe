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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet1.Ingredient' table. You can move, or remove it, as needed.
            this.ingredientTableAdapter.Fill(this.dbDataSet1.Ingredient);
            this.recipeTableAdapter.Fill(this.dbDataSet1.Recipe);  
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            RecipeEditor editor = new RecipeEditor(dbDataSet1,recipeTableAdapter,recipeBindingSource);
            editor.adding("Łosoś z kaparami","HOW TO","łosoś,kapary");
            
          
        }
    }
}
