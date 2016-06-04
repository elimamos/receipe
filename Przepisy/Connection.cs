using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace Przepisy
{
    class Connection
    {
       protected SqlConnection cn;
        public void connect()
        {
           cn = new SqlConnection(global::Przepisy.Properties.Settings.Default.dbConnectionString);
            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
        public void close()
        {
            cn.Close(); 
        }
    }
}
