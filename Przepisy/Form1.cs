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
        private int rowIndex = 0;
        RecipeEditor editor;
        public Form1()
        {
            InitializeComponent();
             
            this.displayListCreator = new DisplayListCreator(dbDataSet1);
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            style();
            this.thingsUneedTableAdapter.Fill(this.dbDataSet1.ThingsUneed);
            this.ingredientTableAdapter.Fill(this.dbDataSet1.Ingredient);
            this.recipeTableAdapter.Fill(this.dbDataSet1.Recipe);
            this.editor = new RecipeEditor(dbDataSet1);
           
            

            DataGridViewCell cell = new DataGridViewTextBoxCell();
            DataGridViewTextBoxColumn recipeName = new DataGridViewTextBoxColumn()
               {
                   CellTemplate = cell,
                   Name = "recipeTitle",
                   HeaderText = "Recipe Title",
                  
                   DataPropertyName = "name",
                   Width = 440

               };
            DataGridViewTextBoxColumn recipeFitness = new DataGridViewTextBoxColumn()
            {

                CellTemplate = cell,
                Name = "recipeFitness",
                HeaderText = "Match",
                DataPropertyName = "fitness",
                Width = 326

            };

            dataGridView4.Columns.Add(recipeName);
            dataGridView4.Columns.Add(recipeFitness);


            this.itemList=displayListCreator.display();
            var filenamesList = new BindingList<DisplayItem>(this.itemList);

            refreshRecommendationList();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {

            Console.WriteLine(textBox1.Text.Length);
            if (textBox1.Text == "eggs, flour, butter...")
            {
                refreshRecommendationList();
            }
            else
            {
                refreshRecommendationList(textBox1.Text);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    refreshRecommendationList();
                }
                else
                    button1.PerformClick();
                // these last two lines will stop the beep sound
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
      
        
        private void refreshRecommendationList(string ingredience)
        {

            this.itemList = displayListCreator.display(ingredience);
            dataGridView4.DataSource = this.itemList;
        }
        private void refreshRecommendationList()
        {
            this.itemList = displayListCreator.display();
            dataGridView4.DataSource = this.itemList;
        }

     

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "eggs, flour, butter...";
                textBox1.ForeColor = SystemColors.MenuText;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "eggs, flour, butter...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.MenuText;
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.Text = "Title";
                textBox2.ForeColor = SystemColors.MenuText;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Title")
            {
                textBox2.Text = "";
                textBox2.ForeColor = SystemColors.MenuText;
            }
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                textBox3.Text = "Ingredience";
                textBox3.ForeColor = SystemColors.MenuText;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Ingredience")
            {
                textBox3.Text = "";
                textBox3.ForeColor = SystemColors.MenuText;
            }
        }
        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length == 0)
            {
                richTextBox1.Text = "Recipe instructions";
                richTextBox1.ForeColor = SystemColors.MenuText;
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Recipe instructions")
            {
                richTextBox1.Text = "";
                richTextBox1.ForeColor = SystemColors.MenuText;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            

            this.editor.adding(textBox2.Text, richTextBox1.Text, textBox3.Text);
            refreshRecommendationList();
            textBox2.Clear();
            textBox3.Clear();
            richTextBox1.Clear();
            refreshRecommendationList();
            

        }

      

        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           if (e.Button== MouseButtons.Right )
            {
                this.dataGridView4.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.contextMenuStrip1.Show(this.dataGridView4, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
         }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.remove(this.itemList[this.rowIndex].id);
            refreshRecommendationList();
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.rowIndex = e.RowIndex;
            int id = this.itemList[this.rowIndex].id;

            Form f2 = new Form2( id, dbDataSet1);
            f2.ShowDialog(); // Shows Form2
        }
        private void style() {
            //Form1 properties
            MaximizeBox = false;
            //Datagridview4 properties
            dataGridView4.AutoGenerateColumns = false;
            dataGridView4.RowHeadersVisible = false;
            dataGridView4.ScrollBars = ScrollBars.Vertical;
            dataGridView4.AllowUserToResizeRows = false;
            dataGridView4.AllowUserToResizeColumns = false;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.MultiSelect = false;
            dataGridView4.EnableHeadersVisualStyles = false;
            //textBox properties
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Text = "eggs, flour, butter...";
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            textBox2.ForeColor = SystemColors.GrayText;
            textBox2.Text = "Title";
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            textBox3.ForeColor = SystemColors.GrayText;
            textBox3.Text = "Ingredience";
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            this.textBox3.Enter += new System.EventHandler(this.textBox3_Enter);
            richTextBox1.ForeColor = SystemColors.GrayText;
            richTextBox1.Text = "Recipe instructions";
            richTextBox2.BackColor = SystemColors.ButtonHighlight;
            this.richTextBox1.Leave += new System.EventHandler(this.richTextBox1_Leave);
            this.richTextBox1.Enter += new System.EventHandler(this.richTextBox1_Enter);
       // dataGridView4 design
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            dataGridView4.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dataGridView4.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView4.DefaultCellStyle.BackColor = Color.White;
            dataGridView4.DefaultCellStyle.ForeColor = Color.MidnightBlue;
        }

        private void textBox1_Enter_1(object sender, EventArgs e)
        {

            Console.WriteLine(textBox1.Text.Length);
            if (textBox1.Text == "eggs, flour, butter...")
            {
                refreshRecommendationList();
            }
            else
            {
                refreshRecommendationList(textBox1.Text);
            };
        }
        

	




       

        
        
    }
}
