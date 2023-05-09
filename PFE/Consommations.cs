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
    public partial class Consommations : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP23\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public Consommations()
        {
            InitializeComponent();
        }

        private void Consommations_Load(object sender, EventArgs e)
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
            con.Open();

            cmd.CommandText = "insert into consommations values (" + int.Parse(textBox1.Text) + " , '" +
                dateTimePicker1.Value + " ', '" + dateTimePicker2.Value + " ', " + int.Parse(comboBox1.Text) + ")";

            cmd.ExecuteNonQuery();

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
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



                        

                        dateTimePicker1.Text = dr[1].ToString();

                        dateTimePicker2.Text = dr[2].ToString();    

                        




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

                cmd.CommandText = "update consommations set date_consomations='" + dateTimePicker1.Value + "' , heure_consommations='" +
                    dateTimePicker2.Value + " ', code_clients=" + int.Parse(comboBox1.Text) + "where numéro_consommations=" + int.Parse(textBox1.Text);



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

                cmd.CommandText = "delete from consommations where numéro_consommations=" + int.Parse(textBox1.Text);

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
