using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PrasingsPOS
{
    public partial class DashboardControl : UserControl
    {
        private readonly string connectionString =
            @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
int nWidthEllipse, int nHeightEllipse);

        public DashboardControl()
        {
            InitializeComponent();
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            LoadSummaryCards();
            LoadSalesByCategoryChart();
            LoadTopSellingProducts();
            LoadLowStockItems();
            LoadRecentActivity();

            dgvTopSelling.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvTopSelling.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            

            dgvLowStock.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvLowStock.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            dgvRecentActivity.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvRecentActivity.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            panel1.Region = System.Drawing.Region.FromHrgn(
    CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 12, 12)
);
            panel2.Region = System.Drawing.Region.FromHrgn(
   CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 12, 12)
);
            panel3.Region = System.Drawing.Region.FromHrgn(
   CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 12, 12)
);
            panel4.Region = System.Drawing.Region.FromHrgn(
   CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 12, 12)
);

            chartSalesByCategory.Region = System.Drawing.Region.FromHrgn(
 CreateRoundRectRgn(0, 0, chartSalesByCategory.Width, chartSalesByCategory.Height, 12, 12)
);
           
        }

        // 🧩 Summary Cards
        private void LoadSummaryCards()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                lblTodaysSales.Text = "₱" + Convert.ToDecimal(
                    new SqlCommand("SELECT ISNULL(SUM(TotalAmount),0) FROM Transactions WHERE CAST(DateTime AS DATE)=CAST(GETDATE() AS DATE)", con)
                    .ExecuteScalar()).ToString("#,##0.00");

                lblTodaysTransactions.Text = new SqlCommand(
                    "SELECT COUNT(*) FROM Transactions WHERE CAST(DateTime AS DATE)=CAST(GETDATE() AS DATE)", con)
                    .ExecuteScalar() + " Sale/s";

                lblLowStockItems.Text = new SqlCommand(
                    "SELECT COUNT(*) FROM RawMaterials WHERE StockQty <= ReorderLevel", con)
                    .ExecuteScalar() + " Item/s";

                lblTodaysExpenses.Text = "₱" + Convert.ToDecimal(
                    new SqlCommand("SELECT ISNULL(SUM(TotalCost),0) FROM PurchaseDetails WHERE CAST(DateTime AS DATE)=CAST(GETDATE() AS DATE)", con)
                    .ExecuteScalar()).ToString("#,##0.00");
            }
        }

        // 📊 Sales by Category Chart
        private void LoadSalesByCategoryChart()
        {
            chartSalesByCategory.Series.Clear();
            Series series = new Series("SalesByCategory")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            chartSalesByCategory.Series.Add(series);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT p.Category, SUM(td.SubTotal) AS TotalSales
                    FROM TransactionDetails td
                    INNER JOIN Products p ON td.ProductID = p.ProductID
                    INNER JOIN Transactions t ON td.TransactionID = t.TransactionID
                    GROUP BY p.Category";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    series.Points.AddXY(reader["Category"].ToString(), reader["TotalSales"]);
                }
            }

            chartSalesByCategory.Legends[0].Docking = Docking.Right;
            chartSalesByCategory.Palette = ChartColorPalette.Excel;
        }

        // 🏆 Top Selling Products
        private void LoadTopSellingProducts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                   SELECT TOP 5 
                p.ProductName AS Product,
                SUM(td.Qty) AS Sold
            FROM TransactionDetails td
            INNER JOIN Products p ON td.ProductID = p.ProductID
            GROUP BY p.ProductName
            ORDER BY Sold DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTopSelling.AutoGenerateColumns = false;
                dgvTopSelling.DataSource = dt;
                dgvTopSelling.Columns["Product"].DataPropertyName = "Product";
                dgvTopSelling.Columns["Sold"].DataPropertyName = "Sold";

                dgvTopSelling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTopSelling.Columns["Product"].FillWeight = 70;
                dgvTopSelling.Columns["Sold"].FillWeight = 30;

                dgvTopSelling.RowsDefaultCellStyle.BackColor = Color.FromArgb(0x24, 0x24, 0x24);            // SURFACE
                dgvTopSelling.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(0x2E, 0x2E, 0x2E); // SURFACE2
                dgvTopSelling.RowsDefaultCellStyle.ForeColor = Color.White;
                dgvTopSelling.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

                // ✅ Selected row stays red accent
                dgvTopSelling.RowsDefaultCellStyle.BackColor = Color.White;
                dgvTopSelling.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220); // light gray
                dgvTopSelling.RowsDefaultCellStyle.ForeColor = Color.Black;
                dgvTopSelling.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;


            }
        }

        // ⚠️ Low Stock Items
        private void LoadLowStockItems()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT MaterialName AS Item, StockQty
                    FROM RawMaterials
                    WHERE StockQty <= ReorderLevel
                    ORDER BY StockQty ASC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvLowStock.AutoGenerateColumns = false;
                dgvLowStock.DataSource = dt;
                dgvLowStock.Columns["Item"].DataPropertyName = "Item";
                dgvLowStock.Columns["Stock"].DataPropertyName = "StockQty";

                dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLowStock.Columns["Item"].FillWeight = 60;
                dgvLowStock.Columns["Stock"].FillWeight = 40;

                dgvLowStock.RowsDefaultCellStyle.BackColor = Color.FromArgb(0x24, 0x24, 0x24);            // SURFACE
                dgvLowStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(0x2E, 0x2E, 0x2E); // SURFACE2
                dgvLowStock.RowsDefaultCellStyle.ForeColor = Color.White;
                dgvLowStock.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

                // ✅ Selected row stays red accent
                dgvLowStock.RowsDefaultCellStyle.BackColor = Color.White;
                dgvLowStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220); // light gray
                dgvLowStock.RowsDefaultCellStyle.ForeColor = Color.Black;
                dgvLowStock.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            }
        }

        // 🔄 Recent Activity
        private void LoadRecentActivity()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT TOP 10 Activity, DateTime AS RawTime
            FROM (
                SELECT 'Sale #' + CAST(t.TransactionID AS VARCHAR) + ' - ' + t.CashierName AS Activity, t.DateTime
                FROM Transactions t
                UNION ALL
                SELECT 'Restocked: ' + pd.MaterialName AS Activity, pd.DateTime
                FROM PurchaseDetails pd
            ) a
            ORDER BY DateTime DESC;";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // 🔹 Convert timestamps to “time ago” format
                dt.Columns.Add("Time", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    DateTime time = Convert.ToDateTime(row["RawTime"]);
                    TimeSpan diff = DateTime.Now - time;

                    string display;
                    if (diff.TotalMinutes < 1)
                        display = "Just now";
                    else if (diff.TotalMinutes < 60)
                        display = $"{Math.Floor(diff.TotalMinutes)} minute/s ago";
                    else if (diff.TotalHours < 24)
                        display = $"{Math.Floor(diff.TotalHours)} hour/s ago";
                    else
                        display = $"{Math.Floor(diff.TotalDays)} day/s ago";

                    row["Time"] = display;
                }

                dgvRecentActivity.AutoGenerateColumns = false;
                dgvRecentActivity.DataSource = dt;
                dgvRecentActivity.Columns["Activity"].DataPropertyName = "Activity";
                dgvRecentActivity.Columns["Time"].DataPropertyName = "Time";

                dgvRecentActivity.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvRecentActivity.Columns["Activity"].FillWeight = 65;
                dgvRecentActivity.Columns["Time"].FillWeight = 35;

                dgvRecentActivity.RowsDefaultCellStyle.BackColor = Color.FromArgb(0x24, 0x24, 0x24);            // SURFACE
                dgvRecentActivity.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(0x2E, 0x2E, 0x2E); // SURFACE2
                dgvRecentActivity.RowsDefaultCellStyle.ForeColor = Color.White;
                dgvRecentActivity.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;

                // ✅ Selected row stays red accent
                dgvRecentActivity.RowsDefaultCellStyle.BackColor = Color.White;
                dgvRecentActivity.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220); // light gray
                dgvRecentActivity.RowsDefaultCellStyle.ForeColor = Color.Black;
                dgvRecentActivity.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void chartSalesByCategory_Click(object sender, EventArgs e)
        {

        }
    }
}


