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
    public partial class AddProductForm : Form
    {
        string connectionString = @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        // 🔹 Materials UI controls (built dynamically)
        private ComboBox cmbMaterial;
        private NumericUpDown numQtyNeeded;
        private Button btnAddMaterial;
        private DataGridView dgvMaterials;

        // 🔹 Holds materials selected for this product before saving
        private class MaterialEntry
        {
            public int MaterialID;
            public string MaterialName;
            public string Unit;
            public decimal QtyNeeded;
        }
        private List<MaterialEntry> selectedMaterials = new List<MaterialEntry>();

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(cmbCategory.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
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

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Please enter a valid stock quantity (whole numbers only).",
                                "Invalid Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    string query = "INSERT INTO Products (productname, category, price, stock, status) " +
                                   "OUTPUT INSERTED.ProductID " +
                                   "VALUES (@name, @cat, @price, @stock, @status)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@cat", cmbCategory.Text);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                    int newProductId = (int)cmd.ExecuteScalar();

                    foreach (var mat in selectedMaterials)
                    {
                        SqlCommand matCmd = new SqlCommand(
                            "INSERT INTO ProductMaterials (ProductID, MaterialID, QuantityNeeded) " +
                            "VALUES (@pid, @mid, @qty)", conn);
                        matCmd.Parameters.AddWithValue("@pid", newProductId);
                        matCmd.Parameters.AddWithValue("@mid", mat.MaterialID);
                        matCmd.Parameters.AddWithValue("@qty", mat.QtyNeeded);
                        matCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Product has been added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving product:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            // Populate Category ComboBox
            cmbCategory.Items.AddRange(new string[]
            {
                "Chaofan",
                "Sizzling",
                "Combo",
                "Flavored Chicken",
                "Beverages",
                "Silog",
                "Ala Carte"
            });

            // Populate Status ComboBox
            cmbStatus.Items.AddRange(new string[]
            {
                "Active",
                "Inactive"
            });

            // Set default selection
            cmbStatus.SelectedIndex = 0; // Active

            BuildMaterialsSection();
            LoadRawMaterials();
        }

        // 🔹 Build the "Required Materials" section dynamically
        private void BuildMaterialsSection()
        {
            // Find the lowest point among existing controls (Status row)
            int startY = cmbStatus.Bottom + 25;

            var lblMaterials = new Label
            {
                Text = "Required Materials/Ingredients:",
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(txtName.Left, startY)
            };

            cmbMaterial = new ComboBox
            {
                Location = new Point(txtName.Left, startY + 28),
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
                Location = new Point(txtName.Left, startY + 64),
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
            btnSave.Location = new Point(btnSave.Left, buttonsY);   // Save
            btnCancel.Location = new Point(btnCancel.Left, buttonsY); // Cancel

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

        private class ComboItem
        {
            public int Id;
            public string Name;
            public string Unit;
            public override string ToString() => Name;
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

            // Prevent duplicate entries
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}