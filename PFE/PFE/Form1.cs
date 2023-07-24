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
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void cLASSESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class cs = new Class();
            cs.Show();
           // this.Enabled = false;

        }

        private void cLIENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void hOTELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hotels ht = new Hotels();
            ht.Show();
           // this.Enabled = false;
        }

        private void cATEGORIESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categories ct = new Categories();
            ct.Show();
           // this.Enabled = false;
        }

        private void cHAMBRESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chambres ch = new Chambres();
            ch.Show();
            //this.Enabled = false;
        }

        private void pRESTATIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Préstations pr = new Préstations();
            pr.Show();
            //this.Enabled = false;
        }

        private void cONSOMMATIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consommations cm = new Consommations();
            cm.Show();
           // this.Enabled = false;
        }

        private void cLIENTSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Clients cl = new Clients();
            cl.Show();
           // this.Enabled = false;
        }

        private void rÉSERVATIONSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Réservations rev = new Réservations();
            rev.Show();
            //this.Enabled = false;
        }

        private void tARIFIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tarifier ta = new Tarifier();
            ta.Show();
          //  this.Enabled = false;
        }

        private void oFFREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Offre of = new Offre();
            of.Show();
          //  this.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void infoHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void infoClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoClient ih = new InfoClient();

            ih.Show();
        }

        private void iNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoClass ic = new InfoClass();

            ic.Show();
        }

        private void infoCatégoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoCategories ica = new InfoCategories();

            ica.Show();
        }

        private void infoPréstationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoPrestation ip = new InfoPrestation();

            ip.Show();
        }

        private void infoHotelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            InfoHotel ih = new InfoHotel();

            ih.Show();
        }
    }
}
