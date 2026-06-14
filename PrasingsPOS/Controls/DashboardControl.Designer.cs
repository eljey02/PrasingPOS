namespace PrasingsPOS
{
    partial class DashboardControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTodaysSales = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblTodaysTransactions = new System.Windows.Forms.Label();
            this.bbb = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblLowStockItems = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblTodaysExpenses = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chartSalesByCategory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvRecentActivity = new System.Windows.Forms.DataGridView();
            this.Activity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTopSelling = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByCategory)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSelling)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(243)))), ((int)(((byte)(208)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTodaysSales);
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Location = new System.Drawing.Point(46, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 93);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PrasingsPOS.Properties.Resources.money;
            this.pictureBox1.Location = new System.Drawing.Point(41, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 34);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblTodaysSales
            // 
            this.lblTodaysSales.AutoSize = true;
            this.lblTodaysSales.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTodaysSales.Location = new System.Drawing.Point(85, 58);
            this.lblTodaysSales.Name = "lblTodaysSales";
            this.lblTodaysSales.Size = new System.Drawing.Size(28, 25);
            this.lblTodaysSales.TabIndex = 1;
            this.lblTodaysSales.Text = "--";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(76, 15);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(122, 25);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Today\'s Sales";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.lblTodaysTransactions);
            this.panel2.Controls.Add(this.bbb);
            this.panel2.Location = new System.Drawing.Point(308, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(245, 93);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::PrasingsPOS.Properties.Resources.bill;
            this.pictureBox2.Location = new System.Drawing.Point(13, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 34);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lblTodaysTransactions
            // 
            this.lblTodaysTransactions.AutoSize = true;
            this.lblTodaysTransactions.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTodaysTransactions.Location = new System.Drawing.Point(83, 58);
            this.lblTodaysTransactions.Name = "lblTodaysTransactions";
            this.lblTodaysTransactions.Size = new System.Drawing.Size(28, 25);
            this.lblTodaysTransactions.TabIndex = 1;
            this.lblTodaysTransactions.Text = "--";
            // 
            // bbb
            // 
            this.bbb.AutoSize = true;
            this.bbb.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbb.Location = new System.Drawing.Point(44, 15);
            this.bbb.Name = "bbb";
            this.bbb.Size = new System.Drawing.Size(184, 25);
            this.bbb.TabIndex = 0;
            this.bbb.Text = "Today\'s Transactions";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(166)))), ((int)(((byte)(151)))));
            this.panel3.Controls.Add(this.pictureBox5);
            this.panel3.Controls.Add(this.lblLowStockItems);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(569, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(245, 93);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::PrasingsPOS.Properties.Resources.warning__1_;
            this.pictureBox5.Location = new System.Drawing.Point(34, 12);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(34, 34);
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // lblLowStockItems
            // 
            this.lblLowStockItems.AutoSize = true;
            this.lblLowStockItems.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblLowStockItems.Location = new System.Drawing.Point(97, 58);
            this.lblLowStockItems.Name = "lblLowStockItems";
            this.lblLowStockItems.Size = new System.Drawing.Size(28, 25);
            this.lblLowStockItems.TabIndex = 1;
            this.lblLowStockItems.Text = "--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Low Stock Items";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Controls.Add(this.lblTodaysExpenses);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(831, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 93);
            this.panel4.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::PrasingsPOS.Properties.Resources.profit;
            this.pictureBox4.Location = new System.Drawing.Point(35, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 34);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // lblTodaysExpenses
            // 
            this.lblTodaysExpenses.AutoSize = true;
            this.lblTodaysExpenses.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTodaysExpenses.Location = new System.Drawing.Point(83, 58);
            this.lblTodaysExpenses.Name = "lblTodaysExpenses";
            this.lblTodaysExpenses.Size = new System.Drawing.Size(28, 25);
            this.lblTodaysExpenses.TabIndex = 1;
            this.lblTodaysExpenses.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(63, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Today\'s Expenses";
            // 
            // chartSalesByCategory
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSalesByCategory.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSalesByCategory.Legends.Add(legend3);
            this.chartSalesByCategory.Location = new System.Drawing.Point(46, 208);
            this.chartSalesByCategory.Name = "chartSalesByCategory";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartSalesByCategory.Series.Add(series3);
            this.chartSalesByCategory.Size = new System.Drawing.Size(507, 231);
            this.chartSalesByCategory.TabIndex = 1;
            this.chartSalesByCategory.Text = "chart1";
            this.chartSalesByCategory.Click += new System.EventHandler(this.chartSalesByCategory_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(46, 175);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(507, 32);
            this.panel5.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.label9.Location = new System.Drawing.Point(16, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Sales by Category";
            // 
            // dgvRecentActivity
            // 
            this.dgvRecentActivity.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentActivity.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentActivity.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRecentActivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentActivity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Activity,
            this.Time});
            this.dgvRecentActivity.Location = new System.Drawing.Point(46, 482);
            this.dgvRecentActivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRecentActivity.Name = "dgvRecentActivity";
            this.dgvRecentActivity.RowHeadersVisible = false;
            this.dgvRecentActivity.RowHeadersWidth = 51;
            this.dgvRecentActivity.RowTemplate.Height = 24;
            this.dgvRecentActivity.Size = new System.Drawing.Size(507, 158);
            this.dgvRecentActivity.TabIndex = 8;
            // 
            // Activity
            // 
            this.Activity.HeaderText = "Activity";
            this.Activity.Name = "Activity";
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvLowStock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLowStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Stock});
            this.dgvLowStock.Location = new System.Drawing.Point(569, 433);
            this.dgvLowStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.RowHeadersVisible = false;
            this.dgvLowStock.RowHeadersWidth = 51;
            this.dgvLowStock.RowTemplate.Height = 24;
            this.dgvLowStock.Size = new System.Drawing.Size(507, 207);
            this.dgvLowStock.TabIndex = 9;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            // 
            // dgvTopSelling
            // 
            this.dgvTopSelling.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopSelling.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTopSelling.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTopSelling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopSelling.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product,
            this.Sold});
            this.dgvTopSelling.Location = new System.Drawing.Point(569, 208);
            this.dgvTopSelling.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTopSelling.Name = "dgvTopSelling";
            this.dgvTopSelling.RowHeadersVisible = false;
            this.dgvTopSelling.RowHeadersWidth = 51;
            this.dgvTopSelling.RowTemplate.Height = 24;
            this.dgvTopSelling.Size = new System.Drawing.Size(507, 185);
            this.dgvTopSelling.TabIndex = 10;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            // 
            // Sold
            // 
            this.Sold.HeaderText = "Sold";
            this.Sold.Name = "Sold";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.label10);
            this.panel6.Location = new System.Drawing.Point(569, 176);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(507, 32);
            this.panel6.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.label10.Location = new System.Drawing.Point(20, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 23);
            this.label10.TabIndex = 0;
            this.label10.Text = "Top Selling Products";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.label12);
            this.panel7.Location = new System.Drawing.Point(46, 451);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(507, 32);
            this.panel7.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.label12.Location = new System.Drawing.Point(16, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 23);
            this.label12.TabIndex = 0;
            this.label12.Text = "Recent Activity";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.label11);
            this.panel9.Location = new System.Drawing.Point(569, 401);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(507, 32);
            this.panel9.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12.25F);
            this.label11.Location = new System.Drawing.Point(20, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 23);
            this.label11.TabIndex = 0;
            this.label11.Text = "Low Stock Items";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.label1);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1124, 58);
            this.panel8.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Modules Overview and Sales Insights";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Overview";
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.dgvRecentActivity);
            this.Controls.Add(this.dgvLowStock);
            this.Controls.Add(this.dgvTopSelling);
            this.Controls.Add(this.chartSalesByCategory);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(1124, 653);
            this.Load += new System.EventHandler(this.DashboardControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesByCategory)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentActivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSelling)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesByCategory;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvRecentActivity;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.DataGridView dgvTopSelling;
        private System.Windows.Forms.Label lblTodaysSales;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblTodaysTransactions;
        private System.Windows.Forms.Label bbb;
        private System.Windows.Forms.Label lblLowStockItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTodaysExpenses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sold;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}
