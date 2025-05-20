using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmacyStoreManagement.Pharmacist;

namespace PharmacyStoreManagement
{
    public partial class FormPharmacist : Form
    {
        public FormPharmacist()
        {
            InitializeComponent();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            uS_Dashboard1.Visible = true;
            uS_Dashboard1.BringToFront();
        }

        private void FormPharmacist_Load(object sender, EventArgs e)
        {
            uS_Dashboard1.Visible = false;
            uS_AddMedicine1.Visible = false;
            uS_ViewMedicine1.Visible = false;
            uS_UpdateMedicine1.Visible=false;
            btnDashboard.PerformClick();
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            uS_AddMedicine1.Visible = true;
            uS_AddMedicine1.BringToFront();
        }

        private void btnViewMedicine_Click(object sender, EventArgs e)
        {
            uS_ViewMedicine1.Visible = true;
            uS_ViewMedicine1.BringToFront();
        }

        private void btnUpdateMedi_Click(object sender, EventArgs e)
        {
            uS_UpdateMedicine1.Visible = true;
            uS_UpdateMedicine1.BringToFront();
        }

        private void uS_UpdateMedicine1_Load(object sender, EventArgs e)
        {

        }
    }
}
