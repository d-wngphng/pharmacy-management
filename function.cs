using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PharmacyStoreManagement
{
    internal class function
    {
        protected SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\pharmacy.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            return con;
        }

        public DataSet getData(string query)
        {
            using (SqlConnection con = getConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error while retrieving data: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return ds;
            }
        }
        public DataSet getData(SqlCommand cmd)
        {
            using (SqlConnection con = getConnection())
            {
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                try
                {
                    da.Fill(ds);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error while retrieving data: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return ds;
            }
        }

        public void setData(string query, string msg)
        {
            using (SqlConnection con = getConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    if (!string.IsNullOrEmpty(msg))
                    {
                        MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException sqlEx)
                {
                    string errorDetails = "SQL Error: " + sqlEx.Message;
                    MessageBox.Show(errorDetails, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred.: " + ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void setData(SqlCommand cmd, string successMsg)
        {
            using (SqlConnection con = getConnection())
            {
                cmd.Connection = con;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    if (!string.IsNullOrEmpty(successMsg))
                    {
                        MessageBox.Show(successMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (SqlException sqlEx)
                {
                    string errorDetails = "SQL Error: " + sqlEx.Message;
                    MessageBox.Show(errorDetails, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred.: " + ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }
    }
}