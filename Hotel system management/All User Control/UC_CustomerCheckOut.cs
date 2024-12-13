using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_system_management.All_User_Control
{

    public partial class UC_CustomerCheckOut : UserControl
    {

        function fn = new function() { };
        String query;


        public UC_CustomerCheckOut()
        {
            InitializeComponent();
        }

        private void UC_CustomerCheckOut_Load(object sender, EventArgs e)
        {
           // query = "select customer.cid,customer.name,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.dob,customer.idproof,customer.addres,customer.checkin,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where chekout = 'NO'";


      
             query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkIn,rooms.RoomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where chekout = 'NO'";

           
            DataSet ds = fn.getData(query); 

           
            guna2DataGridView1.DataSource = ds.Tables[0];

            // query for ssms 
            //from tables customer and rooms (joined the two) on customer roomid (primary key and foreign key)
            // inner join means whatever data match from the table first table and 
            // second table will be shown
            //foreign key (roomid) -/from first table/- references rooms (roomid) from the second table
            // is equal to rooms.roomid where checkout is equal to 'NO' what this means is that only those
            //customer can checkout which are already in the hotel 
            //if this customer who's already left our hotel then why do we have to even checkout? aight

            //call the method 
            // whatever is going to return from fn will be stored in ds

            //show that detail into the datagridview 
      
       

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkIn,rooms.RoomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where cname like '" + txtName.Text + "%' and chekout = 'NO'";
            //query for database for the comman like string or letter % so whatever you put inside the textbox to search will automatically show
            // chekout = 'NO'only show all record of the customer that are still in the hotel
            DataSet ds =fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        int id;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtCName.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtRoom.Text = guna2DataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(); // it was column 9 thats why :)
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if(txtCName.Text != "") // if textbox is not equal to null
            {
                if(MessageBox.Show("Confim?","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
                {
                    String cdate = txtCheckOutDate.Text;
                    query = "update customer set chekout = 'YES',checkout='"+cdate+"' where cid = "+id+" update rooms set booked = 'NO' where roomNo = '"+txtRoom.Text+"' ";
                    //query for updation and change room availability to YES from NO
                    fn.setData(query, "Check out Successful.");
                    UC_CustomerCheckOut_Load(this,null);
                    clearAll();

                }
                               
            }
            else
            {
                MessageBox.Show("No Customer Selected.","Message",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void clearAll()
        {
            txtCName.Clear();
            txtName.Clear();
            txtRoom.Clear();
            txtCheckOutDate.ResetText();
        }

        private void UC_CustomerCheckOut_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
