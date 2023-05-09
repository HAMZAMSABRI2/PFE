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
    public partial class Hotels : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP23\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public Hotels()
        {
            InitializeComponent();
        }

        private void Hotels_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select nbre_etoile from classe";

            int a = 0;

            SqlDataReader drd = cmd.ExecuteReader();

            while (drd.Read())
            {
                a = 1;
                comboBox1.Items.Add(drd["id_facture"].ToString());
                comboBox1.ValueMember = drd["id_facture"].ToString();
                comboBox1.DisplayMember = drd["id_facture"].ToString();

            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd.CommandText = "insert into hotel values (" + int.Parse(textBox1.Text) + " , '" + textBox2.Text
                + " ', " + int.Parse(textBox3.Text) + " ,' " + textBox4.Text + " ', '" + textBox5.Text + " ', " + ")";

            cmd.ExecuteNonQuery();

            con.Close();

            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "select * from hotel";

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                int b = 0;

                while (dr.Read())
                {
                    if (dr[0].ToString().Equals(textBox1.Text))
                    {
                        b = 1;



                        textBox2.Text = dr[1].ToString();

                        textBox3.Text = dr[2].ToString();

                        textBox4.Text = dr[3].ToString();

                        textBox5.Text = dr[4].ToString();

                        comboBox1.Text = dr[5].ToString();

                    }


                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "update hotel set nom_hotel='" + textBox2.Text + "' , code_de_télephone=" + int.Parse(textBox3.Text) +
                    " , telephone='" + textBox4.Text + "' ,adresse_hotel='" + textBox5.Text + " ', nbre_etoile=" + int.Parse(comboBox1.Text) +
                    "where numéro_d_hotel=" + int.Parse(textBox1.Text);

                cmd.ExecuteNonQuery();

                con.Close();


                textBox1.Clear();

                textBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "delete from hotel where numéro_d_hotel=" + int.Parse(textBox1.Text);

                cmd.ExecuteNonQuery();

                con.Close();


                textBox1.Clear();

                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
