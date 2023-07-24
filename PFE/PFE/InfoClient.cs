using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFE
{
    public partial class InfoClient : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP23\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public InfoClient()
        {
            InitializeComponent();
        }

        private void InfoClient_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            con.Open();
            cmd.CommandText = "select * from clients";

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString()
                     , dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());



            }

            dr.Close();

            con.Close();
        }
    }
}
