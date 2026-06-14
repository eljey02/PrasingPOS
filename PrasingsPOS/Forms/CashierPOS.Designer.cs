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
            this.lblCashierName = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.ItemGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.lblChange = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelAlaCarte = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelBeverages = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelFlavoredChicken = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelCombo = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelSizzling = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelChaofan = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelAll = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelSilog = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRecentTransactions = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(4)))), ((int)(((byte)(15)))));
            this.panel2.Controls.Add(this.btnRecentTransactions);
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.lblDate);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.lblCashierName);
            this.panel2.Controls.Add(this.pictureBox10);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1126, 52);
            this.panel2.TabIndex = 4;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(4)))), ((int)(((byte)(15)))));
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(842, 29);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 15);
            this.lblTime.TabIndex = 15;
            this.lblTime.Text = "Time";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(4)))), ((int)(((byte)(15)))));
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(834, 14);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 15);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "Date";
            // 
            // lblCashierName
            // 
            this.lblCashierName.AutoSize = true;
            this.lblCashierName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashierName.ForeColor = System.Drawing.Color.White;
            this.lblCashierName.Location = new System.Drawing.Point(64, 14);
            this.lblCashierName.Name = "lblCashierName";
            this.lblCashierName.Size = new System.Drawing.Size(119, 25);
            this.lblCashierName.TabIndex = 0;
            this.lblCashierName.Text = "Welcome, --";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.button1);
            this.panel12.Controls.Add(this.label2);
            this.panel12.Controls.Add(this.txtRemarks);
            this.panel12.Controls.Add(this.dgvOrder);
            this.panel12.Controls.Add(this.txtPayment);
            this.panel12.Controls.Add(this.button14);
            this.panel12.Controls.Add(this.button13);
            this.panel12.Controls.Add(this.button12);
            this.panel12.Controls.Add(this.lblChange);
            this.panel12.Controls.Add(this.label25);
            this.panel12.Controls.Add(this.label1);
            this.panel12.Controls.Add(this.label23);
            this.panel12.Controls.Add(this.lblGrandTotal);
            this.panel12.Controls.Add(this.label22);
            this.panel12.Location = new System.Drawing.Point(614, 55);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(513, 615);
            this.panel12.TabIndex = 10;
            this.panel12.Paint += new System.Windows.Forms.PaintEventHandler(this.panel12_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.button1.Location = new System.Drawing.Point(183, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 32);
            this.button1.TabIndex = 15;
            this.button1.Text = "Remove Selected";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(9, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Total Price:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(359, 421);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(127, 22);
            this.txtRemarks.TabIndex = 13;
            // 
            // dgvOrder
            // 
            this.dgvOrder.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemGrid,
            this.QtyGrid,
            this.PriceGrid,
            this.TotalGrid,
            this.ProductID});
            this.dgvOrder.Location = new System.Drawing.Point(10, 57);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.ReadOnly = true;
            this.dgvOrder.RowHeadersVisible = false;
            this.dgvOrder.RowHeadersWidth = 51;
            this.dgvOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrder.Size = new System.Drawing.Size(494, 306);
            this.dgvOrder.TabIndex = 12;
            this.dgvOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellContentClick);
            this.dgvOrder.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellContentClick);
            this.dgvOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrder_CellContentClick);
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
            // txtPayment
            // 
            this.txtPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtPayment.Location = new System.Drawing.Point(14, 483);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(474, 23);
            this.txtPayment.TabIndex = 11;
            this.txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Firebrick;
            this.button14.FlatAppearance.BorderSize = 0;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button14.Location = new System.Drawing.Point(107, 557);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(282, 48);
            this.button14.TabIndex = 9;
            this.button14.Text = "Confirm Order";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Yellow;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(10, 369);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(167, 32);
            this.button13.TabIndex = 9;
            this.button13.Text = "Clear Order";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(914, 14);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(150, 23);
            this.button12.TabIndex = 9;
            this.button12.Text = "Logout";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(113, 512);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(86, 25);
            this.lblChange.TabIndex = 0;
            this.lblChange.Text = "(change)";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(9, 512);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(82, 25);
            this.label25.TabIndex = 0;
            this.label25.Text = "Change:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remarks:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(9, 455);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(92, 25);
            this.label23.TabIndex = 0;
            this.label23.Text = "Payment:";
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrandTotal.Location = new System.Drawing.Point(141, 416);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(36, 25);
            this.lblGrandTotal.TabIndex = 0;
            this.lblGrandTotal.Text = "---";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(5, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(206, 37);
            this.label22.TabIndex = 0;
            this.label22.Text = "Customer Order";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(3, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 58);
            this.panel1.TabIndex = 12;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtSearch.Location = new System.Drawing.Point(12, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(573, 30);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "🔍 Search Products....";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.Silver;
            this.tabPage8.Controls.Add(this.flowLayoutPanelAlaCarte);
            this.tabPage8.Location = new System.Drawing.Point(4, 26);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(596, 528);
            this.tabPage8.TabIndex = 13;
            this.tabPage8.Text = "Ala Carte";
            // 
            // flowLayoutPanelAlaCarte
            // 
            this.flowLayoutPanelAlaCarte.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelAlaCarte.Location = new System.Drawing.Point(7, 6);
            this.flowLayoutPanelAlaCarte.Name = "flowLayoutPanelAlaCarte";
            this.flowLayoutPanelAlaCarte.Size = new System.Drawing.Size(583, 516);
            this.flowLayoutPanelAlaCarte.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.Silver;
            this.tabPage5.Controls.Add(this.flowLayoutPanelBeverages);
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(596, 528);
            this.tabPage5.TabIndex = 11;
            this.tabPage5.Text = "Beverages";
            // 
            // flowLayoutPanelBeverages
            // 
            this.flowLayoutPanelBeverages.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelBeverages.Location = new System.Drawing.Point(7, 6);
            this.flowLayoutPanelBeverages.Name = "flowLayoutPanelBeverages";
            this.flowLayoutPanelBeverages.Size = new System.Drawing.Size(583, 516);
            this.flowLayoutPanelBeverages.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Silver;
            this.tabPage4.Controls.Add(this.flowLayoutPanelFlavoredChicken);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(596, 528);
            this.tabPage4.TabIndex = 10;
            this.tabPage4.Text = "Flavored Chicken";
            // 
            // flowLayoutPanelFlavoredChicken
            // 
            this.flowLayoutPanelFlavoredChicken.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelFlavoredChicken.Location = new System.Drawing.Point(7, 6);
            this.flowLayoutPanelFlavoredChicken.Name = "flowLayoutPanelFlavoredChicken";
            this.flowLayoutPanelFlavoredChicken.Size = new System.Drawing.Size(583, 516);
            this.flowLayoutPanelFlavoredChicken.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Silver;
            this.tabPage3.Controls.Add(this.flowLayoutPanelCombo);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(596, 528);
            this.tabPage3.TabIndex = 9;
            this.tabPage3.Text = "Combo Meals";
            // 
            // flowLayoutPanelCombo
            // 
            this.flowLayoutPanelCombo.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelCombo.Location = new System.Drawing.Point(7, 6);
            this.flowLayoutPanelCombo.Name = "flowLayoutPanelCombo";
            this.flowLayoutPanelCombo.Size = new System.Drawing.Size(583, 516);
            this.flowLayoutPanelCombo.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Silver;
            this.tabPage2.Controls.Add(this.flowLayoutPanelSizzling);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(596, 528);
            this.tabPage2.TabIndex = 8;
            this.tabPage2.Text = "Sizzling Meals";
            // 
            // flowLayoutPanelSizzling
            // 
            this.flowLayoutPanelSizzling.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelSizzling.Location = new System.Drawing.Point(7, 6);
            this.flowLayoutPanelSizzling.Name = "flowLayoutPanelSizzling";
            this.flowLayoutPanelSizzling.Size = new System.Drawing.Size(583, 516);
            this.flowLayoutPanelSizzling.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Silver;
            this.tabPage1.Controls.Add(this.flowLayoutPanelChaofan);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(596, 528);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Chaofan Meals";
            // 
            // flowLayoutPanelChaofan
            // 
            this.flowLayoutPanelChaofan.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelChaofan.Location = new System.Drawing.Point(7, 6);
            this.flowLayoutPanelChaofan.Name = "flowLayoutPanelChaofan";
            this.flowLayoutPanelChaofan.Size = new System.Drawing.Size(583, 516);
            this.flowLayoutPanelChaofan.TabIndex = 3;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.Silver;
            this.tabPage7.Controls.Add(this.flowLayoutPanelAll);
            this.tabPage7.Location = new System.Drawing.Point(4, 26);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(596, 528);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "All";
            // 
            // flowLayoutPanelAll
            // 
            this.flowLayoutPanelAll.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelAll.Location = new System.Drawing.Point(7, 6);
            this.flowLayoutPanelAll.Name = "flowLayoutPanelAll";
            this.flowLayoutPanelAll.Size = new System.Drawing.Size(583, 516);
            this.flowLayoutPanelAll.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(4, 112);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 558);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.Silver;
            this.tabPage6.Controls.Add(this.flowLayoutPanelSilog);
            this.tabPage6.Location = new System.Drawing.Point(4, 26);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(596, 528);
            this.tabPage6.TabIndex = 14;
            this.tabPage6.Text = "Silog Meals";
            // 
            // flowLayoutPanelSilog
            // 
            this.flowLayoutPanelSilog.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelSilog.Location = new System.Drawing.Point(7, 6);
            this.flowLayoutPanelSilog.Name = "flowLayoutPanelSilog";
            this.flowLayoutPanelSilog.Size = new System.Drawing.Size(586, 516);
            this.flowLayoutPanelSilog.TabIndex = 4;
            // 
            // btnRecentTransactions
            // 
            this.btnRecentTransactions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRecentTransactions.FlatAppearance.BorderSize = 0;
            this.btnRecentTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecentTransactions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRecentTransactions.ForeColor = System.Drawing.Color.White;
            this.btnRecentTransactions.Location = new System.Drawing.Point(644, 9);
            this.btnRecentTransactions.Name = "btnRecentTransactions";
            this.btnRecentTransactions.Size = new System.Drawing.Size(146, 35);
            this.btnRecentTransactions.TabIndex = 16;
            this.btnRecentTransactions.Text = " Recent Transactions";
            this.btnRecentTransactions.UseVisualStyleBackColor = false;
            this.btnRecentTransactions.Click += new System.EventHandler(this.btnRecentTransactions_Click);
            // 
            // button10
            // 
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Image = global::PrasingsPOS.Properties.Resources.logout;
            this.button10.Location = new System.Drawing.Point(1057, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(51, 47);
            this.button10.TabIndex = 9;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pictureBox10.Image = global::PrasingsPOS.Properties.Resources.bayag;
            this.pictureBox10.Location = new System.Drawing.Point(3, 3);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(55, 49);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 10;
            this.pictureBox10.TabStop = false;
            // 
            // POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1130, 682);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "POS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS";
            this.Load += new System.EventHandler(this.POS_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCashierName;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAlaCarte;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBeverages;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFlavoredChicken;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCombo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSizzling;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelChaofan;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSilog;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRecentTransactions;
    }
}