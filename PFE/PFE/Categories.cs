using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFE
{
    public partial class Categories : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP23\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public Categories()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd.CommandText = "insert into categories values (" + int.Parse(textBox1.Text) + " , '" + textBox2.Text + "'" + " )";
            cmd.ExecuteNonQuery();

            con.Close();

            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "select * from categories";

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                int b = 0;

                while (dr.Read())
                {
                    if (dr[0].ToString().Equals(textBox1.Text))
                    {
                        b = 1;



                        textBox2.Text = dr[1].ToString();



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

                cmd.CommandText = "update categories set description_cat='" + textBox2.Text + "' where code_catégories=" + int.Parse(textBox1.Text);
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

                cmd.CommandText = "delete from categories where code_catégories=" + int.Parse(textBox1.Text);

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

        private void Categories_Load(object sender, EventArgs e)
        {

        }
    }
}
