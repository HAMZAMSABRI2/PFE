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
    public partial class Réservations : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP23\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public Réservations()
        {
            InitializeComponent();
        }

        private void Réservations_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select num_chambres from chambres;"+ "select code_clients from clients";

            int a = 0;

            SqlDataReader drd = cmd.ExecuteReader();

            while (drd.Read())
            {
                a = 1;
                comboBox1.Items.Add(drd["num_chambres"].ToString());
                comboBox1.ValueMember = drd["num_chambres"].ToString();
                comboBox1.DisplayMember = drd["num_chambres"].ToString();

            }

            drd.NextResult();

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
            con.Open();

            cmd.CommandText = "insert into reservations values (" + int.Parse(comboBox1.Text) + " , " +
                int.Parse(comboBox2.Text) + " , " + int.Parse(textBox1.Text) + " , '" + dateTimePicker1.Value +
                " ', '" + dateTimePicker2.Value + " ', '" + dateTimePicker3.Value + " ', " + float.Parse(textBox2.Text) + ")";

            cmd.ExecuteNonQuery();

            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "select * from reservations";

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                int b = 0;

                while (dr.Read())
                {
                    if (dr[0].ToString().Equals(comboBox1.Text))
                    {
                        b = 1;

                        textBox1.Text = dr[1].ToString();

                        dateTimePicker1.Text = dr[2].ToString();

                        dateTimePicker2.Text = dr[3].ToString();

                        dateTimePicker3.Text = dr[4].ToString();

                        textBox2.Text = dr[5].ToString();
                        

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

                cmd.CommandText = "update reservations set code_clients=" + int.Parse(comboBox2.Text) + " , num_res=" + int.Parse(textBox1)

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
