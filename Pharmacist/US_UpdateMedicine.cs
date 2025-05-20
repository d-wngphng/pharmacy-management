using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PharmacyStoreManagement.Pharmacist
{
    public partial class US_UpdateMedicine : UserControl
    {
        function fn = new function();
        String query;
        public US_UpdateMedicine()
        {
            InitializeComponent();
        }

        private void clearAll()
        {
            txtMediid.Clear();
            txtMediName.Clear();
            txtMediNumber.Clear();
            txtMDate.ResetText();
            txtEDate.ResetText();
            txtAddQuantity.Clear();
            txtAvailable.Clear();
            txtPricePerUnit.Clear();

            if (txtAddQuantity.Text != "0")
            {
                txtAddQuantity.Text = "0";
            }
            else
            {
                txtAddQuantity.Text = "0";
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        Int64 totalQuantity;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String mname = txtMediName.Text;
            String mnumber = txtMediNumber.Text;
            String mdate = txtMDate.Text;
            String edate = txtEDate.Text;
            Int64 quantity = Int64.Parse(txtAvailable.Text);
            Int64 addQuantity = Int64.Parse(txtAddQuantity.Text);
            Int64 unitprice = Int64.Parse(txtPricePerUnit.Text);
            
            totalQuantity = quantity + addQuantity;

            query = "update medic set mname = '" + mname + "', mnumber = '" + mnumber + "', mDate = '" + mdate + "', eDate = '" + edate + "', quantity = '" + totalQuantity + "', perUnit = '" + unitprice + "' where mid = '" + txtMediid.Text + "'";
            fn.setData(query, "Drug details updated.");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMediid.Text))
            {
                MessageBox.Show("Please enter Drug ID to search.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMediid.Focus();
                return;
            }

            try
            {
                string query = "SELECT * FROM medic WHERE mid = @mid_param";
                SqlCommand cmd = new SqlCommand(query);

                cmd.Parameters.Add(new SqlParameter("@mid_param", SqlDbType.VarChar, 50)).Value = txtMediid.Text;


                DataSet ds = fn.getData(cmd);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        DataRow row = ds.Tables[0].Rows[0];

                        txtMediName.Text = row["mname"].ToString();             
                        txtMediNumber.Text = row["mnumber"].ToString();
                        txtAvailable.Text = row["quantity"].ToString();
                        txtPricePerUnit.Text = row["perUnit"].ToString();

                        if (row["mDate"] != DBNull.Value) 
                            txtMDate.Text = Convert.ToDateTime(row["mDate"]).ToString("dd/MM/yyyy"); 
                        if (row["eDate"] != DBNull.Value)
                            txtEDate.Text = Convert.ToDateTime(row["eDate"]).ToString("dd/MM/yyyy"); 


                    }
                    else
                    {
                        MessageBox.Show("More than one drug with this ID was found. Please check the data.", "Inconsistent data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearMedicineFields();
                    }
                }
                else
                {
                    MessageBox.Show("No medicine found with ID: " + txtMediid.Text, "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearMedicineFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during the search.: " + ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearMedicineFields()
        {
            txtMediName.Clear();
            txtMediNumber.Clear();
            txtMDate.Text = "";
            txtEDate.Text = "";
            txtAvailable.Clear();
            txtPricePerUnit.Clear();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void txtAddQuantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
