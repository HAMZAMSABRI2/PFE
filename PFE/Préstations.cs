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
    public partial class Préstations : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP41\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public Préstations()
        {
            InitializeComponent();
        }

        private void Préstations_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)


        {

            try
            {
                if(textBox1.Text =="" || textBox2.Text =="")
                {
                    MessageBox.Show("saisie invalide");
                }

                else
                {

            con.Open();

            cmd.CommandText = "insert into prestations values (" + int.Parse(textBox1.Text) + " , '" + textBox2.Text +"'" +  " )";
            cmd.ExecuteNonQuery();

            con.Close();

            textBox1.Clear();
                    textBox2.Clear();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
