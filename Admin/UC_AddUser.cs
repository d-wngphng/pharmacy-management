using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyStoreManagement.Admin
{
    public partial class UC_AddUser : UserControl
    {
        function fn = new function();
        String query;
        public UC_AddUser()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            String role = txtRole.Text;
            String name = txtName.Text;
            String dob = txtDob.Text;
            Int64 mobile = Int64.Parse(txtPhone.Text);
            String email = txtEmail.Text;
            String username = txtUserName.Text;
            String pass = txtPassword.Text;

            try
            {
                query = "Insert into users (userRole,name,dob,mobile,email,username,pass) values ('" + role + "','" + name + "','" + dob + "','" + mobile + "','" + email + "','" + username + "','" + pass + "')";
                fn.setData(query, "Sign up Successful!");
            }
            catch (Exception)
            {
                MessageBox.Show("Username already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            txtName.Clear();
            txtDob.ResetText();
            txtEmail.Clear();
            txtPhone.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtRole.SelectedIndex = -1;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username = '" + txtUserName.Text + "'";
            DataSet ds = fn.getData(query);

            if (ds.Tables[0].Rows.Count == 0)
            {
                pictrAddUser.ImageLocation = @"C:\Users\HP\source\repos\PharmacyStoreManagement\image_pharmacy\yes.png";
            } else
            {
                pictrAddUser.ImageLocation = @"C:\Users\HP\source\repos\PharmacyStoreManagement\image_pharmacy\no.png";
            }    
        }
    }
}
