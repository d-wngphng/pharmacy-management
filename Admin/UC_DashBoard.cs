﻿using System;
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
    public partial class UC_DashBoard : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        public UC_DashBoard()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void UC_DashBoard_Load(object sender, EventArgs e)
        {
            query = "select count(userRole) from users where userRole = 'Admin';";
            ds = fn.getData(query);
            setLabel(ds, lblAdmin);

            query = "select count(userRole) from users where userRole = 'Pharmacist';";
            ds = fn.getData(query);
            setLabel(ds, lblPharmacists);
        }

        private void setLabel(DataSet ds, Label lbl)
        {
            if (ds.Tables[0].Rows.Count != 0)
            {
                lbl.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lbl.Text = "0";
            }
        }

        private void btnSyn_Click(object sender, EventArgs e)
        {
            UC_DashBoard_Load(this, null);
        }
    }
}
