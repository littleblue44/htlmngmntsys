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
    public partial class CustomerDetails : UserControl
    {
        function fn = new function();
        String query;
        public CustomerDetails()
        {
            InitializeComponent();
        }

        private void txtSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.SelectedIndex == 0)
            {
                query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid = rooms.roomid";
                getRecord(query);

            }
            else if (txtSearchBy.SelectedIndex == 1)
            {
                // is null cuz the checkout data is still not filled which means the customer are still in the hotel
                query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is null";
                getRecord(query);
            }
            else if (txtSearchBy.SelectedIndex == 2)
            {
                // is not null which means it has the checkout data which means the customer checked out and is not in the hotel anymore
                query = "select customer.cid,customer.cname,customer.mobile,customer.nationality,customer.gender,customer.dob,customer.idproof,customer.addres,customer.checkin,customer.checkout,rooms.roomNo,rooms.roomType,rooms.bed,rooms.price from customer inner join rooms on customer.roomid = rooms.roomid where checkout is not null";
                getRecord(query);
            }
        }

        private void getRecord(String query) // just so i can call it so i wont have to type dis again and again
            {
                DataSet ds = fn.getData(query);
                guna2DataGridView1.DataSource = ds.Tables[0];

            }

        }
}
