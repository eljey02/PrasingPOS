namespace PrasingsPOS
{
    partial class SalesControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.TransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Change = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAverageSaleValue = new System.Windows.Forms.Label();
            this.lblTotalTransactions = new System.Windows.Forms.Label();
            this.lblTotalSaleValue = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.salesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.txtSearchSales = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblAverageSale = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSales
            // 
            this.dgvSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionID,
            this.DateTime,
            this.ProductSummary,
            this.TotalAmount,
            this.Payment,
            this.Change,
            this.Remarks,
            this.Cashier});
            this.dgvSales.Location = new System.Drawing.Point(24, 132);
            this.dgvSales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.RowHeadersVisible = false;
            this.dgvSales.RowHeadersWidth = 51;
            this.dgvSales.RowTemplate.Height = 24;
            this.dgvSales.Size = new System.Drawing.Size(1081, 283);
            this.dgvSales.TabIndex = 5;
            // 
            // TransactionID
            // 
            this.TransactionID.HeaderText = "ID";
            this.TransactionID.Name = "TransactionID";
            // 
            // DateTime
            // 
            this.DateTime.HeaderText = "Date";
            this.DateTime.Name = "DateTime";
            // 
            // ProductSummary
            // 
            this.ProductSummary.HeaderText = "Product/s";
            this.ProductSummary.Name = "ProductSummary";
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "Total Amount";
            this.TotalAmount.Name = "TotalAmount";
            // 
            // Payment
            // 
            this.Payment.HeaderText = "Payment";
            this.Payment.Name = "Payment";
            // 
            // Change
            // 
            this.Change.HeaderText = "Change";
            this.Change.Name = "Change";
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // Cashier
            // 
            this.Cashier.HeaderText = "Cashier Present";
            this.Cashier.Name = "Cashier";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 58);
            this.panel1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(20, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Detailed Sales Overview";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(17, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.label6.Size = new System.Drawing.Size(113, 37);
            this.label6.TabIndex = 2;
            this.label6.Text = "Sales";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFrom.Location = new System.Drawing.Point(571, 95);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(164, 20);
            this.dtpFrom.TabIndex = 9;
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpTo.Location = new System.Drawing.Point(787, 95);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(164, 20);
            this.dtpTo.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(524, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(756, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "To:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(977, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 31);
            this.button1.TabIndex = 10;
            this.button1.Text = "Filter";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblAverageSale);
            this.panel2.Controls.Add(this.lblAverageSaleValue);
            this.panel2.Controls.Add(this.lblTotalTransactions);
            this.panel2.Controls.Add(this.lblTotalSales);
            this.panel2.Controls.Add(this.lblTotalSaleValue);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(24, 420);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(321, 202);
            this.panel2.TabIndex = 11;
            // 
            // lblAverageSaleValue
            // 
            this.lblAverageSaleValue.AutoSize = true;
            this.lblAverageSaleValue.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblAverageSaleValue.Location = new System.Drawing.Point(155, 141);
            this.lblAverageSaleValue.Name = "lblAverageSaleValue";
            this.lblAverageSaleValue.Size = new System.Drawing.Size(28, 25);
            this.lblAverageSaleValue.TabIndex = 3;
            this.lblAverageSaleValue.Text = "--";
            // 
            // lblTotalTransactions
            // 
            this.lblTotalTransactions.AutoSize = true;
            this.lblTotalTransactions.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTotalTransactions.Location = new System.Drawing.Point(8, 104);
            this.lblTotalTransactions.Name = "lblTotalTransactions";
            this.lblTotalTransactions.Size = new System.Drawing.Size(161, 25);
            this.lblTotalTransactions.TabIndex = 2;
            this.lblTotalTransactions.Text = "Total Transactions";
            // 
            // lblTotalSaleValue
            // 
            this.lblTotalSaleValue.AutoSize = true;
            this.lblTotalSaleValue.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTotalSaleValue.Location = new System.Drawing.Point(155, 64);
            this.lblTotalSaleValue.Name = "lblTotalSaleValue";
            this.lblTotalSaleValue.Size = new System.Drawing.Size(28, 25);
            this.lblTotalSaleValue.TabIndex = 1;
            this.lblTotalSaleValue.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 37);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sales Summary:";
            // 
            // salesChart
            // 
            chartArea2.Name = "ChartArea1";
            this.salesChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.salesChart.Legends.Add(legend2);
            this.salesChart.Location = new System.Drawing.Point(351, 420);
            this.salesChart.Name = "salesChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.salesChart.Series.Add(series2);
            this.salesChart.Size = new System.Drawing.Size(754, 202);
            this.salesChart.TabIndex = 4;
            this.salesChart.Text = "chart1";
            // 
            // rbDaily
            // 
            this.rbDaily.AutoSize = true;
            this.rbDaily.BackColor = System.Drawing.Color.White;
            this.rbDaily.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDaily.Location = new System.Drawing.Point(1000, 461);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(54, 21);
            this.rbDaily.TabIndex = 12;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Daily";
            this.rbDaily.UseVisualStyleBackColor = false;
            this.rbDaily.CheckedChanged += new System.EventHandler(this.rbDaily_CheckedChanged);
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.BackColor = System.Drawing.Color.White;
            this.rbWeekly.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rbWeekly.Location = new System.Drawing.Point(1000, 488);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Size = new System.Drawing.Size(66, 21);
            this.rbWeekly.TabIndex = 12;
            this.rbWeekly.TabStop = true;
            this.rbWeekly.Text = "Weekly";
            this.rbWeekly.UseVisualStyleBackColor = false;
            this.rbWeekly.CheckedChanged += new System.EventHandler(this.rbWeekly_CheckedChanged);
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.BackColor = System.Drawing.Color.White;
            this.rbMonthly.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rbMonthly.Location = new System.Drawing.Point(1000, 515);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(73, 21);
            this.rbMonthly.TabIndex = 12;
            this.rbMonthly.TabStop = true;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = false;
            this.rbMonthly.CheckedChanged += new System.EventHandler(this.rbMonthly_CheckedChanged);
            // 
            // txtSearchSales
            // 
            this.txtSearchSales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchSales.Location = new System.Drawing.Point(14, 14);
            this.txtSearchSales.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchSales.Name = "txtSearchSales";
            this.txtSearchSales.Size = new System.Drawing.Size(459, 22);
            this.txtSearchSales.TabIndex = 7;
            this.txtSearchSales.Text = "🔍 Search Sales....";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtSearchSales);
            this.panel4.Location = new System.Drawing.Point(24, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(485, 46);
            this.panel4.TabIndex = 14;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblTotalSales.Location = new System.Drawing.Point(9, 64);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(104, 25);
            this.lblTotalSales.TabIndex = 1;
            this.lblTotalSales.Text = "Total Sales:";
            // 
            // lblAverageSale
            // 
            this.lblAverageSale.AutoSize = true;
            this.lblAverageSale.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.lblAverageSale.Location = new System.Drawing.Point(9, 141);
            this.lblAverageSale.Name = "lblAverageSale";
            this.lblAverageSale.Size = new System.Drawing.Size(125, 25);
            this.lblAverageSale.TabIndex = 3;
            this.lblAverageSale.Text = "Average Sale:";
            // 
            // SalesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbMonthly);
            this.Controls.Add(this.rbDaily);
            this.Controls.Add(this.rbWeekly);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.salesChart);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSales);
            this.Name = "SalesControl";
            this.Size = new System.Drawing.Size(1133, 641);
            this.Load += new System.EventHandler(this.SalesControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAverageSaleValue;
        private System.Windows.Forms.Label lblTotalTransactions;
        private System.Windows.Forms.Label lblTotalSaleValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart salesChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Change;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cashier;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearchSales;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblAverageSale;
        private System.Windows.Forms.Label lblTotalSales;
    }
}
