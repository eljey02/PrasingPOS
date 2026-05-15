using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient; // needed for database access
using System.Text;

namespace PrasingsPOS
{
    public partial class POS : Form
    {
        public POS()
        {
            InitializeComponent();
        }

        private void POS_Load(object sender, EventArgs e)
        {
            timer1.Start();
            LoadProducts(); // load products when form opens
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
        }

        // -------------------------------
        // Load products from DB
        // -------------------------------
        private void LoadProducts(String searchKeyword = " ")

        {
            flowLayoutPanelProducts.Controls.Clear();

            using (SqlConnection conn = new SqlConnection("Data Source=Lj\\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True"))
            {
                conn.Open();
                string query = "SELECT ProductID, ProductName, Price, Category FROM Products";

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query += " WHERE ProductName LIKE @Search";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int productId = reader.GetInt32(0);
                        string productName = reader.GetString(1);
                        decimal price = reader.GetDecimal(2);
                        string category = reader.GetString(3);

                        Button btn = new Button();
                        btn.Text = productName + "\n₱" + price.ToString("N2");
                        btn.Tag = new { ProductID = productId, Price = price };
                        btn.Click += ProductButton_Click;

                        btn.Width = 120;
                        btn.Height = 80;
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;

                        // 🎨 Color by category
                        if (category == "Chaofan")
                            btn.BackColor = Color.Orange;
                        else if (category == "Sizzling")
                            btn.BackColor = Color.Firebrick;
                        else
                            btn.BackColor = Color.DarkSlateBlue;

                        flowLayoutPanelProducts.Controls.Add(btn);
                    }
                }
            }

            string connString = "Data Source=Lj\\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT ProductID, ProductName, Price FROM Products";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int productId = reader.GetInt32(0);
                        string productName = reader.GetString(1);
                        decimal price = reader.GetDecimal(2);

