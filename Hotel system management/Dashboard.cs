using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_system_management
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uC_AddRoom1.Visible = true;
            uC_AddRoom1.BringToFront();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        { 
            uC_Employee1.Visible = false;
            uC_AddRoom1.Visible=false;
            btnAddRoom.PerformClick();
            uC_CustomerRegistration1.Visible = false;
            
        }

        private void uC_AddRoom1_Load(object sender, EventArgs e)
        {

        }

        private void uC_CustomerRegistration1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            uC_CustomerRegistration1.Visible=true;
            uC_CustomerRegistration1.BringToFront();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            uC_CustomerCheckOut1.Visible=true;
            uC_CustomerCheckOut1.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            customerDetails1.Visible=true;
            customerDetails1.BringToFront();
        }

        private void customerDetails1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            uC_Employee1.Visible = true;
            uC_Employee1.BringToFront();
        }

        private void uC_Employee1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
