using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFE
{
    public partial class InfoConsommation : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP41\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public InfoConsommation()
        {
            InitializeComponent();
        }

        private void InfoConsommation_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select code_clients from clients";

            int a = 0;

            SqlDataReader drd = cmd.ExecuteReader();

            while (drd.Read())
            {
                a = 1;
                comboBox1.Items.Add(drd["code_clients"].ToString());
                comboBox1.ValueMember = drd["code_clients"].ToString();
                comboBox1.DisplayMember = drd["code_clients"].ToString();

            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cmd.CommandText = "select * from consommations where code_clients =" + comboBox1.SelectedItem;
            con.Open();

            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int test = 0;

            while (dr.Read())
            {
                test = 1;
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());





            }

            dr.Close();

            con.Close();

            if (test == 0)
            {
                MessageBox.Show("n'existe pas dans le tableau");
            }
        }
    }
}
