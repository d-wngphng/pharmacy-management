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
    public partial class UC_ViewUser : UserControl
    {
        function fn = new function();
        String query;
        String currentUser = "";
        public UC_ViewUser()
        {
            InitializeComponent();
        }

        public string ID
        {
            set { currentUser = value; }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            UC_ViewUser_Load(this,null);
        }

        private void UC_ViewUser_Load(object sender, EventArgs e)
        {
            query = "select * from users";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from users where username like '" + txtSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        String userName;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userName = guna2DataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch { }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete Information!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (currentUser != userName)
                {
                    query = "delete from users where username = '" + userName + "'";
                    fn.setData(query, "Record Deleted!");
                    UC_ViewUser_Load(this, null);
                }
                else
                {
                    MessageBox.Show("Error cannot be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
