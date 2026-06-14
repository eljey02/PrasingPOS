using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class InventoryControl : UserControl
    {
        private string selectedMaterialID;
        private string connectionString =
            @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public InventoryControl()
        {
            InitializeComponent();
            LoadSummaryCards();
            LoadMaterials();
            LoadSortByFilter();
        }

        private void LoadSummaryCards()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM RawMaterials", conn);
                lblTotalMaterials.Text = ((int)cmdTotal.ExecuteScalar()).ToString();

                SqlCommand cmdLow = new SqlCommand(
                    "SELECT COUNT(*) FROM RawMaterials WHERE StockQty <= ReorderLevel AND StockQty > 0", conn);
                lblLowStockCount.Text = ((int)cmdLow.ExecuteScalar()).ToString();

                SqlCommand cmdOut = new SqlCommand(
                    "SELECT COUNT(*) FROM RawMaterials WHERE StockQty = 0", conn);
                lblOutOfStockCount.Text = ((int)cmdOut.ExecuteScalar()).ToString();
            }
        }

        private void LoadMaterials(string filter = "", string orderBy = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT MaterialID, MaterialName, Category, Unit, StockQty, ReorderLevel FROM RawMaterials";

                if (!string.IsNullOrEmpty(filter))
                    query += " WHERE " + filter;

                if (!string.IsNullOrEmpty(orderBy))
                    query += " ORDER BY " + orderBy;

                dgvMaterials.AutoGenerateColumns = false;

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvMaterials.DataSource = dt;

                dgvMaterials.Columns["MaterialID"].DataPropertyName = "MaterialID";
                dgvMaterials.Columns["MaterialName"].DataPropertyName = "MaterialName";
                dgvMaterials.Columns["Category"].DataPropertyName = "Category";
                dgvMaterials.Columns["Unit"].DataPropertyName = "Unit";
                dgvMaterials.Columns["StockQty"].DataPropertyName = "StockQty";
                dgvMaterials.Columns["ReorderLevel"].DataPropertyName = "ReorderLevel";

                dgvMaterials.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                dgvMaterials.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvMaterials.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvMaterials.RowsDefaultCellStyle.BackColor = Color.White;
                dgvMaterials.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
                dgvMaterials.RowsDefaultCellStyle.ForeColor = Color.Black;
                dgvMaterials.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

                dgvMaterials.EnableHeadersVisualStyles = false;
                dgvMaterials.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(253, 246, 236);
                dgvMaterials.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            }
        }

        private void dgvMaterials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            selectedMaterialID = dgvMaterials.Rows[e.RowIndex].Cells["MaterialID"].Value.ToString();
            string materialName = dgvMaterials.Rows[e.RowIndex].Cells["MaterialName"].Value.ToString();
            lblMaterialName.Text = "Material Name: " + materialName;

            if (e.ColumnIndex == dgvMaterials.Columns["Edit"].Index)
            {
                string id = selectedMaterialID;
                string name = materialName;
                string category = dgvMaterials.Rows[e.RowIndex].Cells["Category"].Value.ToString();
                string unit = dgvMaterials.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
                string qty = dgvMaterials.Rows[e.RowIndex].Cells["StockQty"].Value.ToString();
                string reorder = dgvMaterials.Rows[e.RowIndex].Cells["ReorderLevel"].Value.ToString();

                EditMaterialForm editForm = new EditMaterialForm(id, name, category, unit, qty, reorder);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadMaterials();
                    LoadSummaryCards();
                }
            }
            else if (e.ColumnIndex == dgvMaterials.Columns["Delete"].Index)
            {
                string id = selectedMaterialID;
                string name = materialName;

                DialogResult confirm = MessageBox.Show(
                    $"Are you sure you want to delete '{name}'?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM RawMaterials WHERE MaterialID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Material deleted successfully!");
                    LoadMaterials();
                    LoadSummaryCards();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaterialName.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                string.IsNullOrWhiteSpace(txtUnit.Text) ||
                string.IsNullOrWhiteSpace(txtStockQty.Text) ||
                string.IsNullOrWhiteSpace(txtReorderLevel.Text))
            {
                MessageBox.Show("All fields are required. Please fill them in before adding a material.");
                return;
            }

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

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to add this material?",
                "Confirm Add",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO RawMaterials (MaterialName, Category, Unit, StockQty, ReorderLevel, LastUpdated) " +
                    "VALUES (@name, @cat, @unit, @qty, @reorder, GETDATE())", conn);

                cmd.Parameters.AddWithValue("@name", txtMaterialName.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
                cmd.Parameters.AddWithValue("@unit", txtUnit.Text);
                cmd.Parameters.AddWithValue("@qty", stockQty);
                cmd.Parameters.AddWithValue("@reorder", reorderLevel);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Material added successfully!");
            LoadMaterials();
            LoadSummaryCards();

            txtMaterialName.Clear();
            txtCategory.Clear();
            txtUnit.Clear();
            txtStockQty.Clear();
            txtReorderLevel.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMaterialName.Clear();
            txtCategory.Clear();
            txtUnit.Clear();
            txtStockQty.Clear();
            txtReorderLevel.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void LoadSortByFilter()
        {
            cmbSortBy.Items.Clear();
            cmbSortBy.Items.Add("All");
            cmbSortBy.Items.Add("Low Stock");
            cmbSortBy.Items.Add("Out of Stock");
            cmbSortBy.Items.Add("Reorder Needed");
            cmbSortBy.Items.Add("Stock Ascending");
            cmbSortBy.Items.Add("Stock Descending");
            cmbSortBy.SelectedIndex = 0;
        }

        private void cmbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortOption = cmbSortBy.SelectedItem.ToString();

            switch (sortOption)
            {
                case "All":
                    LoadMaterials();
                    break;
                case "Low Stock":
                    LoadMaterials(filter: "StockQty < ReorderLevel");
                    break;
                case "Out of Stock":
                    LoadMaterials(filter: "StockQty = 0");
                    break;
                case "Reorder Needed":
                    LoadMaterials(filter: "StockQty <= ReorderLevel");
                    break;
                case "Stock Ascending":
                    LoadMaterials(orderBy: "StockQty ASC");
                    break;
                case "Stock Descending":
                    LoadMaterials(orderBy: "StockQty DESC");
                    break;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadMaterials();
            }
            else
            {
                string safeKeyword = keyword.Replace("'", "''");
                string filter = $"MaterialName LIKE '%{safeKeyword}%' OR Category LIKE '%{safeKeyword}%' OR Unit LIKE '%{safeKeyword}%'";
                LoadMaterials(filter);
            }
        }

        private void InventoryControl_Load(object sender, EventArgs e)
        {
            pnlTotalMaterials.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnlTotalMaterials.Width, pnlTotalMaterials.Height, 12, 12));
            pnlLowStock.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnlLowStock.Width, pnlLowStock.Height, 12, 12));
            pnlOutOfStock.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, pnlOutOfStock.Width, pnlOutOfStock.Height, 12, 12));
            panel2.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 12, 12));
            panel3.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 12, 12));
            txtSearch.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, txtSearch.Width, txtSearch.Height, 12, 12));
            btnClear.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnClear.Width, btnClear.Height, 12, 12));
            button1.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 12, 12));
            button2.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 12, 12));

            dgvMaterials.EnableHeadersVisualStyles = false;
            dgvMaterials.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(253, 246, 236);
            dgvMaterials.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
        }
    }
}