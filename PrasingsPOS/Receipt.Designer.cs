namespace PrasingsPOS
{
    partial class Receipt
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
            this.rtbReceipt = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbReceipt
            // 
            this.rtbReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbReceipt.Location = new System.Drawing.Point(0, 0);
            this.rtbReceipt.Name = "rtbReceipt";
            this.rtbReceipt.Size = new System.Drawing.Size(382, 553);
            this.rtbReceipt.TabIndex = 0;
            this.rtbReceipt.Text = "";
            // 
            // Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 553);
            this.Controls.Add(this.rtbReceipt);
            this.Name = "Receipt";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Receipt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbReceipt;
    }
}