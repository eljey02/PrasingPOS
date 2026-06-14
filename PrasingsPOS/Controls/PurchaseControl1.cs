using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class PurchaseControl1 : UserControl
    {
        private string connectionString =
            @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        [DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

       
        [DllImport("Gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        public PurchaseControl1()
        {
            InitializeComponent();
            dgvExpenses.AutoGenerateColumns = false;
            SetupGridColumns();
            LoadMaterials();
            LoadExpenses();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yy";

            // Cost per unit is computed
            txtCostPerUnit.ReadOnly = true;
        }

        // Define DataGridView columns manually
        private void SetupGridColumns()
        {
            dgvExpenses.Columns.Clear();
            dgvExpenses.Columns.Add("ID", "ID");
            dgvExpenses.Columns.Add("Material", "Material");
            dgvExpenses.Columns.Add("Quantity", "Quantity");
            dgvExpenses.Columns.Add("Unit", "Unit");
            dgvExpenses.Columns.Add("CostPerUnit", "Cost/Unit");
            dgvExpenses.Columns.Add("TotalCost", "Total Cost");

           
            DataGridViewTextBoxColumn dateCol = new DataGridViewTextBoxColumn();
            dateCol.Name = "Date";
            dateCol.HeaderText = "Date";
            dateCol.ValueType = typeof(DateTime);
            dateCol.DefaultCellStyle.Format = "MM/dd/yyyy";
            dgvExpenses.Columns.Add(dateCol);

            dgvExpenses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExpenses.Columns["Material"].FillWeight = 150;
            dgvExpenses.Columns["Quantity"].FillWeight = 80;
            dgvExpenses.Columns["Unit"].FillWeight = 80;
            dgvExpenses.Columns["CostPerUnit"].FillWeight = 100;
            dgvExpenses.Columns["TotalCost"].FillWeight = 100;
            dgvExpenses.Columns["Date"].FillWeight = 120;

            dgvExpenses.RowHeadersVisible = false;
            dgvExpenses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpenses.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvExpenses.RowsDefaultCellStyle.BackColor = Color.White;
            dgvExpenses.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            dgvExpenses.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgvExpenses.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            dgvExpenses.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvExpenses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvExpenses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // Load materials into ComboBox
        private void LoadMaterials()
        {
            comboMaterial.Items.Clear();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT MaterialName FROM RawMaterials", con);
          
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboMaterial.Items.Add(reader["MaterialName"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading materials:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load expense log into DataGridView
        private void LoadExpenses()
        {
            try
            {
                dgvExpenses.Rows.Clear();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT p.PurchaseDetailID, r.MaterialName, p.Quantity, r.Unit, 
                                 p.CostPerUnit, p.TotalCost, p.DateTime
                          FROM PurchaseDetails p
                          INNER JOIN RawMaterials r ON p.MaterialID = r.MaterialID", con);

           
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                          
                            dgvExpenses.Rows.Add(
                                reader["PurchaseDetailID"],
                                reader["MaterialName"],
                                reader["Quantity"],
                                reader["Unit"],
                                reader["CostPerUnit"],
                                reader["TotalCost"],
                                Convert.ToDateTime(reader["DateTime"])
                            );
                        }
                    }
                }

                UpdateTotalExpenses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading expenses:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Show current stock when material is selected
        private void comboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboMaterial.Text))
            {
                lblStock.Text = "Current Stock: --";
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT StockQty, Unit FROM RawMaterials WHERE MaterialName=@name", con);
                    cmd.Parameters.AddWithValue("@name", comboMaterial.Text.Trim());

          
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            lblStock.Text = $"Current Stock: {reader["StockQty"]} {reader["Unit"]}";
                        else
                            lblStock.Text = "Current Stock: 0";
                    }
                }
            }
            catch (Exception ex)
            {
                lblStock.Text = "Current Stock: --";
                MessageBox.Show("Error loading stock:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Auto-calculate Cost per Unit from Total Cost ÷ Quantity
        private void numQuantity_ValueChanged(object sender, EventArgs e) => CalculateCostPerUnit();
        private void txtTotalCost_TextChanged(object sender, EventArgs e) => CalculateCostPerUnit();

        private void CalculateCostPerUnit()
        {
            decimal qty = numQuantity.Value;

            if (qty > 0 &&
                !string.IsNullOrWhiteSpace(txtTotalCost.Text) &&
                decimal.TryParse(txtTotalCost.Text, out decimal totalCost))
            {
                txtCostPerUnit.Text = (totalCost / qty).ToString("F2");
            }
            else
            {
                txtCostPerUnit.Text = "";
            }
        }

        // Record purchase and update stock
        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (comboMaterial.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a material.");
                return;
            }

            if (!decimal.TryParse(txtTotalCost.Text, out decimal totalCost) || totalCost <= 0)
            {
                MessageBox.Show("Please enter a valid Total Cost.");
                return;
            }

            if (!decimal.TryParse(txtCostPerUnit.Text, out decimal costPerUnit) || costPerUnit <= 0)
            {
                MessageBox.Show("Cost per unit could not be calculated. Check quantity and total cost.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    int materialId = 0;
                    string unit = "";
                    SqlCommand getInfo = new SqlCommand(
                        "SELECT MaterialID, Unit FROM RawMaterials WHERE MaterialName=@name", con);
                    getInfo.Parameters.AddWithValue("@name", comboMaterial.Text);

                    
                    using (SqlDataReader reader = getInfo.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            materialId = Convert.ToInt32(reader["MaterialID"]);
                            unit = reader["Unit"].ToString();
                        }
                    }

                    if (materialId == 0)
                    {
                        MessageBox.Show("Selected material not found in RawMaterials!");
                        return;
                    }


                    SqlCommand cmd = new SqlCommand(
    "INSERT INTO PurchaseDetails(MaterialID, MaterialName, Quantity, Unit, CostPerUnit, TotalCost, DateTime) " +
    "VALUES(@id, @name, @qty, @unit, @cost, @total, @datetime)", con);

                    cmd.Parameters.AddWithValue("@id", materialId);
                    cmd.Parameters.AddWithValue("@name", comboMaterial.Text);
                    cmd.Parameters.AddWithValue("@qty", numQuantity.Value);
                    cmd.Parameters.AddWithValue("@unit", unit);   // already retrieved above
                    cmd.Parameters.AddWithValue("@cost", costPerUnit);
                    cmd.Parameters.AddWithValue("@total", totalCost);
                    cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    SqlCommand updateStock = new SqlCommand(
                        "UPDATE RawMaterials SET StockQty = StockQty + @qty WHERE MaterialID=@id", con);
                    updateStock.Parameters.AddWithValue("@qty", numQuantity.Value);
                    updateStock.Parameters.AddWithValue("@id", materialId);
                    updateStock.ExecuteNonQuery();
                }

                MessageBox.Show("Purchase recorded successfully!");
                LoadExpenses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error recording purchase:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Clear form
        private void btnClear_Click(object sender, EventArgs e)
        {
            comboMaterial.SelectedIndex = -1;
            lblStock.Text = "Current Stock: --";
            numQuantity.Value = 1;
            txtTotalCost.Clear();
            txtCostPerUnit.Clear();
        }

        // Compute total expenses shown in the grid
        private void UpdateTotalExpenses()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvExpenses.Rows)
            {
                if (row.Cells["TotalCost"].Value != null)
                    total += Convert.ToDecimal(row.Cells["TotalCost"].Value);
            }
            lblTotalExpenses.Text = "Total Expenses: ₱" + total.ToString("F2");
        }

        private void PurchaseControl1_Load(object sender, EventArgs e)
        {
            lblStock.Text = "Current Stock: --";

            
            ApplyRoundRegion(panel1);
            ApplyRoundRegion(panel2);
            ApplyRoundRegion(panel3);
            ApplyRoundRegion(btnRecord);
            ApplyRoundRegion(btnClear);
            ApplyRoundRegion(panel5);
            ApplyRoundRegion(btnFilter);
        }

     
        private void ApplyRoundRegion(Control control)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, control.Width, control.Height, 12, 12);
            control.Region = Region.FromHrgn(hRgn);
            DeleteObject(hRgn);
        }

      
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        private void ApplySearchFilter()
        {
            string filter = txtSearch.Text.Trim();

            foreach (DataGridViewRow row in dgvExpenses.Rows)
            {
                if (row.IsNewRow) continue;

                bool match = string.IsNullOrEmpty(filter) ||
                             (row.Cells["Material"].Value != null &&
                              row.Cells["Material"].Value.ToString()
                                  .IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);

                row.Visible = match;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dateTimePicker1.Value.Date;
             
                DateTime toDate = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT p.PurchaseDetailID, r.MaterialName, p.Quantity, r.Unit, 
                                 p.CostPerUnit, p.TotalCost, p.DateTime
                          FROM PurchaseDetails p
                          INNER JOIN RawMaterials r ON p.MaterialID = r.MaterialID
                          WHERE p.DateTime BETWEEN @from AND @to", con);

                    cmd.Parameters.AddWithValue("@from", fromDate);
                    cmd.Parameters.AddWithValue("@to", toDate);

                 
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvExpenses.Rows.Clear();
                        while (reader.Read())
                        {
                    
                            dgvExpenses.Rows.Add(
                                reader["PurchaseDetailID"],
                                reader["MaterialName"],
                                reader["Quantity"],
                                reader["Unit"],
                                reader["CostPerUnit"],
                                reader["TotalCost"],
                                Convert.ToDateTime(reader["DateTime"])
                            );
                        }
                    }
                }

          
                ApplySearchFilter();
                UpdateTotalExpenses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering expenses:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadExpenses();
        }
    }
}