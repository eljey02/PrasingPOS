using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Runtime.InteropServices;
using Font = System.Drawing.Font;

namespace PrasingsPOS
{
    public partial class ReportsControl : UserControl
    {
        // Connection string (class-level field)
        private string connectionString = @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";
        private DataTable dt; 

        [DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        [DllImport("Gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        public ReportsControl()
        {
            InitializeComponent();

            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "MM/dd/yyyy";

            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "MM/dd/yyyy";

          
        }

        private void ReportsControl_Load(object sender, EventArgs e)
        {
            // Auto-load with last 7 days
            DateTime fromDate = DateTime.Today.AddDays(-7);
            DateTime toDate = DateTime.Today;

            LoadExpenseBreakdown(fromDate, toDate);
            LoadSalesByCashier(fromDate, toDate);
            LoadProfitSummary(fromDate, toDate);

            SetupSalesVsExpensesChart();
            SetupProfitTrendChart();

            ComputeTotals();

            dgvProfitSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesByCashier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenseBreakdown.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProfitSummary.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvProfitSummary.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvProfitSummary.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvSalesByCashier.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvSalesByCashier.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvSalesByCashier.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvExpenseBreakdown.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvExpenseBreakdown.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvExpenseBreakdown.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

          
            ApplyRoundRegion(btnGenerateReport);
            ApplyRoundRegion(btnExportExcel);
            ApplyRoundRegion(btnExportPDF);
            ApplyRoundRegion(panel1);
            ApplyRoundRegion(panel2);
            ApplyRoundRegion(panel3);
        }

       
        private void ApplyRoundRegion(Control control)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, control.Width, control.Height, 12, 12);
            control.Region = System.Drawing.Region.FromHrgn(hRgn);
            DeleteObject(hRgn);
        }

        // Load Expense Breakdown Grid
       
        private void LoadExpenseBreakdown(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT rm.Category, SUM(pd.TotalCost) AS Amount
                     FROM PurchaseDetails pd
                     INNER JOIN RawMaterials rm ON pd.MaterialID = rm.MaterialID
                     WHERE pd.DateTime >= @from AND pd.DateTime < DATEADD(DAY, 1, @to)
                     GROUP BY rm.Category";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@from", fromDate);
                    da.SelectCommand.Parameters.AddWithValue("@to", toDate);

                    DataTable dtLocal = new DataTable();
                    da.Fill(dtLocal);

                    dgvExpenseBreakdown.AutoGenerateColumns = false;
                    dgvExpenseBreakdown.Columns["Category"].DataPropertyName = "Category";
                    dgvExpenseBreakdown.Columns["Amount"].DataPropertyName = "Amount";
                    dgvExpenseBreakdown.DataSource = dtLocal;

                    // FIX #1: Removed dead dark-theme lines that were immediately overwritten
                    dgvExpenseBreakdown.RowsDefaultCellStyle.BackColor = Color.White;
                    dgvExpenseBreakdown.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
                    dgvExpenseBreakdown.RowsDefaultCellStyle.ForeColor = Color.Black;
                    dgvExpenseBreakdown.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading expense breakdown:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Chart setup
        private void SetupSalesVsExpensesChart()
        {
            if (dt == null || dt.Rows.Count == 0) return;

            chartSalesVsExpenses.Series.Clear();
            var area = chartSalesVsExpenses.ChartAreas[0];
            area.AxisX.Interval = 1;
            area.AxisY.LabelStyle.Format = "₱#,##0";
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.LineColor = Color.Transparent;
            area.AxisY.LineColor = Color.Transparent;
            area.BorderColor = Color.Transparent;
            area.BackColor = Color.WhiteSmoke;

            Series salesSeries = new Series("Sales")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.ForestGreen,
                BorderWidth = 2
            };

            Series expenseSeries = new Series("Expenses")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Orange,
                BorderWidth = 2
            };

            chartSalesVsExpenses.Series.Add(salesSeries);
            chartSalesVsExpenses.Series.Add(expenseSeries);

