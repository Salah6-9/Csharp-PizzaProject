using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();


        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnGetStarted_Click_1(object sender, EventArgs e)
        {
            Form Frm = new FrmTableOfMenu();
            Frm.Show();
            this.Hide();

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}