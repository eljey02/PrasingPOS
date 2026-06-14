using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PrasingsPOS
{
    public partial class SalesControl : UserControl
    {
        [DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        
        [DllImport("Gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        string connectionString = @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        public SalesControl()
        {
            InitializeComponent();

           
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "MM/dd/yyyy";
            dtpFrom.Value = System.DateTime.Today;

            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "MM/dd/yyyy";
            dtpTo.Value = System.DateTime.Today;

            // Grid formatting
            dgvSales.AutoGenerateColumns = false;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.Columns["ProductSummary"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSales.Columns["DateTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSales.Columns["ProductSummary"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvSales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvSales.Columns["DateTime"].DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvSales.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";
            dgvSales.Columns["Payment"].DefaultCellStyle.Format = "N2";
            dgvSales.Columns["Change"].DefaultCellStyle.Format = "N2";

            dgvSales.RowsDefaultCellStyle.BackColor = Color.White;
            dgvSales.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            dgvSales.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgvSales.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            dgvSales.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvSales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvSales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

           
            dgvSales.Columns["TransactionID"].DataPropertyName = "TransactionID";
            dgvSales.Columns["DateTime"].DataPropertyName = "DateTime";
            dgvSales.Columns["ProductSummary"].DataPropertyName = "ProductSummary";
            dgvSales.Columns["TotalAmount"].DataPropertyName = "TotalAmount";
            dgvSales.Columns["Payment"].DataPropertyName = "Payment";
            dgvSales.Columns["Change"].DataPropertyName = "Change";
            dgvSales.Columns["Remarks"].DataPropertyName = "Remarks";
            dgvSales.Columns["Cashier"].DataPropertyName = "CashierName";
        }

        // FIX #3: Helper that creates, assigns, and immediately frees the GDI handle
        private void ApplyRoundRegion(Control control)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, control.Width, control.Height, 12, 12);
            control.Region = System.Drawing.Region.FromHrgn(hRgn);
            DeleteObject(hRgn);
        }

      
        private void LoadSales(DateTime fromDate, DateTime toDate, string filter = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
SELECT 
    t.TransactionID,
    t.DateTime,
    STRING_AGG(CONCAT(p.ProductName, ' (x', td.Qty, ')'), CHAR(13)+CHAR(10)) AS ProductSummary,
    t.TotalAmount,
    t.Payment,
    t.Change,
    t.Remarks,
    t.CashierName
FROM Transactions t
INNER JOIN TransactionDetails td ON t.TransactionID = td.TransactionID
INNER JOIN Products p ON td.ProductID = p.ProductID
WHERE t.DateTime BETWEEN @fromDate AND @toDate";

                    if (!string.IsNullOrEmpty(filter))
                        query += " AND (t.CashierName LIKE @filter OR t.Remarks LIKE @filter OR p.ProductName LIKE @filter)";

                    query += @"
GROUP BY t.TransactionID, t.DateTime, t.TotalAmount, t.Payment, t.Change, t.Remarks, t.CashierName
ORDER BY t.DateTime DESC;";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@toDate", toDate.Date.AddDays(1).AddTicks(-1));
                    if (!string.IsNullOrEmpty(filter))
                        cmd.Parameters.AddWithValue("@filter", "%" + filter + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvSales.DataSource = dt;

                    // Compute summary values
                    decimal totalSales = 0;
                    int transactionCount = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows)
                        totalSales += Convert.ToDecimal(row["TotalAmount"]);

                    decimal averageSale = transactionCount > 0 ? totalSales / transactionCount : 0;

                  
                    lblTotalSaleValue.Text = $"₱{totalSales:N2}";
                    lblTotalTransactions.Text = $"Transactions: {transactionCount}";
                    lblAverageSaleValue.Text = $"₱{averageSale:N2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        // Load chart
     
        private void LoadSalesChart(string mode)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query;

                    if (mode == "Daily")
                    {
                        query = @"SELECT 
    FORMAT(DateTime, 'MMM dd, yyyy') AS Label,
    SUM(TotalAmount) AS Total
FROM Transactions
GROUP BY FORMAT(DateTime, 'MMM dd, yyyy')
ORDER BY MIN(DateTime);";
                    }
                    else if (mode == "Weekly")
                    {
                        query = @"SELECT 
    CONCAT(
        FORMAT(DATEADD(DAY, 1 - DATEPART(WEEKDAY, MIN(DateTime)), MIN(DateTime)), 'MMM dd'),
        ' - ',
        FORMAT(DATEADD(DAY, 7 - DATEPART(WEEKDAY, MAX(DateTime)), MAX(DateTime)), 'MMM dd')
    ) AS Label,
    SUM(TotalAmount) AS Total
FROM Transactions
GROUP BY DATEPART(ISO_WEEK, DateTime)
ORDER BY DATEPART(ISO_WEEK, DateTime);";
                    }
                    else if (mode == "Monthly")
                    {
                        query = @"SELECT 
    FORMAT(DateTime, 'MMMM yyyy') AS Label,
    SUM(TotalAmount) AS Total
FROM Transactions
GROUP BY FORMAT(DateTime, 'MMMM yyyy')
ORDER BY MIN(DateTime);";
                    }
                    else
                    {
                  
                        LoadSalesChart("Daily");
                        return;
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    salesChart.Series.Clear();
                    Series series = new Series("Sales");
                    series.ChartType = SeriesChartType.Column;
                    series.IsValueShownAsLabel = true;

                    foreach (DataRow row in dt.Rows)
                        series.Points.AddXY(row["Label"], row["Total"]);

                    salesChart.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalesControl_Load(object sender, EventArgs e)
        {
            
            dgvSales.BringToFront();

          
            LoadSales(new System.DateTime(2000, 1, 1), System.DateTime.Today);
            LoadDefaultChart();

           
            ApplyRoundRegion(panel4);
            ApplyRoundRegion(button1);
            ApplyRoundRegion(salesChart);
            ApplyRoundRegion(panel2);

            lblTotalSaleValue.ForeColor = Color.FromArgb(0x39, 0xD3, 0x53);
            lblAverageSaleValue.ForeColor = Color.FromArgb(0x39, 0xD3, 0x53);
        }

        
        private void LoadDefaultChart()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string chartQuery = @"
SELECT CAST(t.DateTime AS DATE) AS SaleDate,
       SUM(t.TotalAmount) AS DailyTotal
FROM Transactions t
GROUP BY CAST(t.DateTime AS DATE)
ORDER BY SaleDate;";

                    SqlDataAdapter chartAdapter = new SqlDataAdapter(chartQuery, conn);
                    DataTable chartData = new DataTable();
                    chartAdapter.Fill(chartData);

                    salesChart.Series.Clear();
                    salesChart.Series.Add("Daily Sales");
                    salesChart.Series["Daily Sales"].ChartType = SeriesChartType.Column;
                    salesChart.Series["Daily Sales"].Points.Clear();

                    foreach (DataRow row in chartData.Rows)
                    {
                        DateTime date = Convert.ToDateTime(row["SaleDate"]);
                        decimal total = Convert.ToDecimal(row["DailyTotal"]);
                        salesChart.Series["Daily Sales"].Points.AddXY(date.ToString("MM/dd"), total);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading default chart:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        // Search
       
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSales(dtpFrom.Value, dtpTo.Value, txtSearchSales.Text.Trim());
        }

       
        // Filter button

        private void button1_Click(object sender, EventArgs e)
        {
            LoadSales(dtpFrom.Value, dtpTo.Value, txtSearchSales.Text.Trim());
        }

       
        // Chart radio buttons
       
        private void rbDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDaily.Checked) LoadSalesChart("Daily");
        }

        private void rbWeekly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWeekly.Checked) LoadSalesChart("Weekly");
        }

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMonthly.Checked) LoadSalesChart("Monthly");
        }
    }
}