            foreach (DataRow row in dt.Rows)
            {
                string period = row["Period"].ToString();
                decimal sales = row["TotalSales"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TotalSales"]);
                decimal expenses = row["TotalExpenses"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TotalExpenses"]);

                chartSalesVsExpenses.Series["Sales"].Points.AddXY(period, sales);
                chartSalesVsExpenses.Series["Expenses"].Points.AddXY(period, expenses);
            }

            chartSalesVsExpenses.Legends[0].Docking = Docking.Top;
            chartSalesVsExpenses.Legends[0].Font = new Font("Segoe UI", 9, FontStyle.Bold);
            chartSalesVsExpenses.Legends[0].ForeColor = Color.DimGray;
        }

        // Profit Trend Chart (daily view)
        private void SetupProfitTrendChart()
        {
            if (dt == null || dt.Rows.Count == 0) return;

            chartProfitTrend.Series.Clear();
            var area = chartProfitTrend.ChartAreas[0];
            area.AxisX.Interval = 1;
            area.AxisY.LabelStyle.Format = "₱#,##0";
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            area.AxisX.LabelStyle.Angle = 0;
            area.AxisX.LineColor = Color.Transparent;
            area.AxisY.LineColor = Color.Transparent;
            area.BorderColor = Color.Transparent;
            area.BackColor = Color.WhiteSmoke;

            Series profitSeries = new Series("Profit")
            {
                ChartType = SeriesChartType.SplineArea,
                Color = Color.FromArgb(180, Color.LimeGreen),
                BorderColor = Color.LimeGreen,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 7,
                MarkerColor = Color.White
            };

            Series lossSeries = new Series("Loss")
            {
                ChartType = SeriesChartType.SplineArea,
                Color = Color.FromArgb(180, Color.OrangeRed),
                BorderColor = Color.Red,
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 7,
                MarkerColor = Color.White
            };

            chartProfitTrend.Series.Add(profitSeries);
            chartProfitTrend.Series.Add(lossSeries);

            foreach (DataRow row in dt.Rows)
            {
                string period = row["Period"].ToString();
                decimal profit = row["NetProfit"] == DBNull.Value ? 0 : Convert.ToDecimal(row["NetProfit"]);

                if (profit >= 0)
                    chartProfitTrend.Series["Profit"].Points.AddXY(period, profit);
                else
                    chartProfitTrend.Series["Loss"].Points.AddXY(period, profit);
            }

            chartProfitTrend.Legends[0].Docking = Docking.Top;
            chartProfitTrend.Legends[0].Font = new Font("Segoe UI", 9, FontStyle.Bold);
            chartProfitTrend.Legends[0].ForeColor = Color.DimGray;
        }

        // Load Sales by Cashier Grid
        
        private void LoadSalesByCashier(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT CashierName, SUM(TotalAmount) AS TotalSales 
                     FROM Transactions 
                     WHERE DateTime >= @from AND DateTime < DATEADD(DAY, 1, @to) 
                     GROUP BY CashierName";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@from", fromDate);
                    da.SelectCommand.Parameters.AddWithValue("@to", toDate);

                    DataTable dtLocal = new DataTable();
                    da.Fill(dtLocal);

                    dgvSalesByCashier.AutoGenerateColumns = false;
                    dgvSalesByCashier.Columns["Cashier"].DataPropertyName = "CashierName";
                    dgvSalesByCashier.Columns["TotalSales"].DataPropertyName = "TotalSales";
                    dgvSalesByCashier.DataSource = dtLocal;

                    dgvSalesByCashier.RowsDefaultCellStyle.BackColor = Color.White;
                    dgvSalesByCashier.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
                    dgvSalesByCashier.RowsDefaultCellStyle.ForeColor = Color.Black;
                    dgvSalesByCashier.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales by cashier:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void LoadProfitSummary(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"SELECT 
    FORMAT(s.DateValue, 'MM/dd') AS Period,
    ISNULL(SUM(s.TotalAmount), 0) AS TotalSales,
    ISNULL(SUM(e.TotalCost), 0) AS TotalExpenses,
    ISNULL(SUM(s.TotalAmount), 0) - ISNULL(SUM(e.TotalCost), 0) AS NetProfit
FROM (
    SELECT 
        CAST(DateTime AS DATE) AS DateValue,
        SUM(TotalAmount) AS TotalAmount
    FROM Transactions
    WHERE DateTime >= @from AND DateTime < DATEADD(DAY, 1, @to)
    GROUP BY CAST(DateTime AS DATE)
) s
FULL OUTER JOIN (
    SELECT 
        CAST(DateTime AS DATE) AS DateValue,
        SUM(TotalCost) AS TotalCost
    FROM PurchaseDetails
    WHERE DateTime >= @from AND DateTime < DATEADD(DAY, 1, @to)
    GROUP BY CAST(DateTime AS DATE)
) e ON s.DateValue = e.DateValue
GROUP BY s.DateValue, e.DateValue
ORDER BY MIN(ISNULL(s.DateValue, e.DateValue));";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@from", fromDate);
                    da.SelectCommand.Parameters.AddWithValue("@to", toDate);

                    dt = new DataTable();
                    da.Fill(dt);

                    dgvProfitSummary.AutoGenerateColumns = false;
                    dgvProfitSummary.Columns["Period"].DataPropertyName = "Period";
                    dgvProfitSummary.Columns["TotalSales1"].DataPropertyName = "TotalSales";
                    dgvProfitSummary.Columns["TotalExpenses1"].DataPropertyName = "TotalExpenses";
                    dgvProfitSummary.Columns["NetProfit"].DataPropertyName = "NetProfit";
                    dgvProfitSummary.Columns["TotalSales1"].DefaultCellStyle.Format = "₱#,##0.00";
                    dgvProfitSummary.Columns["TotalExpenses1"].DefaultCellStyle.Format = "₱#,##0.00";
                    dgvProfitSummary.Columns["NetProfit"].DefaultCellStyle.Format = "₱#,##0.00";
                    dgvProfitSummary.DataSource = dt;

                    dgvProfitSummary.RowsDefaultCellStyle.BackColor = Color.White;
                    dgvProfitSummary.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
                    dgvProfitSummary.RowsDefaultCellStyle.ForeColor = Color.Black;
                    dgvProfitSummary.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profit summary:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Compute Totals
        private void ComputeTotals()
        {
            decimal totalSales = dgvSalesByCashier.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Cells["TotalSales"].Value != null)
                .Sum(r => Convert.ToDecimal(r.Cells["TotalSales"].Value));

            decimal totalExpenses = dgvExpenseBreakdown.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Cells["Amount"].Value != null)
                .Sum(r => Convert.ToDecimal(r.Cells["Amount"].Value));

