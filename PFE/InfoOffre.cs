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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PFE
{
    public partial class InfoOffre : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP41\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public InfoOffre()
        {
            InitializeComponent();
        }

        private void InfoOffre_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select numéro_d_hotel from hotel";

            int a = 0;

            SqlDataReader drd = cmd.ExecuteReader();

            while (drd.Read())
            {
                a = 1;
                comboBox1.Items.Add(drd["numéro_d_hotel"].ToString());
                comboBox1.ValueMember = drd["numéro_d_hotel"].ToString();
                comboBox1.DisplayMember = drd["numéro_d_hotel"].ToString();

            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cmd.CommandText = "select * from offre where numéro_d_hotel =" + comboBox1.SelectedItem;
            con.Open();

            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int test = 0;

            while (dr.Read())
            {
                test = 1;
                dataGridView1.Rows.Add(dr[1].ToString(), dr[2].ToString());




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
