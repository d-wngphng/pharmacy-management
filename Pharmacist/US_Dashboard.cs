using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyStoreManagement.Pharmacist
{
    public partial class US_Dashboard : UserControl
    {
        function fn = new function();
        String query;
        DataSet ds;
        Int64 count;
        public US_Dashboard()
        {
            InitializeComponent();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            chart1.Series["Valid Medicines"].Points.Clear();
            chart1.Series["Expired Medicines"].Points.Clear();
            loadChart();
        }

        private void US_Dashboard_Load(object sender, EventArgs e)
        {
            loadChart();
        }

        public void loadChart()
        {
            try
            {
                query = "SELECT mname, eDate FROM medic";
                ds = fn.getData(query);

                int validCount = 0;
                int expiredCount = 0;

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (DateTime.TryParse(row["eDate"].ToString(), out DateTime expiryDate))
                    {
                        if (expiryDate >= DateTime.Now)
                            validCount++;
                        else
                            expiredCount++;
                    }
                }

                chart1.Series["Valid Medicines"].Points.Clear();
                chart1.Series["Expired Medicines"].Points.Clear();

                chart1.Series["Valid Medicines"].Points.AddY(validCount);
                chart1.Series["Expired Medicines"].Points.AddY(expiredCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart: " + ex.Message);
            }
        }
    }
}