                        Button btn = new Button();
                        btn.Text = productName + "\n₱" + price.ToString("N2");
                        btn.Tag = new { ProductID = productId, Price = price };
                        btn.Click += ProductButton_Click;



                    }
                }
            }
        }

        // -------------------------------
        // Handle product clicks
        // -------------------------------
        private void ProductButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            dynamic tag = btn.Tag;
            int productId = tag.ProductID;
            decimal price = tag.Price;
            string name = btn.Text.Split('\n')[0];

            AddProduct(name, price, productId);
        }

        // -------------------------------
        // Add product to DataGridView
        // -------------------------------
        private void AddProduct(string itemName, decimal price, int productId)
        {
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.Cells["ProductID"].Value != null &&
                    (int)row.Cells["ProductID"].Value == productId)
                {
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    qty++;
                    row.Cells["Qty"].Value = qty;
                    row.Cells["Total"].Value = qty * price;
                    UpdateGrandTotal();
                    return;
                }
            }

            dgvOrder.Rows.Add(productId, itemName, 1, price, price);
            UpdateGrandTotal();
        }

        private void UpdateGrandTotal()
        {
            decimal grandTotal = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                grandTotal += Convert.ToDecimal(row.Cells["Total"].Value);
            }
            lblGrandTotal.Text = "₱" + grandTotal.ToString("N2");
        }

        private void user_Load(object sender, EventArgs e)
        {
            timer1.Start();
            dgvOrder.Columns.Clear();
            dgvOrder.AutoGenerateColumns = false;

            // Hidden ProductID column
            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "ProductID";
            colID.HeaderText = "ProductID";
            colID.Visible = false;
            dgvOrder.Columns.Add(colID);

            // Item column with Fill
            DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
            colItem.Name = "Item";
            colItem.HeaderText = "Item";
            colItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrder.Columns.Add(colItem);

            // Fixed-width numeric columns
            DataGridViewTextBoxColumn colQty = new DataGridViewTextBoxColumn();
            colQty.Name = "Qty";
            colQty.HeaderText = "Qty";
            colQty.Width = 60;
            dgvOrder.Columns.Add(colQty);

            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.Name = "Price";
            colPrice.HeaderText = "Price";
            colPrice.Width = 80;
            dgvOrder.Columns.Add(colPrice);

            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Total";
            colTotal.Width = 80;
            dgvOrder.Columns.Add(colTotal);

            LoadProducts();
        }

        

        private void button13_Click(object sender, EventArgs e)
        {

            dgvOrder.Rows.Clear();
            lblGrandTotal.Text = "₱0.00";
            txtPayment.Text = "";
            lblChange.Text = "₱0.00";


        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPayment.Text, out decimal payment))
            {
                decimal grandTotal = 0;
                foreach (DataGridViewRow row in dgvOrder.Rows)
                {
                    grandTotal += Convert.ToDecimal(row.Cells["Total"].Value);
                }

                // 🔸 Check if payment is insufficient
                if (payment < grandTotal)
                {
                    MessageBox.Show(
                        "Insufficient payment amount. Please collect the full amount before proceeding.",
                        "Payment Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    lblChange.Text = "₱0.00";
                    return;
                }

                // 🔸 Calculate change if payment is enough
                decimal change = payment - grandTotal;
                lblChange.Text = "₱" + change.ToString("N2");
            }
            else
            {
                MessageBox.Show(
                    "Please enter a valid payment amount.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            decimal grandTotal = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.IsNewRow) continue;
                grandTotal += Convert.ToDecimal(row.Cells["Total"].Value);
            }

            if (!decimal.TryParse(txtPayment.Text, out decimal payment))
            {
                MessageBox.Show("Please enter a valid payment amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (payment < grandTotal)
            {
                MessageBox.Show("Insufficient payment amount. Please collect the full amount before proceeding.",
                                "Payment Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal change = payment - grandTotal;
            int transactionId = 0;
            using (SqlConnection conn = new SqlConnection("Data Source=Lj\\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True"))
            {
                conn.Open();

                // 1️⃣ Insert into Transactions (header)
                string transQuery = @"INSERT INTO Transactions (UserID, DateTime, TotalAmount, Payment, Change)
                          VALUES (@UserID, GETDATE(), @TotalAmount, @Payment, @Change);
                          SELECT SCOPE_IDENTITY();";

                SqlCommand transCmd = new SqlCommand(transQuery, conn);
                transCmd.Parameters.AddWithValue("@UserID", 1); // cashier ID
                transCmd.Parameters.AddWithValue("@TotalAmount", grandTotal);
                transCmd.Parameters.AddWithValue("@Payment", payment);
                transCmd.Parameters.AddWithValue("@Change", change);

                

                // 2️⃣ Insert each product into TransactionDetails
                foreach (DataGridViewRow row in dgvOrder.Rows)
                {
                    if (row.IsNewRow) continue;

                    int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

                    string detailQuery = @"INSERT INTO TransactionDetails (TransactionID, ProductID, Qty, Price, Total)
                               VALUES (@TransactionID, @ProductID, @Qty, @Price, @Total)";
                    using (SqlCommand detailCmd = new SqlCommand(detailQuery, conn))
                    {
                        detailCmd.Parameters.AddWithValue("@TransactionID", transactionId);
                        detailCmd.Parameters.AddWithValue("@ProductID", productId);
                        detailCmd.Parameters.AddWithValue("@Qty", qty);
                        detailCmd.Parameters.AddWithValue("@Price", price);
                        detailCmd.Parameters.AddWithValue("@Total", total);
                        detailCmd.ExecuteNonQuery();
                    }
                }
            }

            // 🧾 Build receipt text
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("                   PRASING'S LECHON SIZZLING");
            receipt.AppendLine("                    Official Receipt");
            receipt.AppendLine("----------------------------------------------------------------------");
            receipt.AppendLine("                         Date: " + DateTime.Now);
            receipt.AppendLine("                         Transaction ID: " + transactionId);
            receipt.AppendLine("----------------------------------------------------------------------");
            receipt.AppendLine("    Item\tQty\tPrice\tTotal");

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.IsNewRow) continue;
                string item = row.Cells["Item"].Value.ToString();
                int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                decimal total = Convert.ToDecimal(row.Cells["Total"].Value);
                receipt.AppendLine($"{item}\t{qty}\t₱{price:N2}\t₱{total:N2}");
            }

            receipt.AppendLine("------------------------------------");
            receipt.AppendLine($"Grand Total:\t\t₱{grandTotal:N2}");
            receipt.AppendLine($"Payment:\t\t₱{payment:N2}");
            receipt.AppendLine($"Change:\t\t₱{change:N2}");
            receipt.AppendLine("------------------------------------");
            receipt.AppendLine("Thank you for dining with us!");

            // Show Receipt form instead of MessageBox
            Receipt receiptForm = new Receipt();
            receiptForm.ReceiptText = receipt.ToString();
            receiptForm.ShowDialog();

            // Reset cashier form
            dgvOrder.Rows.Clear();
            lblGrandTotal.Text = "₱0.00";
            txtPayment.Text = "";
            lblChange.Text = "₱0.00";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}



