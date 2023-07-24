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
    public partial class Chambres : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP41\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public Chambres()
        {
            InitializeComponent();
        }

        private void Chambres_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select code_catégories from categories;" + "select numéro_d_hotel from hotel";

            int a = 0;

            SqlDataReader drd = cmd.ExecuteReader();

            while (drd.Read())
            {
                a = 1;
                comboBox1.Items.Add(drd["code_catégories"].ToString());
                comboBox1.ValueMember = drd["code_catégories"].ToString();
                comboBox1.DisplayMember = drd["code_catégories"].ToString();

            }

            drd.NextResult();

            while (drd.Read())
            {
                a = 1;
                comboBox2.Items.Add(drd["numéro_d_hotel"].ToString());
                comboBox2.ValueMember = drd["numéro_d_hotel"].ToString();
                comboBox2.DisplayMember = drd["numéro_d_hotel"].ToString();

            }

            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" )
                {
                    MessageBox.Show("saisie invalide");
                }

                else
                {

            con.Open();

            cmd.CommandText = "insert into chambres values (" + int.Parse(textBox1.Text) + " , '" + textBox2.Text + " ', " + int.Parse(comboBox1.Text) + " , "
                + int.Parse(comboBox2.Text) + ")";

            cmd.ExecuteNonQuery();

            con.Close();

            textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.Items.Clear();
                    comboBox2.Items.Clear();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "select * from chambres";

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                int b = 0;

                while (dr.Read())
                {
                    if (dr[0].ToString().Equals(textBox1.Text))
                    {
                        b = 1;



                        textBox2.Text = dr[1].ToString();



                        comboBox1.Text = dr[2].ToString();

                        comboBox2.Text = dr[3].ToString();

                    }


                }
                con.Close();
                if (b == 0) MessageBox.Show("il n'existe pas dans le système");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                con.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "update chambres set tel_chambre='" + textBox2.Text + "' , code_catégories=" + int.Parse(comboBox1.Text) + " , numéro_d_hotel=" +
                     int.Parse(comboBox2.Text) + "where num_chambres=" + int.Parse(textBox1.Text);

                cmd.ExecuteNonQuery();

                con.Close();


                textBox1.Clear();

                textBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "delete from chambres where num_chambres=" + int.Parse(textBox1.Text);

                cmd.ExecuteNonQuery();

                con.Close();


                textBox1.Clear();

                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
