namespace PrasingsPOS
{
    partial class POS
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POS));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.lblChange = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanelProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ItemGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button10 = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox10);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1434, 64);
            this.panel2.TabIndex = 4;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Black;
            this.lblTime.Location = new System.Drawing.Point(1100, 31);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(44, 20);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "Time";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.White;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(1101, 12);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 20);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(339, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hello, (Cashier name dapat to)";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.dgvOrder);
            this.panel12.Controls.Add(this.txtPayment);
            this.panel12.Controls.Add(this.button14);
            this.panel12.Controls.Add(this.button15);
            this.panel12.Controls.Add(this.button13);
            this.panel12.Controls.Add(this.button12);
            this.panel12.Controls.Add(this.lblChange);
            this.panel12.Controls.Add(this.label25);
            this.panel12.Controls.Add(this.label23);
            this.panel12.Controls.Add(this.lblGrandTotal);
            this.panel12.Controls.Add(this.label22);
            this.panel12.Location = new System.Drawing.Point(818, 68);
            this.panel12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(617, 714);
            this.panel12.TabIndex = 10;
            this.panel12.Paint += new System.Windows.Forms.PaintEventHandler(this.panel12_Paint);
            // 
            // dgvOrder
            // 
            this.dgvOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemGrid,
            this.QtyGrid,
            this.PriceGrid,
            this.TotalGrid,
            this.ProductID});
            this.dgvOrder.Location = new System.Drawing.Point(13, 70);
            this.dgvOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.Size = new System.Drawing.Size(599, 411);
            this.dgvOrder.TabIndex = 12;
            // 
            // txtPayment
            // 
            this.txtPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtPayment.Location = new System.Drawing.Point(112, 578);
            this.txtPayment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(168, 26);
            this.txtPayment.TabIndex = 11;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Firebrick;
            this.button14.Font = new System.Drawing.Font("Segoe Fluent Icons", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button14.Location = new System.Drawing.Point(138, 658);
            this.button14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(386, 52);
            this.button14.TabIndex = 9;
            this.button14.Text = "Process Order";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button15.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(345, 555);
            this.button15.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(136, 63);
            this.button15.TabIndex = 9;
            this.button15.Text = "Calculate Change";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Yellow;
            this.button13.Font = new System.Drawing.Font("Segoe Fluent Icons", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(132, 489);
            this.button13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(392, 39);
            this.button13.TabIndex = 9;
            this.button13.Text = "Clear Order";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(1219, 17);
            this.button12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(200, 28);
            this.button12.TabIndex = 9;
            this.button12.Text = "Logout";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe Fluent Icons", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(127, 618);
            this.lblChange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(91, 27);
            this.lblChange.TabIndex = 0;
            this.lblChange.Text = "(change)";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(8, 613);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(117, 38);
            this.label25.TabIndex = 0;
            this.label25.Text = "Change:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 575);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(85, 23);
            this.label23.TabIndex = 0;
            this.label23.Text = "Payment:";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(8, 532);
            this.lblGrandTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(161, 38);
            this.lblGrandTotal.TabIndex = 0;
            this.lblGrandTotal.Text = "Total Price:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe Fluent Icons", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(7, 17);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(198, 34);
            this.label22.TabIndex = 0;
            this.label22.Text = "Customer Order";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanelProducts
            // 
            this.flowLayoutPanelProducts.Location = new System.Drawing.Point(4, 134);
            this.flowLayoutPanelProducts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Size = new System.Drawing.Size(794, 633);
            this.flowLayoutPanelProducts.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(4, 71);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 55);
            this.panel1.TabIndex = 12;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtSearch.Location = new System.Drawing.Point(42, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(712, 36);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ItemGrid
            // 
            this.ItemGrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemGrid.HeaderText = "Item";
            this.ItemGrid.MinimumWidth = 10;
            this.ItemGrid.Name = "ItemGrid";
            this.ItemGrid.ReadOnly = true;
            // 
            // QtyGrid
            // 
            this.QtyGrid.HeaderText = "Qty";
            this.QtyGrid.MinimumWidth = 6;
            this.QtyGrid.Name = "QtyGrid";
            this.QtyGrid.ReadOnly = true;
            this.QtyGrid.Width = 40;
            // 
            // PriceGrid
            // 
            this.PriceGrid.HeaderText = "Price";
            this.PriceGrid.MinimumWidth = 6;
            this.PriceGrid.Name = "PriceGrid";
            this.PriceGrid.ReadOnly = true;
            this.PriceGrid.Width = 80;
            // 
            // TotalGrid
            // 
            this.TotalGrid.HeaderText = "Total";
            this.TotalGrid.MinimumWidth = 6;
            this.TotalGrid.Name = "TotalGrid";
            this.TotalGrid.ReadOnly = true;
            this.TotalGrid.Width = 80;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            this.ProductID.Width = 125;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBox1.Image = global::PrasingsPOS.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(47, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button10
            // 
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Image = global::PrasingsPOS.Properties.Resources.sign_out_alt__1_;
            this.button10.Location = new System.Drawing.Point(1358, 0);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(71, 58);
            this.button10.TabIndex = 9;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBox10.Image = global::PrasingsPOS.Properties.Resources.bayag;
            this.pictureBox10.Location = new System.Drawing.Point(4, 4);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(73, 60);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 10;
            this.pictureBox10.TabStop = false;
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1439, 782);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanelProducts);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "POS";
            this.Text = "POS";
            this.Load += new System.EventHandler(this.user_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
    }
}