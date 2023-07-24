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
    public partial class Tarifier : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP41\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public Tarifier()
        {
            InitializeComponent();
        }

        private void Tarifier_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select nbre_etoile from classe;" + "select code_catégories from categories";

            int a = 0;

            SqlDataReader drd = cmd.ExecuteReader();

            while (drd.Read())
            {
                a = 1;
                comboBox1.Items.Add(drd["nbre_etoile"].ToString());
                comboBox1.ValueMember = drd["nbre_etoile"].ToString();
                comboBox1.DisplayMember = drd["nbre_etoile"].ToString();

            }

            drd.NextResult();

            while (drd.Read())
            {
                a = 1;
                comboBox2.Items.Add(drd["code_catégories"].ToString());
                comboBox2.ValueMember = drd["code_catégories"].ToString();
                comboBox2.DisplayMember = drd["code_catégories"].ToString();

            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)

            
        {
            try
            {

            if(comboBox1.Text==""|| comboBox2.Text=="" || textBox1.Text == "")
            {
                MessageBox.Show("saisie invalide");
            }

            else
            {

            con.Open();

            cmd.CommandText = "insert into tarifier values (" + int.Parse(comboBox1.Text) + " , " + int.Parse(comboBox2.Text)
                + " ,  " + int.Parse(textBox1.Text) + ")";

            cmd.ExecuteNonQuery();

            con.Close();
                    textBox1.Clear();
                    comboBox1.Items.Clear();
                    comboBox2.Items.Clear();

                    MessageBox.Show("saisie validé avec succès");
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

                cmd.CommandText = "select * from tarifier";

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                int b = 0;

                while (dr.Read())
                {
                    if (dr[0].ToString().Equals(comboBox1.Text))
                    {
                        b = 1;



                        comboBox2.Text = dr[1].ToString();

                        textBox1.Text = dr[2].ToString();



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

                cmd.CommandText = "update tarifier set code_catégories=" + int.Parse(comboBox2.Text) 
                    + " , tarif_unitaire=" + int.Parse(textBox1.Text) + " where nbre_etoile=" + int.Parse(textBox1.Text);
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

                cmd.CommandText = "delete from tarifier where nbre_etoile=" + int.Parse(comboBox1.Text);

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
