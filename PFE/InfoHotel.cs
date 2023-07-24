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
    public partial class InfoHotel : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP41\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public InfoHotel()
        {
            InitializeComponent();
        }

        private void InfoHotel_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select nbre_etoile from classe";

            int a = 0;

            SqlDataReader drd = cmd.ExecuteReader();

            while (drd.Read())
            {
                a = 1;
                comboBox1.Items.Add(drd["nbre_etoile"].ToString());
                comboBox1.ValueMember = drd["nbre_etoile"].ToString();
                comboBox1.DisplayMember = drd["nbre_etoile"].ToString();

            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
 
                dataGridView1.Rows.Clear();
                cmd.CommandText = "select * from hotel where nbre_etoile =" + comboBox1.SelectedItem;
                con.Open();

                SqlDataReader dr;
                 dr = cmd.ExecuteReader();
            int test = 0;
  
                while (dr.Read())
                {
                test = 1;
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString()
                         , dr[4].ToString(), dr[5].ToString());





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
