namespace PrasingsPOS
{
    partial class EditMaterialForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtStockQty = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStockQtysdsd = new System.Windows.Forms.Label();
            this.txtUnitsdsd = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sdsd = new System.Windows.Forms.Label();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(189, 212);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 33);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.TextChanged += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtStockQty
            // 
            this.txtStockQty.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockQty.Location = new System.Drawing.Point(132, 114);
            this.txtStockQty.Margin = new System.Windows.Forms.Padding(2);
            this.txtStockQty.Name = "txtStockQty";
            this.txtStockQty.Size = new System.Drawing.Size(75, 26);
            this.txtStockQty.TabIndex = 14;
            // 
            // txtUnit
            // 
            this.txtUnit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.Location = new System.Drawing.Point(132, 82);
            this.txtUnit.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(75, 26);
            this.txtUnit.TabIndex = 15;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialName.Location = new System.Drawing.Point(132, 20);
            this.txtMaterialName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(135, 26);
            this.txtMaterialName.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(40, 212);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 33);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Reorder at:";
            // 
            // txtStockQtysdsd
            // 
            this.txtStockQtysdsd.AutoSize = true;
            this.txtStockQtysdsd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockQtysdsd.Location = new System.Drawing.Point(16, 112);
            this.txtStockQtysdsd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtStockQtysdsd.Name = "txtStockQtysdsd";
            this.txtStockQtysdsd.Size = new System.Drawing.Size(56, 21);
            this.txtStockQtysdsd.TabIndex = 7;
            this.txtStockQtysdsd.Text = "Stock:";
            // 
            // txtUnitsdsd
            // 
            this.txtUnitsdsd.AutoSize = true;
            this.txtUnitsdsd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitsdsd.Location = new System.Drawing.Point(16, 80);
            this.txtUnitsdsd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtUnitsdsd.Name = "txtUnitsdsd";
            this.txtUnitsdsd.Size = new System.Drawing.Size(44, 21);
            this.txtUnitsdsd.TabIndex = 8;
            this.txtUnitsdsd.Text = "Unit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Category:";
            // 
            // sdsd
            // 
            this.sdsd.AutoSize = true;
            this.sdsd.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sdsd.Location = new System.Drawing.Point(16, 19);
            this.sdsd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sdsd.Name = "sdsd";
            this.sdsd.Size = new System.Drawing.Size(121, 21);
            this.sdsd.TabIndex = 10;
            this.sdsd.Text = "Material Name:";
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(132, 46);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(2);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(135, 26);
            this.txtCategory.TabIndex = 16;
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReorderLevel.Location = new System.Drawing.Point(132, 142);
            this.txtReorderLevel.Margin = new System.Windows.Forms.Padding(2);
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(75, 26);
            this.txtReorderLevel.TabIndex = 14;
            // 
            // EditMaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 264);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtReorderLevel);
            this.Controls.Add(this.txtStockQty);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtMaterialName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStockQtysdsd);
            this.Controls.Add(this.txtUnitsdsd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sdsd);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditMaterialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtStockQty;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtStockQtysdsd;
        private System.Windows.Forms.Label txtUnitsdsd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label sdsd;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtReorderLevel;
    }
}