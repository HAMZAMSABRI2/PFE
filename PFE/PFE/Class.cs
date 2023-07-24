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
    public partial class Class : Form
    {
        public static SqlConnection con = new SqlConnection("Data source = HP23\\SQLEXPRESS ; initial catalog = gestion_hotels ; integrated security = true");
        public static SqlCommand cmd = new SqlCommand(" ",con);
        public Class()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Class_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd.CommandText = "insert into classe values (" + int.Parse(textBox1.Text) + " )";

            cmd.ExecuteNonQuery();

            con.Close();

            textBox1.Clear();
        }
    }
}
