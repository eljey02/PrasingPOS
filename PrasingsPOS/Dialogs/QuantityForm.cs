using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class QuantityForm : Form
    {
        public int SelectedQuantity { get; private set; }
        public QuantityForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be at least 1.",
                                "Invalid Quantity",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; 
            }
            SelectedQuantity = (int)numQuantity.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
