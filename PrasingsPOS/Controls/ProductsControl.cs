using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class ProductsControl : UserControl
    {
        string connectionString = @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        [DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        
        [DllImport("Gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        public ProductsControl()
        {
            InitializeComponent();
        }

        private void ProductsControl_Load(object sender, EventArgs e)
        {
            dgvProducts.AutoGenerateColumns = false;

            // Fill filter ComboBox
            cmbFilterCategory.Items.AddRange(new string[]
            {
                "All",
                "Chaofan",
                "Sizzling",
                "Combo",
                "Flavored Chicken",
                "Beverages",
                "Silog",
                "Ala Carte"
            });
            cmbFilterCategory.SelectedIndex = 0;

            // Setup DataGridView columns
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProducts.Columns["ProductID"].DataPropertyName = "ProductID";
            dgvProducts.Columns["ProductName"].DataPropertyName = "ProductName";
            dgvProducts.Columns["Category"].DataPropertyName = "Category";
            dgvProducts.Columns["Price"].DataPropertyName = "Price";
            dgvProducts.Columns["Stock"].DataPropertyName = "Stock";
            dgvProducts.Columns["Status"].DataPropertyName = "Status";

            dgvProducts.Columns["ProductName"].FillWeight = 200;
            dgvProducts.Columns["Category"].FillWeight = 100;
            dgvProducts.Columns["Price"].FillWeight = 80;
            dgvProducts.Columns["Stock"].FillWeight = 80;
            dgvProducts.Columns["Status"].FillWeight = 80;

            dgvProducts.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

          
            dgvProducts.RowsDefaultCellStyle.BackColor = Color.White;
            dgvProducts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            dgvProducts.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgvProducts.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            dgvProducts.EnableHeadersVisualStyles = false;
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);

            // Load data
            LoadProducts();

           
            bool panelExists = false;
            foreach (Control c in this.Controls)
            {
                if (c is RoundedPanel && c.Size == new Size(860, 45) && c.Location == new Point(20, 117))
                {
                    panelExists = true;
                    break;
                }
            }

            if (!panelExists)
            {
                RoundedPanel card = new RoundedPanel();
                card.Size = new Size(860, 45);
                card.Location = new Point(20, 117);
                card.BackColor = Color.FromArgb(255, 255, 255);
                card.Radius = 16;
                card.BorderColor = Color.FromArgb(192, 255, 192);
                card.BorderWidth = 2;
                this.Controls.Add(card);
            }

            ApplyRoundRegion(button1);
            ApplyRoundRegion(button2);
            ApplyRoundRegion(btnDeleteProducts);
        }

      
        private void ApplyRoundRegion(Control control)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, control.Width, control.Height, 12, 12);
            control.Region = Region.FromHrgn(hRgn);
            DeleteObject(hRgn);
        }

        // Reusable LoadProducts method
        private void LoadProducts(string filterQuery = "", SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
SELECT 
    p.productid AS ProductID,
    p.productname AS ProductName,
    p.category AS Category,
    p.price AS Price,
    CAST(
        ISNULL(
            (SELECT MIN(r.StockQty / pm.QuantityNeeded)
             FROM ProductMaterials pm
             JOIN RawMaterials r ON pm.MaterialID = r.MaterialID
             WHERE pm.ProductID = p.ProductID AND pm.QuantityNeeded > 0), 0
        ) AS DECIMAL(10,2)
    ) AS Stock,
    p.status AS Status
FROM Products p";

                    if (!string.IsNullOrEmpty(filterQuery))
                        query += " WHERE " + filterQuery;

                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProducts.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ComboBox filter logic
        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Add Product button
        private void button1_Click(object sender, EventArgs e)
        {
            AddProductForm addForm = new AddProductForm();
            if (addForm.ShowDialog() == DialogResult.OK)
                LoadProducts();
        }

        // Delete Product button
        private void btnDeleteProducts_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to remove.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductID"].Value);
            string productName = dgvProducts.CurrentRow.Cells["ProductName"].Value.ToString();

           
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if this product has any transaction history
                    SqlCommand checkCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM TransactionDetails WHERE ProductID=@id", conn);
                    checkCmd.Parameters.AddWithValue("@id", productId);
                    int usageCount = (int)checkCmd.ExecuteScalar();

                    if (usageCount > 0)
                    {
                        // Has sales history 
                        DialogResult result = MessageBox.Show(
                            $"\"{productName}\" has existing transaction records and cannot be permanently deleted.\n\n" +
                            "It will instead be marked as Inactive so it no longer appears in the POS.",
                            "Cannot Delete — Marking Inactive",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.OK)
                        {
                            SqlCommand deactivateCmd = new SqlCommand(
                                "UPDATE Products SET status='Inactive' WHERE productid=@id", conn);
                            deactivateCmd.Parameters.AddWithValue("@id", productId);
                            deactivateCmd.ExecuteNonQuery();

                            MessageBox.Show("Product has been marked as Inactive.", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        // No sales history 
                        DialogResult result = MessageBox.Show(
                            $"Are you sure you want to permanently remove \"{productName}\"?",
                            "Confirm Delete",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            SqlCommand deleteMaterials = new SqlCommand(
                                "DELETE FROM ProductMaterials WHERE ProductID=@id", conn);
                            deleteMaterials.Parameters.AddWithValue("@id", productId);
                            deleteMaterials.ExecuteNonQuery();

                            SqlCommand deleteCmd = new SqlCommand(
                                "DELETE FROM Products WHERE productid=@id", conn);
                            deleteCmd.Parameters.AddWithValue("@id", productId);
                            deleteCmd.ExecuteNonQuery();

                            MessageBox.Show("Product has been removed successfully!", "Success",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LoadProducts();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string category = cmbFilterCategory.SelectedItem.ToString();
            string keyword = txtSearchProduct.Text.Trim();

            string filter = "";
            var paramList = new System.Collections.Generic.List<SqlParameter>();

            if (category != "All")
            {
                filter = "category = @category";
                paramList.Add(new SqlParameter("@category", category));
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                if (!string.IsNullOrEmpty(filter))
                    filter += " AND ";
                filter += "productname LIKE @keyword";
                paramList.Add(new SqlParameter("@keyword", "%" + keyword + "%"));
            }

            LoadProducts(filter, paramList.ToArray());
        }

        // Edit Product button
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to edit.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductID"].Value);

            EditProductForm editForm = new EditProductForm(productId);
            if (editForm.ShowDialog() == DialogResult.OK)
                LoadProducts();
        }

      
    }
}