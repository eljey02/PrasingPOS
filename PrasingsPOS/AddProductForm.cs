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
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (productname, category, price, stock, status) " +
                               "VALUES (@name, @cat, @price, @stock, @status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@cat", cmbCategory.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
                cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStock.Text));
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Product has been added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK; // closes popup and signals success
            this.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            this.Load += new System.EventHandler(this.AddProductForm_Load);
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
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }

