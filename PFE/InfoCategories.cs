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
    public partial class InfoCategories : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP41\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public InfoCategories()
        {
            InitializeComponent();
        }

        private void InfoCategories_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            con.Open();
            cmd.CommandText = "select * from categories";

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString());



            }

            dr.Close();

            con.Close();
        }
    }
}
