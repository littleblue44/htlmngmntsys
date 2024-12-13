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
    public partial class Form1 : Form
    {

        function fn = new function();
        String query;
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            query = "select username,pass from employee where username = '"+txtUsername.Text+"' and pass ='"+txtPassword.Text+"'";
            DataSet ds = fn.getData(query);


            if (txtUsername.Text == "admin" && txtPassword.Text == "1234" || ds.Tables[0].Rows.Count !=0)
            {
               labelError.Visible = false;
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.Show();

            }
            else
            {
                labelError.Visible = true;
                txtPassword.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
