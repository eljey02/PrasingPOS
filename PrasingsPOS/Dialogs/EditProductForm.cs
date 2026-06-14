using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class EditProductForm : Form
    {
        private int productId;
        string connectionString = @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        // 🔹 Materials UI controls (built dynamically)
        private ComboBox cmbMaterial;
        private NumericUpDown numQtyNeeded;
        private Button btnAddMaterial;
        private DataGridView dgvMaterials;

        private class MaterialEntry
        {
            public int MaterialID;
            public string MaterialName;
            public string Unit;
            public decimal QtyNeeded;
        }
        private List<MaterialEntry> selectedMaterials = new List<MaterialEntry>();

        private class ComboItem
        {
            public int Id;
            public string Name;
            public string Unit;
            public override string ToString() => Name;
        }

        // Constructor that receives the Product ID
        public EditProductForm(int id)
        {
            InitializeComponent();
            productId = id;

            // Populate Category ComboBox
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Chaofan");
            cmbCategory.Items.Add("Sizzling");
            cmbCategory.Items.Add("Combo");
            cmbCategory.Items.Add("Flavored Chicken");
            cmbCategory.Items.Add("Beverages");
            cmbCategory.Items.Add("Silog");
            cmbCategory.Items.Add("Ala Carte");

            // Populate Status ComboBox
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");

            lblProductID.Text = "Product ID: " + id.ToString();
            LoadProductDetails();

            BuildMaterialsSection();
            LoadRawMaterials();
            LoadExistingMaterials();
        }

        // Default constructor (optional, used by Designer)
        public EditProductForm()
        {
            InitializeComponent();
        }

        private void LoadProductDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT productname, category, price, stock, status FROM Products WHERE productid=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", productId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtProductName.Text = reader["productname"].ToString();
                    cmbCategory.SelectedItem = reader["category"].ToString();
                    txtPrice.Text = reader["price"].ToString();
                    numStock.Value = Convert.ToInt32(reader["stock"]);
                    cmbStatus.SelectedItem = reader["status"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                cmbCategory.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Please enter a valid price (numbers only, e.g. 99.50).",
                                "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMaterials.Count == 0)
            {
                MessageBox.Show("Please add at least one required material for this product.",
                                "Missing Materials", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"UPDATE Products
                             SET productname=@name,
                                 category=@category,
                                 price=@price,
                                 stock=@stock,
                                 status=@status
                             WHERE productid=@id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@category", cmbCategory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", (int)numStock.Value);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.ExecuteNonQuery();

                    SqlCommand deleteCmd = new SqlCommand(
                        "DELETE FROM ProductMaterials WHERE ProductID=@id", conn);
                    deleteCmd.Parameters.AddWithValue("@id", productId);
                    deleteCmd.ExecuteNonQuery();

                    foreach (var mat in selectedMaterials)
                    {
                        SqlCommand matCmd = new SqlCommand(
                            "INSERT INTO ProductMaterials (ProductID, MaterialID, QuantityNeeded) " +
                            "VALUES (@pid, @mid, @qty)", conn);
                        matCmd.Parameters.AddWithValue("@pid", productId);
                        matCmd.Parameters.AddWithValue("@mid", mat.MaterialID);
                        matCmd.Parameters.AddWithValue("@qty", mat.QtyNeeded);
                        matCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // 🔹 Build the "Required Materials" section dynamically
        private void BuildMaterialsSection()
        {
            int startY = cmbStatus.Bottom + 25;

            var lblMaterials = new Label
            {
                Text = "Required Materials:",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(txtProductName.Left, startY)
            };

            cmbMaterial = new ComboBox
            {
                Location = new Point(txtProductName.Left, startY + 28),
                Width = 160,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            numQtyNeeded = new NumericUpDown
            {
                Location = new Point(cmbMaterial.Right + 10, startY + 28),
                Width = 70,
                DecimalPlaces = 2,
                Minimum = 0.01m,
                Maximum = 9999,
                Value = 1
            };

            btnAddMaterial = new Button
            {
                Text = "Add",
                Location = new Point(numQtyNeeded.Right + 10, startY + 28),
                Width = 60,
                Height = numQtyNeeded.Height,
                BackColor = Color.FromArgb(0xC0, 0x39, 0x2B),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAddMaterial.FlatAppearance.BorderSize = 0;
            btnAddMaterial.Click += BtnAddMaterial_Click;

            dgvMaterials = new DataGridView
            {
                Location = new Point(txtProductName.Left, startY + 64),
                Size = new Size(360, 120),
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                BackgroundColor = Color.White,
                Font = new Font("Segoe UI", 9)
            };

            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Material",
                HeaderText = "Material",
                FillWeight = 150,
                DataPropertyName = "MaterialName"
            });
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Qty",
                HeaderText = "Qty Needed",
                FillWeight = 80,
                DataPropertyName = "QtyNeeded"
            });
            dgvMaterials.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Unit",
                HeaderText = "Unit",
                FillWeight = 60,
                DataPropertyName = "Unit"
            });

            var removeCol = new DataGridViewButtonColumn
            {
                Name = "Remove",
                HeaderText = "",
                Text = "Remove",
                UseColumnTextForButtonValue = true,
                FillWeight = 60
            };
            dgvMaterials.Columns.Add(removeCol);
            dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMaterials.CellClick += DgvMaterials_CellClick;

            this.Controls.Add(lblMaterials);
            this.Controls.Add(cmbMaterial);
            this.Controls.Add(numQtyNeeded);
            this.Controls.Add(btnAddMaterial);
            this.Controls.Add(dgvMaterials);

            // 🔹 Push Save/Cancel buttons below the materials grid
            int buttonsY = dgvMaterials.Bottom + 20;
            btnSave.Location = new Point(btnSave.Left, buttonsY);
            btnCancel.Location = new Point(btnCancel.Left, buttonsY);

            // 🔹 Resize the form to fit everything
            this.ClientSize = new Size(this.ClientSize.Width, buttonsY + btnSave.Height + 30);
        }

        // 🔹 Load raw materials into the combo box
        private void LoadRawMaterials()
        {
            cmbMaterial.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaterialID, MaterialName, Unit FROM RawMaterials", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbMaterial.Items.Add(new ComboItem
                    {
                        Id = Convert.ToInt32(reader["MaterialID"]),
                        Name = reader["MaterialName"].ToString(),
                        Unit = reader["Unit"].ToString()
                    });
                }
            }
            cmbMaterial.DisplayMember = "Name";
        }

        // 🔹 Pre-load existing ProductMaterials for this product
        private void LoadExistingMaterials()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    @"SELECT pm.MaterialID, r.MaterialName, r.Unit, pm.QuantityNeeded
                      FROM ProductMaterials pm
                      INNER JOIN RawMaterials r ON pm.MaterialID = r.MaterialID
                      WHERE pm.ProductID=@id", conn);
                cmd.Parameters.AddWithValue("@id", productId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    selectedMaterials.Add(new MaterialEntry
                    {
                        MaterialID = Convert.ToInt32(reader["MaterialID"]),
                        MaterialName = reader["MaterialName"].ToString(),
                        Unit = reader["Unit"].ToString(),
                        QtyNeeded = Convert.ToDecimal(reader["QuantityNeeded"])
                    });
                }
            }

            RefreshMaterialsGrid();
        }

        // 🔹 Add a material to the list
        private void BtnAddMaterial_Click(object sender, EventArgs e)
        {
            if (cmbMaterial.SelectedItem == null)
            {
                MessageBox.Show("Please select a material.");
                return;
            }

            var item = (ComboItem)cmbMaterial.SelectedItem;

            if (selectedMaterials.Any(m => m.MaterialID == item.Id))
            {
                MessageBox.Show("This material is already added.");
                return;
            }

            selectedMaterials.Add(new MaterialEntry
            {
                MaterialID = item.Id,
                MaterialName = item.Name,
                Unit = item.Unit,
                QtyNeeded = numQtyNeeded.Value
            });

            RefreshMaterialsGrid();
        }

        // 🔹 Remove a material from the list
        private void DgvMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvMaterials.Columns[e.ColumnIndex].Name == "Remove")
            {
                selectedMaterials.RemoveAt(e.RowIndex);
                RefreshMaterialsGrid();
            }
        }

        private void RefreshMaterialsGrid()
        {
            dgvMaterials.Rows.Clear();
            foreach (var mat in selectedMaterials)
            {
                dgvMaterials.Rows.Add(mat.MaterialName, mat.QtyNeeded, mat.Unit, "Remove");
            }
        }
    }
}