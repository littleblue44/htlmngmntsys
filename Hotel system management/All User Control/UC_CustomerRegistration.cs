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


namespace Hotel_system_management.All_User_Control
{
    public partial class UC_CustomerRegistration : UserControl
    {
        function fn = new function();
        String query;

        public UC_CustomerRegistration()
        {
            InitializeComponent();
        }

        public void setComboBox(String query,ComboBox combo)
        {
            SqlDataReader sdr = fn.getForCombo(query);
            while (sdr.Read()) //loop
            {
                for(int i = 0; i <sdr.FieldCount; i++)
                {
                    combo.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoomNo.Items.Clear();
            txtPrice.Clear();
            query = "select roomNo from rooms where bed = '"+txtBed.Text+"' and roomType='"+txtRoom.Text+"' and booked= 'NO' ";
            setComboBox(query, txtRoomNo);
        }

        private void txtBed_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRoom.SelectedIndex = -1; 
            txtRoomNo.Items.Clear();
            /*
             halimbawa you selected ac room type and double bed type then changed your mind the data will still stay thats
            why we need to clear it again to display it accurately
             */
            txtPrice.Clear();
        }

        int rid;
        private void txtRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select price,roomid from rooms where roomNo = '"+txtRoomNo.Text+"' ";
            DataSet ds = fn.getData(query);
            txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            rid = int.Parse(ds.Tables[0].Rows[0][1].ToString()); //roomid is int and gin convert maw sa string
        }

        private void btnAlloteRoom_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtContact.Text!="" && txtNationality.Text!="" &&txtGender.Text!="" && txtDob.Text!="" && txtIdProof.Text!="" && txtAddress.Text!="" && txtCheckIn.Text!="" && txtPrice.Text!="")
            {
                String name = txtName.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);    // querying
                String national = txtNationality.Text;
                String gender = txtGender.Text;
                String dob = txtDob.Text;
                String idproof = txtIdProof.Text;
                String address = txtAddress.Text;
                String checkin = txtCheckIn.Text;

                query = "insert into customer (cname,mobile,nationality,gender,dob,idproof,addres,checkin,roomid) values ('"+name+"',"+mobile+",'"+national+"','"+gender+"','"+dob+"','"+idproof+"','"+address+"','"+checkin+"',"+rid+") update rooms set booked = 'YES' where roomNO = '"+txtRoomNo.Text+"'";
                fn.setData(query, "Room No " + txtRoomNo.Text + "Allocation Succesful.");
                clearAll(); // calls clearAll class when you leave the customer registration panel
            }
            else
            {
                MessageBox.Show("Fill All fields before proceeding.","Information!!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtName.Clear();
            txtContact.Clear();
            txtNationality.Clear();
            txtGender.SelectedIndex = -1; //has hard coded items thats why we cant use clear command so we have to do the selectedIndex
            txtDob.ResetText(); // this is a date time so we cannot clear any text inside it so when used it resets to the current date
            txtIdProof.Clear();
            txtAddress.Clear();
            txtCheckIn.ResetText();
            txtBed.SelectedIndex = -1;
            txtRoomNo.SelectedIndex = -1;
            txtRoomNo.Items.Clear();
            txtPrice.Clear();

        }

        private void UC_CustomerRegistration_Leave(object sender, EventArgs e)
        {
            clearAll(); // calls the class above that clears all clears all text when you leave the customer reg panel
        }
    }
}
