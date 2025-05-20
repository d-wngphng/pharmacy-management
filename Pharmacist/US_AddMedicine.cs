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
    public partial class US_AddMedicine : UserControl
    {
        function fn = new function();
        String query;
        public US_AddMedicine()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMediid.Text) ||
                string.IsNullOrWhiteSpace(txtMediName.Text) ||
                string.IsNullOrWhiteSpace(txtMediNumber.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) ||
                string.IsNullOrWhiteSpace(txtPricePerUnit.Text))
            {
                MessageBox.Show("Please fill in all information completely.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string mid = txtMediid.Text;
                string mname = txtMediName.Text;
                string mnumber = txtMediNumber.Text;

                
                DateTime mdateValue = txtManuFact.Value;
                DateTime edateValue = txtExpireMedi.Value;

                Int64 quantity;
                
                if (!Int64.TryParse(txtQuantity.Text, out quantity))
                {
                    MessageBox.Show("Invalid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Int64 perunit;
                
                if (!Int64.TryParse(txtPricePerUnit.Text, out perunit))
                {
                    MessageBox.Show("Invalid unit price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sqlQuery = "INSERT INTO medic (mid, mname, mnumber, mDate, eDate, quantity, perunit) " +
                                  "VALUES (@mid, @mname, @mnumber, @mDate, @eDate, @quantity, @perunit)";


                using (SqlCommand cmd = new SqlCommand(sqlQuery))
                {
                    cmd.Parameters.AddWithValue("@mid", mid);
                    cmd.Parameters.AddWithValue("@mname", mname);
                    cmd.Parameters.AddWithValue("@mnumber", mnumber);
                    cmd.Parameters.Add("@mDate", SqlDbType.Date).Value = mdateValue;
                    cmd.Parameters.Add("@eDate", SqlDbType.Date).Value = edateValue;
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@perunit", perunit);


                    fn.setData(cmd, "Add medicine successfully!");


                    txtMediid.Clear();
                    txtMediName.Clear();
                    txtMediNumber.Clear();
                    txtManuFact.Value = DateTime.Now;
                    txtExpireMedi.Value = DateTime.Now;
                    txtQuantity.Clear();
                    txtPricePerUnit.Clear();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Input data format error: " + ex.Message, "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException sqlEx)
            {
                System.Diagnostics.Debug.WriteLine("SQL error in btnAddP_Click: " + sqlEx.ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unknown error in btnAddP_Click: " + ex.ToString());
                MessageBox.Show("An unexpected error occurred.: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            txtMediid.Clear();
            txtMediName.Clear();
            txtMediNumber.Clear();
            txtPricePerUnit.Clear();
            txtQuantity.Clear();
            txtManuFact.ResetText();
            txtExpireMedi.ResetText();
        }
    }
}
