using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text;

namespace PrasingsPOS
{
    public partial class POS : Form
    {
        private int currentUserID;
        private string cashierName;
        string connectionString = "Data Source=Lj\\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";
       
        [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
    int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
    int nWidthEllipse, int nHeightEllipse);


        public POS(string userName, int userID)
        {
            InitializeComponent();
            cashierName = userName;
            currentUserID = userID;
            lblCashierName.Text = "Welcome, " + cashierName;
        }

        private void POS_Load(object sender, EventArgs e)
        {
            timer1.Start();
            LoadProducts();

            button14.Region = System.Drawing.Region.FromHrgn(
        CreateRoundRectRgn(0, 0, button14.Width, button14.Height, 12, 12)
        );

            button13.Region = System.Drawing.Region.FromHrgn(
        CreateRoundRectRgn(0, 0, button13.Width, button13.Height, 12, 12)
        );

            button1.Region = System.Drawing.Region.FromHrgn(
        CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 12, 12)
        );

            btnRecentTransactions.Region = System.Drawing.Region.FromHrgn(
        CreateRoundRectRgn(0, 0, btnRecentTransactions.Width, btnRecentTransactions.Height, 12, 12)
        );

            panel1.Region = System.Drawing.Region.FromHrgn(
    CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 12, 12)
);

            panel12.Region = System.Drawing.Region.FromHrgn(
    CreateRoundRectRgn(0, 0, panel12.Width, panel12.Height, 12, 12)
);
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
        // Get available stock for a product
        // Accounts for raw materials already committed by other items in the current order
        // -------------------------------
        private decimal GetAvailableStock(int productId)
        {
            // Build a dictionary of how much of each raw material is already consumed by the current order
            var committedMaterials = new System.Collections.Generic.Dictionary<int, decimal>();

            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["ProductID"].Value == null) continue;

