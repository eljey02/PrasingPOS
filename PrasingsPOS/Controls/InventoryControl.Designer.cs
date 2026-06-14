namespace PrasingsPOS
{
    partial class InventoryControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flpSummary = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTotalMaterials = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTotalMaterials = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.pnlLowStock = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlOutOfStock = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblOutOfStockCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.MaterialID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReorderLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.d = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flpSummary.SuspendLayout();
            this.pnlTotalMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnlOutOfStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1124, 58);
            this.panel1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(10, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(295, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Restocking and Daily Spending Overview";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventory";
            // 
            // flpSummary
            // 
            this.flpSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            this.flpSummary.Controls.Add(this.pnlTotalMaterials);
            this.flpSummary.Controls.Add(this.pnlLowStock);
            this.flpSummary.Controls.Add(this.pnlOutOfStock);
            this.flpSummary.Location = new System.Drawing.Point(14, 64);
            this.flpSummary.Name = "flpSummary";
            this.flpSummary.Size = new System.Drawing.Size(1094, 111);
            this.flpSummary.TabIndex = 2;
            this.flpSummary.WrapContents = false;
            // 
            // pnlTotalMaterials
            // 
            this.pnlTotalMaterials.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlTotalMaterials.Controls.Add(this.pictureBox1);
            this.pnlTotalMaterials.Controls.Add(this.lblTotalMaterials);
            this.pnlTotalMaterials.Controls.Add(this.lbl);
            this.pnlTotalMaterials.Location = new System.Drawing.Point(70, 15);
            this.pnlTotalMaterials.Margin = new System.Windows.Forms.Padding(70, 15, 10, 10);
            this.pnlTotalMaterials.Name = "pnlTotalMaterials";
            this.pnlTotalMaterials.Size = new System.Drawing.Size(223, 72);
            this.pnlTotalMaterials.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PrasingsPOS.Properties.Resources.fabric;
            this.pictureBox1.Location = new System.Drawing.Point(27, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 32);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // lblTotalMaterials
            // 
            this.lblTotalMaterials.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalMaterials.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMaterials.Location = new System.Drawing.Point(76, 34);
            this.lblTotalMaterials.Name = "lblTotalMaterials";
            this.lblTotalMaterials.Size = new System.Drawing.Size(66, 32);
            this.lblTotalMaterials.TabIndex = 0;
            this.lblTotalMaterials.Text = "00";
            this.lblTotalMaterials.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lbl
            // 
            this.lbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Black;
            this.lbl.Location = new System.Drawing.Point(68, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(138, 25);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Total Materials";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlLowStock
            // 
            this.pnlLowStock.BackColor = System.Drawing.Color.Wheat;
            this.pnlLowStock.Controls.Add(this.pictureBox3);
            this.pnlLowStock.Controls.Add(this.lblLowStockCount);
            this.pnlLowStock.Controls.Add(this.label2);
            this.pnlLowStock.Location = new System.Drawing.Point(423, 15);
            this.pnlLowStock.Margin = new System.Windows.Forms.Padding(120, 15, 3, 3);
            this.pnlLowStock.Name = "pnlLowStock";
            this.pnlLowStock.Size = new System.Drawing.Size(223, 72);
            this.pnlLowStock.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::PrasingsPOS.Properties.Resources.warning__1_;
            this.pictureBox3.Location = new System.Drawing.Point(28, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(34, 34);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // lblLowStockCount
            // 
            this.lblLowStockCount.BackColor = System.Drawing.Color.Transparent;
            this.lblLowStockCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockCount.Location = new System.Drawing.Point(68, 34);
            this.lblLowStockCount.Name = "lblLowStockCount";
            this.lblLowStockCount.Size = new System.Drawing.Size(66, 32);
            this.lblLowStockCount.TabIndex = 0;
            this.lblLowStockCount.Text = "00";
            this.lblLowStockCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(57, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Low Stock Alert";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlOutOfStock
            // 
            this.pnlOutOfStock.BackColor = System.Drawing.Color.Salmon;
            this.pnlOutOfStock.Controls.Add(this.pictureBox2);
            this.pnlOutOfStock.Controls.Add(this.lblOutOfStockCount);
            this.pnlOutOfStock.Controls.Add(this.label4);
            this.pnlOutOfStock.Location = new System.Drawing.Point(759, 15);
            this.pnlOutOfStock.Margin = new System.Windows.Forms.Padding(110, 15, 3, 3);
            this.pnlOutOfStock.Name = "pnlOutOfStock";
            this.pnlOutOfStock.Size = new System.Drawing.Size(223, 72);
            this.pnlOutOfStock.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::PrasingsPOS.Properties.Resources.alert;
            this.pictureBox2.Location = new System.Drawing.Point(38, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // lblOutOfStockCount
            // 
            this.lblOutOfStockCount.BackColor = System.Drawing.Color.Transparent;
            this.lblOutOfStockCount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutOfStockCount.Location = new System.Drawing.Point(68, 34);
            this.lblOutOfStockCount.Name = "lblOutOfStockCount";
            this.lblOutOfStockCount.Size = new System.Drawing.Size(66, 32);
            this.lblOutOfStockCount.TabIndex = 0;
            this.lblOutOfStockCount.Text = "00";
            this.lblOutOfStockCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(69, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Out of Stock";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(307, 181);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(471, 33);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Text = "🔍Search Material...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSortBy.FormattingEnabled = true;
            this.cmbSortBy.Location = new System.Drawing.Point(834, 181);
            this.cmbSortBy.Name = "cmbSortBy";
            this.cmbSortBy.Size = new System.Drawing.Size(168, 29);
            this.cmbSortBy.TabIndex = 4;
            this.cmbSortBy.SelectedIndexChanged += new System.EventHandler(this.cmbSortBy_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(25, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(216, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add Material";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(236)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(45, 98);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "Confirm";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.AllowUserToAddRows = false;
            this.dgvMaterials.AllowUserToResizeRows = false;
            this.dgvMaterials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterials.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaterials.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaterials.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaterialID,
            this.MaterialName,
            this.Category,
            this.Unit,
            this.StockQty,
            this.ReorderLevel,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaterials.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMaterials.Location = new System.Drawing.Point(307, 219);
            this.dgvMaterials.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.RowHeadersVisible = false;
            this.dgvMaterials.RowHeadersWidth = 51;
            this.dgvMaterials.RowTemplate.Height = 24;
            this.dgvMaterials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterials.Size = new System.Drawing.Size(801, 419);
            this.dgvMaterials.TabIndex = 6;
            this.dgvMaterials.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterials_CellContentClick);
            // 
            // MaterialID
            // 
            this.MaterialID.FillWeight = 45.25015F;
            this.MaterialID.HeaderText = "ID";
            this.MaterialID.Name = "MaterialID";
            // 
            // MaterialName
            // 
            this.MaterialName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaterialName.FillWeight = 150F;
            this.MaterialName.HeaderText = "Material";
            this.MaterialName.MinimumWidth = 150;
            this.MaterialName.Name = "MaterialName";
            this.MaterialName.Width = 150;
            // 
            // Category
            // 
            this.Category.FillWeight = 45.25015F;
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // Unit
            // 
            this.Unit.FillWeight = 45.25015F;
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            // 
            // StockQty
            // 
            this.StockQty.FillWeight = 45.25015F;
            this.StockQty.HeaderText = "Stock";
            this.StockQty.Name = "StockQty";
            // 
            // ReorderLevel
            // 
            this.ReorderLevel.FillWeight = 45.25015F;
            this.ReorderLevel.HeaderText = "Reorder";
            this.ReorderLevel.Name = "ReorderLevel";
            // 
            // Edit
            // 
            this.Edit.FillWeight = 45.25015F;
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 45.25015F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "Delete";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.d);
            this.panel2.Controls.Add(this.txtUnit);
            this.panel2.Controls.Add(this.txtReorderLevel);
            this.panel2.Controls.Add(this.txtStockQty);
            this.panel2.Controls.Add(this.txtCategory);
            this.panel2.Controls.Add(this.txtMaterialName);
            this.panel2.Location = new System.Drawing.Point(20, 219);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 269);
            this.panel2.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Moccasin;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(26, 224);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(216, 31);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(178, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Unit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Category";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(155, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Reorder";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "Stock";
            // 
            // d
            // 
            this.d.AutoSize = true;
            this.d.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d.Location = new System.Drawing.Point(77, 7);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(111, 20);
            this.d.TabIndex = 1;
            this.d.Text = "Material Name";
            // 
            // txtUnit
            // 
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnit.Location = new System.Drawing.Point(159, 80);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(82, 20);
            this.txtUnit.TabIndex = 0;
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReorderLevel.Location = new System.Drawing.Point(128, 139);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(113, 20);
            this.txtReorderLevel.TabIndex = 0;
            // 
            // txtStockQty
            // 
            this.txtStockQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockQty.Location = new System.Drawing.Point(25, 139);
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.Size = new System.Drawing.Size(82, 20);
            this.txtStockQty.TabIndex = 0;
            // 
            // txtCategory
            // 
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Location = new System.Drawing.Point(26, 80);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(111, 20);
            this.txtCategory.TabIndex = 0;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaterialName.Location = new System.Drawing.Point(26, 30);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(215, 20);
            this.txtMaterialName.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblMaterialName);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.txtStock);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(18, 494);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 144);
            this.panel3.TabIndex = 8;
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaterialName.Location = new System.Drawing.Point(12, 13);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(121, 21);
            this.lblMaterialName.TabIndex = 6;
            this.lblMaterialName.Text = "Material Name:";
            // 
            // txtStock
            // 
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Location = new System.Drawing.Point(95, 59);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(123, 20);
            this.txtStock.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Stock:";
            // 
            // InventoryControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvMaterials);
            this.Controls.Add(this.cmbSortBy);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.flpSummary);
            this.Controls.Add(this.panel1);
            this.Name = "InventoryControl";
            this.Size = new System.Drawing.Size(1124, 653);
            this.Load += new System.EventHandler(this.InventoryControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flpSummary.ResumeLayout(false);
            this.pnlTotalMaterials.ResumeLayout(false);
            this.pnlTotalMaterials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlLowStock.ResumeLayout(false);
            this.pnlLowStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnlOutOfStock.ResumeLayout(false);
            this.pnlOutOfStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpSummary;
        private System.Windows.Forms.Panel pnlTotalMaterials;
        private System.Windows.Forms.Panel pnlLowStock;
        private System.Windows.Forms.Panel pnlOutOfStock;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvMaterials;
        private System.Windows.Forms.Label lblTotalMaterials;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOutOfStockCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label d;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReorderLevel;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReorderLevel;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