            lblTotalSales.Text = $"₱{totalSales:#,##0.00}";
            lblTotalExpenses.Text = $"₱{totalExpenses:#,##0.00}";
            lblNetProfit.Text = $"₱{(totalSales - totalExpenses):#,##0.00}";
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;

            LoadExpenseBreakdown(fromDate, toDate);
            LoadSalesByCashier(fromDate, toDate);
            LoadProfitSummary(fromDate, toDate);

            SetupSalesVsExpensesChart();
            SetupProfitTrendChart();
            ComputeTotals();
        }

        // Excel Export
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                sfd.FileName = $"PrasingsPOS_Report_{DateTime.Today:MM-dd-yyyy}.xlsx";
                sfd.Title = "Save Excel Report";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var wb = new XLWorkbook())
                    {
                        string range = $"{dtpFrom.Value:MM/dd/yyyy} – {dtpTo.Value:MM/dd/yyyy}";

                        var wsSummary = wb.Worksheets.Add("Profit Summary");
                        WriteSheetHeader(wsSummary, "Profit Summary", range);
                        WriteDataGridToSheet(wsSummary, dgvProfitSummary, startRow: 3);
                        StyleSheet(wsSummary);

                        var wsCashier = wb.Worksheets.Add("Sales by Cashier");
                        WriteSheetHeader(wsCashier, "Sales by Cashier", range);
                        WriteDataGridToSheet(wsCashier, dgvSalesByCashier, startRow: 3);
                        StyleSheet(wsCashier);

                        var wsExpense = wb.Worksheets.Add("Expense Breakdown");
                        WriteSheetHeader(wsExpense, "Expense Breakdown", range);
                        WriteDataGridToSheet(wsExpense, dgvExpenseBreakdown, startRow: 3);
                        StyleSheet(wsExpense);

                        var wsKPI = wb.Worksheets.Add("KPI Summary");
                        WriteKPISheet(wsKPI, range);

                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Excel report exported successfully!", "Export Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed:\n{ex.Message}", "Export Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // PDF Export
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = $"PrasingsPOS_Report_{DateTime.Today:MM-dd-yyyy}.pdf";
                sfd.Title = "Save PDF Report";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    string range = $"{dtpFrom.Value:MM/dd/yyyy} – {dtpTo.Value:MM/dd/yyyy}";

                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate(), 30f, 30f, 30f, 30f);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                        BaseFont bfBold = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
                        var fontTitle = new iTextSharp.text.Font(bfBold, 16, iTextSharp.text.Font.NORMAL, new BaseColor(192, 57, 43));
                        var fontSubtitle = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.ITALIC, new BaseColor(102, 102, 102));
                        var fontSection = new iTextSharp.text.Font(bfBold, 11, iTextSharp.text.Font.NORMAL, new BaseColor(192, 57, 43));
                        var fontHeader = new iTextSharp.text.Font(bfBold, 9, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);
                        var fontCell = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL, new BaseColor(30, 30, 30));
                        var fontKPILabel = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL, new BaseColor(102, 102, 102));
                        var fontKPIValue = new iTextSharp.text.Font(bfBold, 13, iTextSharp.text.Font.NORMAL, new BaseColor(30, 30, 30));

                        doc.Add(new Paragraph("PrasingsPOS – Financial Report", fontTitle) { SpacingAfter = 2f });
                        doc.Add(new Paragraph($"Period: {range}", fontSubtitle) { SpacingAfter = 14f });

                        PdfPTable kpiTable = new PdfPTable(3) { WidthPercentage = 100f, SpacingAfter = 18f };
                        kpiTable.SetWidths(new float[] { 1f, 1f, 1f });
                        AddKPICell(kpiTable, "Total Sales", lblTotalSales.Text, fontKPILabel, fontKPIValue, new BaseColor(34, 139, 34));
                        AddKPICell(kpiTable, "Total Expenses", lblTotalExpenses.Text, fontKPILabel, fontKPIValue, new BaseColor(220, 120, 0));
                        AddKPICell(kpiTable, "Net Profit", lblNetProfit.Text, fontKPILabel, fontKPIValue, new BaseColor(192, 57, 43));
                        doc.Add(kpiTable);

                        doc.Add(new Paragraph("Profit Summary", fontSection) { SpacingAfter = 6f });
                        doc.Add(BuildPdfTable(dgvProfitSummary, fontHeader, fontCell));

                        doc.Add(new Paragraph(" ") { SpacingAfter = 10f });

                        doc.Add(new Paragraph("Sales by Cashier", fontSection) { SpacingAfter = 6f });
                        doc.Add(BuildPdfTable(dgvSalesByCashier, fontHeader, fontCell));

                        doc.Add(new Paragraph(" ") { SpacingAfter = 10f });

                        doc.Add(new Paragraph("Expense Breakdown", fontSection) { SpacingAfter = 6f });
                        doc.Add(BuildPdfTable(dgvExpenseBreakdown, fontHeader, fontCell));

                        doc.Close();
                    }

                    MessageBox.Show("PDF report exported successfully!", "Export Complete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed:\n{ex.Message}", "Export Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //  PDF

        private PdfPTable BuildPdfTable(DataGridView dgv,
            iTextSharp.text.Font fontHeader,
            iTextSharp.text.Font fontCell)
        {
            int colCount = dgv.Columns.Count;
            PdfPTable table = new PdfPTable(colCount) { WidthPercentage = 100f, SpacingAfter = 4f };

            BaseColor headerBg = new BaseColor(192, 57, 43);
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, fontHeader))
                {
                    BackgroundColor = headerBg,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding = 6f,
                    BorderColor = BaseColor.WHITE,
                    BorderWidth = 0.5f
                };
                table.AddCell(cell);
            }

            BaseColor rowLight = new BaseColor(255, 255, 255);
            BaseColor rowAlt = new BaseColor(245, 245, 245);
            int rowIndex = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                BaseColor bg = (rowIndex % 2 == 0) ? rowLight : rowAlt;

                foreach (DataGridViewCell dgvCell in row.Cells)
                {
                    string text = dgvCell.FormattedValue?.ToString() ?? "";
                    PdfPCell cell = new PdfPCell(new Phrase(text, fontCell))
                    {
                        BackgroundColor = bg,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5f,
                        BorderColor = new BaseColor(220, 220, 220),
                        BorderWidth = 0.4f
                    };
                    table.AddCell(cell);
                }
                rowIndex++;
            }

            return table;
        }

        private void AddKPICell(PdfPTable table, string label, string value,
            iTextSharp.text.Font fontLabel,
            iTextSharp.text.Font fontValue,
            BaseColor accentColor)
        {
            PdfPTable inner = new PdfPTable(1) { WidthPercentage = 100f };

            PdfPCell bar = new PdfPCell(new Phrase(" "))
            {
                BackgroundColor = accentColor,
                FixedHeight = 5f,
                Border = iTextSharp.text.Rectangle.NO_BORDER
            };
            inner.AddCell(bar);

            PdfPCell labelCell = new PdfPCell(new Phrase(label, fontLabel))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                PaddingTop = 6f
            };
            inner.AddCell(labelCell);

            PdfPCell valueCell = new PdfPCell(new Phrase(value, fontValue))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                PaddingBottom = 8f
            };
            inner.AddCell(valueCell);

            PdfPCell wrapper = new PdfPCell(inner)
            {
                BackgroundColor = new BaseColor(250, 250, 250),
                BorderColor = new BaseColor(220, 220, 220),
                BorderWidth = 0.5f,
                Padding = 0f
            };
            table.AddCell(wrapper);
        }

        // Helpers: Excel

        private void WriteSheetHeader(IXLWorksheet ws, string title, string dateRange)
        {
            ws.Cell(1, 1).Value = title;
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 14;
            ws.Cell(1, 1).Style.Font.FontColor = XLColor.FromHtml("#C0392B");

            ws.Cell(2, 1).Value = $"Period: {dateRange}";
            ws.Cell(2, 1).Style.Font.Italic = true;
            ws.Cell(2, 1).Style.Font.FontColor = XLColor.FromHtml("#666666");
        }

        private void WriteDataGridToSheet(IXLWorksheet ws, DataGridView dgv, int startRow)
        {
            int col = 1;
            foreach (DataGridViewColumn dgvCol in dgv.Columns)
            {
                var cell = ws.Cell(startRow, col);
                cell.Value = dgvCol.HeaderText;
                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#C0392B");
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                col++;
            }

            int row = startRow + 1;
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                if (dgvRow.IsNewRow) continue;
                col = 1;

                XLColor bg = (row % 2 == 0)
                    ? XLColor.FromHtml("#F5F5F5")
                    : XLColor.White;

                foreach (DataGridViewCell dgvCell in dgvRow.Cells)
                {
                    var cell = ws.Cell(row, col);

                    string raw = dgvCell.FormattedValue?.ToString() ?? "";
                    string clean = raw.Replace("₱", "").Replace(",", "").Trim();
                    if (decimal.TryParse(clean, out decimal num))
                    {
                        cell.Value = num;
                        cell.Style.NumberFormat.Format = "₱#,##0.00";
                    }
                    else
                    {
                        cell.Value = raw;
                    }

                    cell.Style.Fill.BackgroundColor = bg;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    col++;
                }
                row++;
            }
        }

        private void StyleSheet(IXLWorksheet ws)
        {
            var used = ws.RangeUsed();
            if (used == null) return;

            used.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            used.Style.Border.InsideBorderColor = XLColor.FromHtml("#DDDDDD");
            used.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            used.Style.Border.OutsideBorderColor = XLColor.FromHtml("#C0392B");

            ws.ColumnsUsed().AdjustToContents();
        }

        private void WriteKPISheet(IXLWorksheet ws, string dateRange)
        {
            ws.Cell(1, 1).Value = "KPI Summary";
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 14;
            ws.Cell(1, 1).Style.Font.FontColor = XLColor.FromHtml("#C0392B");

            ws.Cell(2, 1).Value = $"Period: {dateRange}";
            ws.Cell(2, 1).Style.Font.Italic = true;
            ws.Cell(2, 1).Style.Font.FontColor = XLColor.FromHtml("#666666");

            string[] headers = { "Metric", "Value" };
            for (int i = 0; i < headers.Length; i++)
            {
                var hCell = ws.Cell(4, i + 1);
                hCell.Value = headers[i];
                hCell.Style.Font.Bold = true;
                hCell.Style.Font.FontColor = XLColor.White;
                hCell.Style.Fill.BackgroundColor = XLColor.FromHtml("#C0392B");
                hCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            var kpis = new[]
            {
                ("Total Sales",    lblTotalSales.Text),
                ("Total Expenses", lblTotalExpenses.Text),
                ("Net Profit",     lblNetProfit.Text)
            };

            int row = 5;
            foreach (var (metric, value) in kpis)
            {
                ws.Cell(row, 1).Value = metric;

                string clean = value.Replace("₱", "").Replace(",", "").Trim();
                if (decimal.TryParse(clean, out decimal num))
                {
                    ws.Cell(row, 2).Value = num;
                    ws.Cell(row, 2).Style.NumberFormat.Format = "₱#,##0.00";
                }
                else
                {
                    ws.Cell(row, 2).Value = value;
                }

                ws.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                ws.Cell(row, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                row++;
            }

            ws.ColumnsUsed().AdjustToContents();
            var used = ws.RangeUsed();
            if (used != null)
            {
                used.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                used.Style.Border.InsideBorderColor = XLColor.FromHtml("#DDDDDD");
                used.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                used.Style.Border.OutsideBorderColor = XLColor.FromHtml("#C0392B");
            }
        }
    }
}