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
    public partial class Offre : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP41\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public Offre()
        {
            InitializeComponent();
        }

        private void Offre_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select numéro_d_hotel from hotel;" + "select code_prestations from prestations";

            int a = 0;

            SqlDataReader drd = cmd.ExecuteReader();

            while (drd.Read())
            {
                a = 1;
                comboBox1.Items.Add(drd["numéro_d_hotel"].ToString());
                comboBox1.ValueMember = drd["numéro_d_hotel"].ToString();
                comboBox1.DisplayMember = drd["numéro_d_hotel"].ToString();

            }

            drd.NextResult();

            while (drd.Read())
            {
                a = 1;
                comboBox2.Items.Add(drd["code_prestations"].ToString());
                comboBox2.ValueMember = drd["code_prestations"].ToString();
                comboBox2.DisplayMember = drd["code_prestations"].ToString();

            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if(comboBox1.Text=="" || comboBox2.Text =="" ||textBox1.Text=="")
                {
                    MessageBox.Show("saisie invalide");
                }

                else
                {

            con.Open();

            cmd.CommandText = "insert into offre values (" + int.Parse(comboBox1.Text) + " , " + int.Parse(comboBox2.Text)
                + " ,  " + float.Parse(textBox1.Text) + ")";

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

                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                cmd.CommandText = "select * from offre";

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

                cmd.CommandText = "update offre set code_prestations=" + int.Parse(comboBox2.Text)
                    + " , prix_pre=" + float.Parse(textBox1.Text) + " where numéro_d_hotel=" + int.Parse(textBox1.Text);
                cmd.ExecuteNonQuery();

                con.Close();


                textBox1.Clear();

                textBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                con.Close() ;
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

                con.Close() ;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
