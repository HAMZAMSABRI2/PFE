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
    public partial class InfoChambres : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP41\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public InfoChambres()
        {
            InitializeComponent();
        }

        private void InfoChambres_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select numéro_d_hotel from hotel";

            int a    = 0;

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex !=-1)
            {
                string selecthotelid = comboBox1.SelectedItem.ToString();
                dataGridView1.Rows.Clear();

                try
                {
                    con.Open();

                    cmd.CommandText = "select nom_hotel from hotel where numéro_d_hotel =" + selecthotelid;

                    string getnom = cmd.ExecuteScalar().ToString();

                    textBox1.Text = getnom;

                    cmd.CommandText = "select adresse_hotel from hotel where numéro_d_hotel=" + selecthotelid;

                    string getadresse = cmd.ExecuteScalar().ToString();

                    textBox2.Text = getadresse;

                    cmd.CommandText = "select * from chambres where numéro_d_hotel=" + selecthotelid;

                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    int  a = 0;

                    while (dr.Read())
                    {
                        a = 1;

                        dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                    }
                    dr.Close();
                    if (a==0)
                    {
                        MessageBox.Show("aucune chambre existe pour cette hotel");

                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
