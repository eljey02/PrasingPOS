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
using System.Xml.Linq;

namespace PrasingsPOS
{
    public partial class EditMaterialForm : Form
    {
        private string materialID;

        public EditMaterialForm(string id, string name, string category, string unit, string qty, string reorder)
        {
            InitializeComponent();
            materialID = id;
            txtMaterialName.Text = name;
            txtCategory.Text = category;
            txtUnit.Text = unit;
            txtStockQty.Text = qty;
            txtReorderLevel.Text = reorder;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1️⃣ Check for empty fields
            if (string.IsNullOrWhiteSpace(txtMaterialName.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                string.IsNullOrWhiteSpace(txtUnit.Text) ||
                string.IsNullOrWhiteSpace(txtStockQty.Text) ||
                string.IsNullOrWhiteSpace(txtReorderLevel.Text))
            {
                MessageBox.Show("All fields are required. Please fill them in before saving.");
                return;
            }

            // 2️⃣ Validate numeric fields
            if (!decimal.TryParse(txtStockQty.Text, out decimal stockQty) || stockQty < 0)
            {
                MessageBox.Show("Stock Quantity must be a valid non-negative number.");
                return;
            }

            if (!decimal.TryParse(txtReorderLevel.Text, out decimal reorderLevel) || reorderLevel < 0)
            {
                MessageBox.Show("Reorder Level must be a valid non-negative number.");
                return;
            }

            // 3️⃣ Confirm before saving
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to save these changes?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            // 4️⃣ Proceed with database update
            using (SqlConnection conn = new SqlConnection(
                @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE RawMaterials SET MaterialName=@name, Category=@cat, Unit=@unit, StockQty=@qty, ReorderLevel=@reorder WHERE MaterialID=@id", conn);
                cmd.Parameters.AddWithValue("@id", materialID);
                cmd.Parameters.AddWithValue("@name", txtMaterialName.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text);
                cmd.Parameters.AddWithValue("@qty", stockQty);
                cmd.Parameters.AddWithValue("@reorder", reorderLevel);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Material updated successfully!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}