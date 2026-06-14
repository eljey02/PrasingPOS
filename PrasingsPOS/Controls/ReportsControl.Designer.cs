namespace PrasingsPOS
{
    partial class ReportsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvSalesByCashier = new System.Windows.Forms.DataGridView();
            this.Cashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProfitSummary = new System.Windows.Forms.DataGridView();
            this.Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalSales1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalExpenses1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNetProfit = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chartSalesVsExpenses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartProfitTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvExpenseBreakdown = new System.Windows.Forms.DataGridView();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesByCashier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfitSummary)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesVsExpenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfitTrend)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenseBreakdown)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFrom.Location = new System.Drawing.Point(92, 80);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(134, 25);
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpTo.Location = new System.Drawing.Point(311, 80);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(129, 25);
            this.dtpTo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(271, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "To:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "From:";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.Black;
            this.btnGenerateReport.Location = new System.Drawing.Point(467, 76);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(169, 33);
            this.btnGenerateReport.TabIndex = 5;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel1.Controls.Add(this.lblTotalSales);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(39, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 85);
            this.panel1.TabIndex = 6;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalSales.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTotalSales.Location = new System.Drawing.Point(98, 43);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(28, 25);
            this.lblTotalSales.TabIndex = 1;
            this.lblTotalSales.Text = "--";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(89, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total Sales:";
            // 
            // dgvSalesByCashier
            // 
            this.dgvSalesByCashier.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalesByCashier.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSalesByCashier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesByCashier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cashier,
            this.TotalSales});
            this.dgvSalesByCashier.Location = new System.Drawing.Point(603, 449);
            this.dgvSalesByCashier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSalesByCashier.Name = "dgvSalesByCashier";
            this.dgvSalesByCashier.RowHeadersVisible = false;
            this.dgvSalesByCashier.RowHeadersWidth = 51;
            this.dgvSalesByCashier.RowTemplate.Height = 24;
            this.dgvSalesByCashier.Size = new System.Drawing.Size(248, 192);
            this.dgvSalesByCashier.TabIndex = 7;
            // 
            // Cashier
            // 
            this.Cashier.HeaderText = "Cashier";
            this.Cashier.Name = "Cashier";
            // 
            // TotalSales
            // 
            this.TotalSales.HeaderText = "Total Sales";
            this.TotalSales.Name = "TotalSales";
            // 
            // dgvProfitSummary
            // 
            this.dgvProfitSummary.BackgroundColor = System.Drawing.Color.White;
            this.dgvProfitSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProfitSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfitSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Period,
            this.TotalSales1,
            this.TotalExpenses1,
            this.NetProfit});
            this.dgvProfitSummary.Location = new System.Drawing.Point(20, 449);
            this.dgvProfitSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvProfitSummary.Name = "dgvProfitSummary";
            this.dgvProfitSummary.RowHeadersVisible = false;
            this.dgvProfitSummary.RowHeadersWidth = 51;
            this.dgvProfitSummary.RowTemplate.Height = 24;
            this.dgvProfitSummary.Size = new System.Drawing.Size(580, 192);
            this.dgvProfitSummary.TabIndex = 7;
            // 
            // Period
            // 
            this.Period.HeaderText = "Period";
            this.Period.Name = "Period";
            // 
            // TotalSales1
            // 
            this.TotalSales1.HeaderText = "Total Sales";
            this.TotalSales1.Name = "TotalSales1";
            // 
            // TotalExpenses1
            // 
            this.TotalExpenses1.HeaderText = "Total Expenses";
            this.TotalExpenses1.Name = "TotalExpenses1";
            // 
            // NetProfit
            // 
            this.NetProfit.HeaderText = "Net Profit";
            this.NetProfit.Name = "NetProfit";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel2.Controls.Add(this.lblTotalExpenses);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(408, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(309, 85);
            this.panel2.TabIndex = 6;
            // 
            // lblTotalExpenses
            // 
            this.lblTotalExpenses.AutoSize = true;
            this.lblTotalExpenses.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalExpenses.ForeColor = System.Drawing.Color.Tomato;
            this.lblTotalExpenses.Location = new System.Drawing.Point(109, 43);
            this.lblTotalExpenses.Name = "lblTotalExpenses";
            this.lblTotalExpenses.Size = new System.Drawing.Size(28, 25);
            this.lblTotalExpenses.TabIndex = 1;
            this.lblTotalExpenses.Text = "--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(87, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Total Expenses";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel3.Controls.Add(this.lblNetProfit);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(777, 119);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 85);
            this.panel3.TabIndex = 6;
            // 
            // lblNetProfit
            // 
            this.lblNetProfit.AutoSize = true;
            this.lblNetProfit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblNetProfit.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblNetProfit.Location = new System.Drawing.Point(104, 43);
            this.lblNetProfit.Name = "lblNetProfit";
            this.lblNetProfit.Size = new System.Drawing.Size(28, 25);
            this.lblNetProfit.TabIndex = 1;
            this.lblNetProfit.Text = "--";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(101, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 25);
            this.label9.TabIndex = 0;
            this.label9.Text = "Net Profit:";
            // 
            // chartSalesVsExpenses
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSalesVsExpenses.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSalesVsExpenses.Legends.Add(legend1);
            this.chartSalesVsExpenses.Location = new System.Drawing.Point(20, 243);
            this.chartSalesVsExpenses.Name = "chartSalesVsExpenses";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSalesVsExpenses.Series.Add(series1);
            this.chartSalesVsExpenses.Size = new System.Drawing.Size(530, 173);
            this.chartSalesVsExpenses.TabIndex = 8;
            this.chartSalesVsExpenses.Text = "chart1";
            // 
            // chartProfitTrend
            // 
            chartArea2.Name = "ChartArea1";
            this.chartProfitTrend.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartProfitTrend.Legends.Add(legend2);
            this.chartProfitTrend.Location = new System.Drawing.Point(564, 243);
            this.chartProfitTrend.Name = "chartProfitTrend";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartProfitTrend.Series.Add(series2);
            this.chartProfitTrend.Size = new System.Drawing.Size(541, 173);
            this.chartProfitTrend.TabIndex = 8;
            this.chartProfitTrend.Text = "chart1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Snow;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(603, 422);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(248, 27);
            this.panel4.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sales by Cashier";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Snow;
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(857, 422);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(248, 27);
            this.panel5.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Snow;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Expense Breakdown";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Snow;
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(20, 422);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(580, 27);
            this.panel6.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "Profit Summary";
            // 
            // dgvExpenseBreakdown
            // 
            this.dgvExpenseBreakdown.BackgroundColor = System.Drawing.Color.White;
            this.dgvExpenseBreakdown.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvExpenseBreakdown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpenseBreakdown.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.Amount});
            this.dgvExpenseBreakdown.Location = new System.Drawing.Point(857, 449);
            this.dgvExpenseBreakdown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvExpenseBreakdown.Name = "dgvExpenseBreakdown";
            this.dgvExpenseBreakdown.RowHeadersVisible = false;
            this.dgvExpenseBreakdown.RowHeadersWidth = 51;
            this.dgvExpenseBreakdown.RowTemplate.Height = 24;
            this.dgvExpenseBreakdown.Size = new System.Drawing.Size(248, 192);
            this.dgvExpenseBreakdown.TabIndex = 7;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Snow;
            this.panel7.Controls.Add(this.label10);
            this.panel7.Location = new System.Drawing.Point(20, 216);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(530, 27);
            this.panel7.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.label10.Location = new System.Drawing.Point(3, 2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 23);
            this.label10.TabIndex = 3;
            this.label10.Text = "Sales vs Expenses";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Snow;
            this.panel8.Controls.Add(this.label11);
            this.panel8.Location = new System.Drawing.Point(564, 216);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(541, 27);
            this.panel8.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.label11.Location = new System.Drawing.Point(3, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 23);
            this.label11.TabIndex = 3;
            this.label11.Text = "Profit Trend";
            // 
            // btnExportPDF
            // 
            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(166)))), ((int)(((byte)(151)))));
            this.btnExportPDF.FlatAppearance.BorderSize = 0;
            this.btnExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExportPDF.Location = new System.Drawing.Point(795, 65);
            this.btnExportPDF.Name = "btnExportPDF";
            this.btnExportPDF.Size = new System.Drawing.Size(147, 40);
            this.btnExportPDF.TabIndex = 10;
            this.btnExportPDF.Text = "🗂️ Export to PDF";
            this.btnExportPDF.UseVisualStyleBackColor = false;
            this.btnExportPDF.Click += new System.EventHandler(this.btnExportPDF_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(215)))), ((int)(((byte)(183)))));
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.Location = new System.Drawing.Point(958, 64);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(147, 41);
            this.btnExportExcel.TabIndex = 11;
            this.btnExportExcel.Text = "📄Export to Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(11, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 37);
            this.label12.TabIndex = 5;
            this.label12.Text = "Reports";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.label12);
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1124, 58);
            this.panel9.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sales and Expenses";
            // 
            // ReportsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.chartProfitTrend);
            this.Controls.Add(this.chartSalesVsExpenses);
            this.Controls.Add(this.dgvProfitSummary);
            this.Controls.Add(this.dgvExpenseBreakdown);
            this.Controls.Add(this.dgvSalesByCashier);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReportsControl";
            this.Size = new System.Drawing.Size(1124, 653);
            this.Load += new System.EventHandler(this.ReportsControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesByCashier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfitSummary)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesVsExpenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfitTrend)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenseBreakdown)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSalesByCashier;
        private System.Windows.Forms.DataGridView dgvProfitSummary;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesVsExpenses;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProfitTrend;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.Label lblNetProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSales;
        private System.Windows.Forms.DataGridView dgvExpenseBreakdown;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalSales1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalExpenses1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetProfit;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label4;
    }
}
