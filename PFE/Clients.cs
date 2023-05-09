using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PFE
{
    public partial class Clients : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP23\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd.CommandText = "insert into clients values (" + int.Parse(textBox1.Text) + " , '" + textBox2.Text + " ', '" + textBox3.Text +
                " ', '" + textBox4.Text + " ', '" + textBox5.Text + " ', '" + textBox6.Text + " ', '" +
                textBox7.Text + " ', '" + textBox8.Text + "'" + ")";

            cmd.ExecuteNonQuery();

            con.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "select * from clients";

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

                        textBox6.Text = dr[5].ToString();

                        textBox7.Text = dr[6].ToString();

                        textBox8.Text = dr[7].ToString();

                    }


                }
                con.Close();
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

                cmd.CommandText = "update clients set nom_client='" + textBox2.Text + " ', prénom_client='" + textBox3.Text +
                    " ', adresse_clients='" + textBox4.Text + " ', ville='" + textBox5.Text + " ', pays='" +
                    textBox6.Text + " ', télephone_client='" + textBox7.Text + " ', adresse_mail='" + textBox8.Text + "' where code_clients=" + int.Parse(textBox1.Text);

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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "delete from clients where code_clients=" + int.Parse(textBox1.Text);

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
