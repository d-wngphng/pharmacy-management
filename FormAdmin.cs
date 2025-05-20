using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyStoreManagement
{
    public partial class FormAdmin : Form
    {
        String user = "";
        public FormAdmin()
        {
            InitializeComponent();
        }

        public string ID
        {
            get { return user.ToString(); }
        }

        public FormAdmin(String userName)
        {
            InitializeComponent();
            lblUserName.Text = userName;
            user = userName;
            uC_ViewUser1.ID = ID;
            uC_Profile1.ID = ID;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            uC_DashBoard1.Visible = true;
            uC_DashBoard1.BringToFront();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            uC_DashBoard1.Visible=false;
            uC_AddUser1.Visible = false;
            uC_ViewUser1.Visible=false;
            uC_Profile1.Visible = false;
            btnDashBoard.PerformClick();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            uC_AddUser1.Visible=true;
            uC_AddUser1.BringToFront();


        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            uC_ViewUser1.Visible = true;
            uC_ViewUser1.BringToFront();
        }

        private void btnProfile_Click_1(object sender, EventArgs e)
        {
            uC_Profile1.Visible = true;
            uC_Profile1.BringToFront();
        }

        private void btnProfile_Enter(object sender, EventArgs e)
        {

        }
    }
}
