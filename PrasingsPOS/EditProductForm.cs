using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class EditProductForm : Form
    {
        private int productId;
        string connectionString = @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        // Constructor that receives the Product ID
        public EditProductForm(int id)
        {
            InitializeComponent();
            productId = id;

            // Populate Category ComboBox
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Chaofan");
            cmbCategory.Items.Add("Sizzling");
            cmbCategory.Items.Add("Lechon");
            cmbCategory.Items.Add("Drinks");

            // Populate Status ComboBox
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");

            lblProductID.Text = "Product ID: " + id.ToString();
            LoadProductDetails();
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
                    numStock.Value = Convert.ToInt32(reader["stock"]); // changed from txtStock.Value
                    cmbStatus.SelectedItem = reader["status"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
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
                cmd.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
                cmd.Parameters.AddWithValue("@stock", (int)numStock.Value);
                cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@id", productId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
