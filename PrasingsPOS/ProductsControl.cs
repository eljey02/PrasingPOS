using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PrasingsPOS
{
    public partial class ProductsControl : UserControl
    {
        string connectionString = @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        public ProductsControl()
        {
            InitializeComponent();
        }

        private void ProductsControl_Load(object sender, EventArgs e)
        {
            dgvProducts.AutoGenerateColumns = false;
            // 🧩 Fill filter ComboBox
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
            cmbFilterCategory.SelectedIndex = 0; // default to All

            // 🧩 Setup DataGridView
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProducts.Columns["ProductID"].DataPropertyName = "productid";
            dgvProducts.Columns["ProductName"].DataPropertyName = "productname";
            dgvProducts.Columns["Category"].DataPropertyName = "category";
            dgvProducts.Columns["Price"].DataPropertyName = "price";
            dgvProducts.Columns["Stock"].DataPropertyName = "stock";
            dgvProducts.Columns["Status"].DataPropertyName = "status";

            dgvProducts.Columns["ProductName"].FillWeight = 200;
            dgvProducts.Columns["Category"].FillWeight = 100;
            dgvProducts.Columns["Price"].FillWeight = 80;
            dgvProducts.Columns["Stock"].FillWeight = 80;
            dgvProducts.Columns["Status"].FillWeight = 80;
            dgvProducts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // ✅ Load once
            LoadProducts();
        }

        // 🧩 Reusable LoadProducts method
        private void LoadProducts(string filterQuery = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                productid AS ProductID,
                productname AS ProductName,
                category AS Category,
                price AS Price,
                stock AS Stock,
                status AS Status
            FROM Products";

                if (!string.IsNullOrEmpty(filterQuery))
                    query += " WHERE " + filterQuery;

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvProducts.DataSource = dt; // binds data to your Designer columns
            }
        }

        // 🧩 ComboBox filter logic
        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedCategory = cmbFilterCategory.SelectedItem.ToString();

            if (selectedCategory == "All")
            {
                LoadProducts(); // show everything
            }
            else
            {
                LoadProducts("category = '" + selectedCategory + "'");
            }
            ApplyFilters();
        }

        // 🧩 Add Product button
        private void button1_Click(object sender, EventArgs e)
        {
            AddProductForm addForm = new AddProductForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts(); // refresh grid after adding
            }
        }

        // 🧩 Delete Product button
        private void btnDeleteProducts_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to remove.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductID"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to remove this product?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Products WHERE productid=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", productId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Product has been removed successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadProducts(); // refresh grid
            }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
            string keyword = txtSearchProduct.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadProducts(); // show all when empty
            }
            else
            {
                // search by product name
                LoadProducts("productname LIKE '%" + keyword + "%'");
            }
        }

            private void ApplyFilters()
            {
                string category = cmbFilterCategory.SelectedItem.ToString();
                string keyword = txtSearchProduct.Text.Trim();
                string filter = "";

                if (category != "All")
                    filter = "category = '" + category + "'";

                if (!string.IsNullOrEmpty(keyword))
                {
                    if (!string.IsNullOrEmpty(filter))
                        filter += " AND ";
                    filter += "productname LIKE '%" + keyword + "%'";
                }

                LoadProducts(filter);
            }

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
            {
                LoadProducts(); // refresh grid after editing
            }
        }
    }
    }

        