                int orderedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);

                // Skip the product we're checking — its own qty is handled by GetQtyAlreadyInOrder in AddProduct
                if (orderedProductId == productId) continue;
                int orderedQty = Convert.ToInt32(row.Cells["QtyGrid"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string matQuery = "SELECT MaterialID, QuantityNeeded FROM ProductMaterials WHERE ProductID = @pid";
                    using (SqlCommand cmd = new SqlCommand(matQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@pid", orderedProductId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int matId = Convert.ToInt32(reader["MaterialID"]);
                                decimal needed = Convert.ToDecimal(reader["QuantityNeeded"]) * orderedQty;

                                if (committedMaterials.ContainsKey(matId))
                                    committedMaterials[matId] += needed;
                                else
                                    committedMaterials[matId] = needed;
                            }
                        }
                    }
                }
            }

            // Now compute effective available stock for the target product
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
SELECT pm.MaterialID, r.StockQty, pm.QuantityNeeded
FROM ProductMaterials pm
JOIN RawMaterials r ON pm.MaterialID = r.MaterialID
WHERE pm.ProductID = @ProductID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        decimal minStock = decimal.MaxValue;
                        bool hasMaterials = false;

                        while (reader.Read())
                        {
                            hasMaterials = true;
                            int matId = Convert.ToInt32(reader["MaterialID"]);
                            decimal stockQty = Convert.ToDecimal(reader["StockQty"]);
                            decimal qtyNeeded = Convert.ToDecimal(reader["QuantityNeeded"]);

                            // Subtract what's already committed by other order rows
                            decimal alreadyCommitted = committedMaterials.ContainsKey(matId)
                                ? committedMaterials[matId]
                                : 0;

                            decimal effectiveStock = stockQty - alreadyCommitted;
                            decimal canMake = effectiveStock / qtyNeeded;

                            if (canMake < minStock)
                                minStock = canMake;
                        }

                        return hasMaterials ? Math.Max(minStock, 0) : 0;
                    }
                }
            }
        }

        // -------------------------------
        // Get total qty already in order DGV for a product
        // -------------------------------
        private int GetQtyAlreadyInOrder(int productId)
        {
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.Cells["ProductID"].Value != null &&
                    Convert.ToInt32(row.Cells["ProductID"].Value) == productId)
                {
                    return Convert.ToInt32(row.Cells["QtyGrid"].Value);
                }
            }
            return 0;
        }

        // -------------------------------
        // Load products from DB
        // -------------------------------
        private void LoadProducts(string searchKeyword = "")
        {
            flowLayoutPanelAll.AutoScroll = true;
            flowLayoutPanelAll.WrapContents = true;
            flowLayoutPanelAll.FlowDirection = FlowDirection.LeftToRight;

            flowLayoutPanelAll.Controls.Clear();
            flowLayoutPanelChaofan.Controls.Clear();
            flowLayoutPanelSizzling.Controls.Clear();
            flowLayoutPanelCombo.Controls.Clear();
            flowLayoutPanelBeverages.Controls.Clear();
            flowLayoutPanelSilog.Controls.Clear();
            flowLayoutPanelFlavoredChicken.Controls.Clear();
            flowLayoutPanelAlaCarte.Controls.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
SELECT 
    p.ProductID, p.ProductName, p.Price, p.Category,
    ISNULL(
        (SELECT MIN(r.StockQty / pm.QuantityNeeded)
         FROM ProductMaterials pm
         JOIN RawMaterials r ON pm.MaterialID = r.MaterialID
         WHERE pm.ProductID = p.ProductID), 0
    ) AS AvailableStock
FROM Products p
WHERE p.Status = 'Active'";

                if (!string.IsNullOrEmpty(searchKeyword))
                    query += " AND p.ProductName LIKE @Search";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchKeyword))
                        cmd.Parameters.AddWithValue("@Search", "%" + searchKeyword + "%");

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int productId = Convert.ToInt32(reader["ProductID"]);
                        string productName = reader["ProductName"].ToString();
                        decimal price = Convert.ToDecimal(reader["Price"]);
                        string category = reader["Category"].ToString().Trim().ToLower();
                        decimal stock = Convert.ToDecimal(reader["AvailableStock"]);

                        Color baseColor;
                        switch (category)
                        {
                            case "chaofan": baseColor = Color.Orange; break;
                            case "sizzling": baseColor = Color.Firebrick; break;
                            case "combo": baseColor = Color.Goldenrod; break;
                            case "beverages": baseColor = Color.MediumPurple; break;
                            case "silog": baseColor = Color.SlateGray; break;
                            case "flavored chicken": baseColor = Color.DarkOliveGreen; break;
                            case "ala carte": baseColor = Color.CadetBlue; break;
                            default: baseColor = Color.SteelBlue; break;
                        }

                        Color btnColor;
                        bool isDisabled = false;
                        if (stock <= 0)
                        {
                            btnColor = Color.FromArgb(80, 80, 80);
                            isDisabled = true;
                        }
                        else if (stock <= 10)
                        {
                            btnColor = Color.FromArgb(200, 140, 0);
                        }
                        else
                        {
                            btnColor = baseColor;
                        }

                        string btnText = productName + "\n₱" + price.ToString("N2");
                        if (stock <= 0)
                            btnText += "\n[Out of Stock]";
                        else if (stock <= 10)
                            btnText += $"\n[Low: {Math.Floor(stock)}]";

                        Button btn = new Button
                        {
                            Text = btnText,
                            Tag = new { ProductID = productId, Price = price },
                            Width = 120,
                            Height = 80,
                            ForeColor = Color.White,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            FlatStyle = FlatStyle.Flat,
                            BackColor = btnColor,
                            Enabled = !isDisabled
                        };
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Click += ProductButton_Click;

                        switch (category)
                        {
                            case "chaofan": flowLayoutPanelChaofan.Controls.Add(btn); break;
                            case "sizzling": flowLayoutPanelSizzling.Controls.Add(btn); break;
                            case "combo": flowLayoutPanelCombo.Controls.Add(btn); break;
                            case "beverages": flowLayoutPanelBeverages.Controls.Add(btn); break;
                            case "silog": flowLayoutPanelSilog.Controls.Add(btn); break;
                            case "flavored chicken": flowLayoutPanelFlavoredChicken.Controls.Add(btn); break;
                            case "ala carte": flowLayoutPanelAlaCarte.Controls.Add(btn); break;
                        }

                        Button btnAll = new Button
                        {
                            Text = btn.Text,
                            Tag = btn.Tag,
                            Width = btn.Width,
                            Height = btn.Height,
                            ForeColor = btn.ForeColor,
                            Font = btn.Font,
                            FlatStyle = btn.FlatStyle,
                            BackColor = btn.BackColor,
                            Enabled = btn.Enabled
                        };
                        btnAll.FlatAppearance.BorderSize = 0;
                        btnAll.Click += ProductButton_Click;
                        flowLayoutPanelAll.Controls.Add(btnAll);
                    }
                }
            }

            CenterFlowLayout(flowLayoutPanelAll);
            CenterFlowLayout(flowLayoutPanelChaofan);
            CenterFlowLayout(flowLayoutPanelSizzling);
            CenterFlowLayout(flowLayoutPanelCombo);
            CenterFlowLayout(flowLayoutPanelBeverages);
            CenterFlowLayout(flowLayoutPanelSilog);
            CenterFlowLayout(flowLayoutPanelFlavoredChicken);
            CenterFlowLayout(flowLayoutPanelAlaCarte);

            dgvOrder.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            FlowLayoutPanel panel = sender as FlowLayoutPanel;
            if (panel != null) CenterFlowLayout(panel);
        }

        private void CenterFlowLayout(FlowLayoutPanel panel)
        {
            const int buttonWidth = 120;
            const int buttonMargin = 6;
            int cellWidth = buttonWidth + buttonMargin;

            int buttonsPerRow = Math.Max(1, panel.Width / cellWidth);
            int totalRowWidth = buttonsPerRow * cellWidth;
            int leftPadding = Math.Max((panel.Width - totalRowWidth) / 2, 0);

            panel.Padding = new Padding(leftPadding, 10, 0, 10);
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
            using (QuantityForm qtyForm = new QuantityForm())
            {
                if (qtyForm.ShowDialog() == DialogResult.OK)
                {
                    int quantity = qtyForm.SelectedQuantity;

                    // Get current available stock (accounts for shared raw materials in order)
                    decimal availableStock = GetAvailableStock(productId);

                    // Get qty already in the order for this product
                    int alreadyInOrder = GetQtyAlreadyInOrder(productId);

                    // Total qty if we allow this addition
                    int totalQty = alreadyInOrder + quantity;

                    // Validate against available stock
                    if (totalQty > Math.Floor(availableStock))
                    {
                        int canStillAdd = (int)Math.Floor(availableStock) - alreadyInOrder;
                        if (canStillAdd <= 0)
                        {
                            MessageBox.Show(
                                $"Cannot add more \"{itemName}\".\n\n" +
                                $"Available stock: {Math.Floor(availableStock)}\n" +
                                $"Already in order: {alreadyInOrder}",
                                "Insufficient Stock",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                        else
                        {
                            MessageBox.Show(
                                $"Not enough stock for \"{itemName}\".\n\n" +
                                $"Available stock: {Math.Floor(availableStock)}\n" +
                                $"Already in order: {alreadyInOrder}\n" +
                                $"You can add at most {canStillAdd} more.",
                                "Insufficient Stock",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                        return;
                    }

                    // If product already in order, update qty
                    foreach (DataGridViewRow row in dgvOrder.Rows)
                    {
                        if (row.Cells["ProductID"].Value != null &&
                            Convert.ToInt32(row.Cells["ProductID"].Value) == productId)
                        {
                            int currentQty = Convert.ToInt32(row.Cells["QtyGrid"].Value);
                            currentQty += quantity;
                            row.Cells["QtyGrid"].Value = currentQty;
                            row.Cells["PriceGrid"].Value = price;
                            row.Cells["TotalGrid"].Value = currentQty * price;
                            UpdateGrandTotal();
                            return;
                        }
                    }

                    // New row
                    int rowIndex = dgvOrder.Rows.Add();
                    DataGridViewRow newRow = dgvOrder.Rows[rowIndex];
                    newRow.Cells["ProductID"].Value = productId;
                    newRow.Cells["ItemGrid"].Value = itemName;
                    newRow.Cells["QtyGrid"].Value = quantity;
                    newRow.Cells["PriceGrid"].Value = price;
                    newRow.Cells["TotalGrid"].Value = quantity * price;
                    UpdateGrandTotal();
                }
            }
        }

        private void UpdateGrandTotal()
        {
            decimal grandTotal = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                grandTotal += Convert.ToDecimal(row.Cells["TotalGrid"].Value);
            }
            lblGrandTotal.Text = "₱" + grandTotal.ToString("N2");
        }

        private void user_Load(object sender, EventArgs e)
        {
            timer1.Start();
            dgvOrder.Columns.Clear();
            dgvOrder.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "ProductID"; colID.HeaderText = "ProductID"; colID.Visible = false;
            dgvOrder.Columns.Add(colID);

            DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
            colItem.Name = "Item"; colItem.HeaderText = "Item";
            colItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOrder.Columns.Add(colItem);

            DataGridViewTextBoxColumn colQty = new DataGridViewTextBoxColumn();
            colQty.Name = "Qty"; colQty.HeaderText = "Qty"; colQty.Width = 60;
            dgvOrder.Columns.Add(colQty);

            DataGridViewTextBoxColumn colPrice = new DataGridViewTextBoxColumn();
            colPrice.Name = "Price"; colPrice.HeaderText = "Price"; colPrice.Width = 80;
            dgvOrder.Columns.Add(colPrice);

            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total"; colTotal.HeaderText = "Total"; colTotal.Width = 80;
            dgvOrder.Columns.Add(colTotal);

            LoadProducts();
        }

        // -------------------------------
        // Clear Order button
        // -------------------------------
        private void button13_Click(object sender, EventArgs e)
        {
            dgvOrder.Rows.Clear();
            lblGrandTotal.Text = "₱0.00";
            txtPayment.Text = "";
            lblChange.Text = "₱0.00";
        }

        // -------------------------------
        // Calculate Change button
        // -------------------------------
        private void button15_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPayment.Text, out decimal payment))
            {
                decimal grandTotal = 0;
                foreach (DataGridViewRow row in dgvOrder.Rows)
                    grandTotal += Convert.ToDecimal(row.Cells["TotalGrid"].Value);

                if (payment < grandTotal)
                {
                    MessageBox.Show(
                        "Insufficient payment amount. Please collect the full amount before proceeding.",
                        "Payment Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblChange.Text = "₱0.00";
                    return;
                }

                lblChange.Text = "₱" + (payment - grandTotal).ToString("N2");
            }
            else
            {
                MessageBox.Show("Please enter a valid payment amount.", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------------
        // Process Order button
        // -------------------------------
        private void button14_Click(object sender, EventArgs e)
        {
            if (dgvOrder.Rows.Count == 0)
            {
                MessageBox.Show("No items in the order. Please add items before processing.",
                                "Empty Order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPayment.Text, out decimal payment))
            {
                MessageBox.Show("Please enter a valid payment amount.", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal grandTotal = 0;
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.IsNewRow) continue;
                grandTotal += Convert.ToDecimal(row.Cells["TotalGrid"].Value);
            }

            if (payment < grandTotal)
            {
                MessageBox.Show("Insufficient payment amount. Please collect the full amount before proceeding.",
                                "Payment Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Final stock check before processing — checks shared raw material conflicts too
            foreach (DataGridViewRow row in dgvOrder.Rows)
            {
                if (row.IsNewRow) continue;
                int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                int orderedQty = Convert.ToInt32(row.Cells["QtyGrid"].Value);
                string itemName = row.Cells["ItemGrid"].Value?.ToString();
                decimal available = GetAvailableStock(productId);

                if (orderedQty > Math.Floor(available))
                {
                    MessageBox.Show(
                        $"Stock changed for \"{itemName}\".\n\n" +
                        $"Ordered: {orderedQty}\n" +
                        $"Available: {Math.Floor(available)}\n\n" +
                        "Please update the order before proceeding.",
                        "Stock Unavailable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            decimal change = payment - grandTotal;

            DialogResult confirm = MessageBox.Show(
                $"Confirm Order?\n\n" +
                $"Total:      ₱{grandTotal:N2}\n" +
                $"Payment:  ₱{payment:N2}\n" +
                $"Change:   ₱{change:N2}\n\n" +
                $"Proceed with this transaction?",
                "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            int transactionId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string productSummary = "";
                foreach (DataGridViewRow row in dgvOrder.Rows)
                {
                    if (row.IsNewRow) continue;
                    productSummary += $"{row.Cells["ItemGrid"].Value} (x{row.Cells["QtyGrid"].Value}), ";
                }
                if (productSummary.EndsWith(", "))
                    productSummary = productSummary.Substring(0, productSummary.Length - 2);

                string remarks = string.IsNullOrWhiteSpace(txtRemarks.Text) ? "No remarks" : txtRemarks.Text;

                // 1️⃣ Insert into Transactions
                string transQuery = @"
INSERT INTO Transactions (DateTime, UserID, CashierName, ProductSummary, TotalAmount, Payment, Change, Remarks)
VALUES (@DateTime, @UserID, @CashierName, @ProductSummary, @TotalAmount, @Payment, @Change, @Remarks);
SELECT SCOPE_IDENTITY();";

                SqlCommand transCmd = new SqlCommand(transQuery, conn);
                transCmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                transCmd.Parameters.AddWithValue("@UserID", currentUserID);
                transCmd.Parameters.AddWithValue("@CashierName", cashierName);
                transCmd.Parameters.AddWithValue("@TotalAmount", grandTotal);
                transCmd.Parameters.AddWithValue("@Payment", payment);
                transCmd.Parameters.AddWithValue("@Change", change);
                transCmd.Parameters.AddWithValue("@Remarks", remarks);
                transCmd.Parameters.AddWithValue("@ProductSummary", productSummary);

                transactionId = Convert.ToInt32(transCmd.ExecuteScalar());

                // 2️⃣ Insert each product into TransactionDetails + deduct raw materials
                foreach (DataGridViewRow row in dgvOrder.Rows)
                {
                    if (row.IsNewRow) continue;

                    int productId = Convert.ToInt32(row.Cells["ProductID"].Value);
                    int qty = Convert.ToInt32(row.Cells["QtyGrid"].Value);
                    decimal price = Convert.ToDecimal(row.Cells["PriceGrid"].Value);
                    decimal total = Convert.ToDecimal(row.Cells["TotalGrid"].Value);

                    string detailQuery = @"
INSERT INTO TransactionDetails (TransactionID, ProductID, Qty, Price)
VALUES (@TransactionID, @ProductID, @Qty, @Price)";

                    using (SqlCommand detailCmd = new SqlCommand(detailQuery, conn))
                    {
                        detailCmd.Parameters.AddWithValue("@TransactionID", transactionId);
                        detailCmd.Parameters.AddWithValue("@ProductID", productId);
                        detailCmd.Parameters.AddWithValue("@Qty", qty);
                        detailCmd.Parameters.AddWithValue("@Price", price);
                        detailCmd.ExecuteNonQuery();
                    }

                    // Deduct raw materials
                    string deductQuery = @"
UPDATE r
SET r.StockQty = r.StockQty - (pm.QuantityNeeded * @qty)
FROM RawMaterials r
JOIN ProductMaterials pm ON r.MaterialID = pm.MaterialID
WHERE pm.ProductID = @pid";

                    using (SqlCommand deductCmd = new SqlCommand(deductQuery, conn))
                    {
                        deductCmd.Parameters.AddWithValue("@pid", productId);
                        deductCmd.Parameters.AddWithValue("@qty", qty);
                        deductCmd.ExecuteNonQuery();
                    }
                }
            }

            ReceiptForm receiptForm = new ReceiptForm(
                transactionId, cashierName, grandTotal, payment, change,
                txtRemarks.Text, dgvOrder);
            receiptForm.ShowDialog();

            // Reload products so button colors reflect updated stock
            dgvOrder.Rows.Clear();
            lblGrandTotal.Text = "₱0.00";
            txtPayment.Text = "";
            lblChange.Text = "₱0.00";
            txtRemarks.Text = "";
            LoadProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void panel12_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutPanelProducts_Paint(object sender, PaintEventArgs e) { }

        // -------------------------------
        // Remove Selected Order button
        // -------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvOrder.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string itemName = dgvOrder.SelectedRows[0].Cells["ItemGrid"].Value?.ToString() ?? "this item";

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to remove \"{itemName}\" from the order?",
                "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            for (int i = dgvOrder.SelectedRows.Count - 1; i >= 0; i--)
                dgvOrder.Rows.Remove(dgvOrder.SelectedRows[i]);

            UpdateGrandTotal();
        }

        // -------------------------------
        // Double-click row to edit qty
        // -------------------------------
        private void dgvOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvOrder.Rows[e.RowIndex];
            string itemName = row.Cells["ItemGrid"].Value?.ToString() ?? "item";
            int currentQty = Convert.ToInt32(row.Cells["QtyGrid"].Value);
            decimal price = Convert.ToDecimal(row.Cells["PriceGrid"].Value);
            int productId = Convert.ToInt32(row.Cells["ProductID"].Value);

            string input = ShowInputDialog(
                $"Enter new quantity for \"{itemName}\":",
                "Edit Quantity",
                currentQty.ToString()
            );

            if (string.IsNullOrWhiteSpace(input)) return;

            if (!int.TryParse(input, out int newQty) || newQty <= 0)
            {
                MessageBox.Show("Please enter a valid quantity greater than 0.", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate new qty against stock (accounts for shared raw materials)
            decimal availableStock = GetAvailableStock(productId);
            if (newQty > Math.Floor(availableStock))
            {
                MessageBox.Show(
                    $"Not enough stock for \"{itemName}\".\n\n" +
                    $"Available stock: {Math.Floor(availableStock)}\n" +
                    $"Requested: {newQty}",
                    "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            row.Cells["QtyGrid"].Value = newQty;
            row.Cells["TotalGrid"].Value = newQty * price;
            UpdateGrandTotal();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // -------------------------------
        // Custom input dialog helper
        // -------------------------------
        private string ShowInputDialog(string message, string title, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 340,
                Height = 160,
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lbl = new Label() { Left = 20, Top = 20, Width = 280, Text = message };
            TextBox txt = new TextBox() { Left = 20, Top = 50, Width = 280, Text = defaultValue };
            Button btnOK = new Button() { Text = "OK", Left = 140, Top = 85, Width = 75, DialogResult = DialogResult.OK };
            Button btnCnl = new Button() { Text = "Cancel", Left = 225, Top = 85, Width = 75, DialogResult = DialogResult.Cancel };

            prompt.Controls.AddRange(new Control[] { lbl, txt, btnOK, btnCnl });
            prompt.AcceptButton = btnOK;
            prompt.CancelButton = btnCnl;
            txt.SelectAll();
            txt.Focus();

            return prompt.ShowDialog() == DialogResult.OK ? txt.Text : "";
        }

        private void btnRecentTransactions_Click(object sender, EventArgs e)
        {
            using (var form = new RecentTransactionsForm())
                form.ShowDialog(this);
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPayment.Text, out decimal payment))
            {
                decimal grandTotal = 0;
                foreach (DataGridViewRow row in dgvOrder.Rows)
                    grandTotal += Convert.ToDecimal(row.Cells["TotalGrid"].Value);

                decimal change = payment - grandTotal;
                lblChange.Text = change >= 0 ? "₱" + change.ToString("N2") : "₱0.00";
            }
            else
            {
                lblChange.Text = "₱0.00";
            }
        }
    }
}