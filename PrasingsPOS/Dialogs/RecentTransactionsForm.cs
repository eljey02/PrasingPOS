using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class RecentTransactionsForm : Form
    {
        private const string ConnStr = "Data Source=Lj\\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        // Controls
        private Panel topPanel, detailPanel;
        private Label lblTitle, lblDetailTitle;
        private NumericUpDown nudLimit;
        private Button btnRefresh, btnClose;
        private DataGridView dgvTransactions, dgvItems;
        private Label lblTotal, lblPayment, lblChange, lblRemarks, lblCashier, lblDateTime, lblTxnID;
        private SplitContainer splitMain;

        public RecentTransactionsForm()
        {
            BuildUI();
            this.Load += (s, e) =>
            {
                splitMain.Panel1MinSize = 280;
                splitMain.Panel2MinSize = 300;
                splitMain.SplitterDistance = 390;
                splitMain.Panel1.BackColor = Color.FromArgb(150, 4, 15);  // thin visual separator
            };
            LoadTransactions();
        }

        // ─── UI Builder ───────────────────────────────────────────────
        private void BuildUI()
        {
            Text = "Recent Transactions — Prasing's Lechon Sizzling";
            Size = new Size(1050, 660);
            MinimumSize = new Size(850, 520);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 9f);

            // ── Top bar ──
            topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 52,
                BackColor = Color.FromArgb(26, 26, 26),
                Padding = new Padding(14, 0, 14, 0)
            };

            lblTitle = new Label
            {
                Text = "🧾  Recent Transactions",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(14, 13)
            };

            var lblShow = new Label
            {
                Text = "Show last:",
                ForeColor = Color.Silver,
                AutoSize = true,
                Location = new Point(660, 17)
            };

            nudLimit = new NumericUpDown
            {
                Minimum = 1,
                Maximum = 100,
                Value = 10,
                Width = 58,
                Location = new Point(738, 14),
                Font = new Font("Segoe UI", 9f)
            };

            btnRefresh = MakeButton("↺  Refresh", Color.FromArgb(192, 57, 43), new Point(806, 12), new Size(88, 28));
            btnRefresh.Click += (s, e) => LoadTransactions();

            btnClose = MakeButton("✕", Color.FromArgb(180, 48, 48), new Point(904, 12), new Size(30, 28));
            btnClose.Click += (s, e) => Close();

            topPanel.Controls.AddRange(new Control[] { lblTitle, lblShow, nudLimit, btnRefresh, btnClose });

            // ── Split: left = master list, right = detail ──
            splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None
            };

            // ── Left panel — transaction list ──
            var leftHeader = new Label
            {
                Text = "  Transactions",
                Dock = DockStyle.Top,
                Height = 32,
                BackColor = Color.FromArgb(150, 4, 15),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft
            };

            dgvTransactions = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                GridColor = Color.FromArgb(220, 220, 220),
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 9f),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            };
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 57, 43);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(150, 4, 15);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.SelectionChanged += DgvTransactions_SelectionChanged;

            splitMain.Panel1.Controls.Add(dgvTransactions);
            splitMain.Panel1.Controls.Add(leftHeader);

            // ── Right panel — detail view ──
            detailPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(12)
            };

            lblDetailTitle = new Label
            {
                Text = "Select a transaction to view details",
                Dock = DockStyle.Top,
                Height = 32,
                BackColor = Color.FromArgb(150, 4, 15), 
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 0, 0, 0)
            };

            // Meta info row
            var metaPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 90,
                ColumnCount = 2,
                RowCount = 3,
                BackColor = Color.FromArgb(253, 245, 245),
                Padding = new Padding(10, 6, 10, 6),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };
            metaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            metaPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            lblTxnID = MetaLabel("Transaction ID: —");
            lblDateTime = MetaLabel("Date & Time: —");
            lblCashier = MetaLabel("Cashier: —");
            lblRemarks = MetaLabel("Remarks: —");

            metaPanel.Controls.Add(lblTxnID, 0, 0);
            metaPanel.Controls.Add(lblDateTime, 1, 0);
            metaPanel.Controls.Add(lblCashier, 0, 1);
            metaPanel.Controls.Add(lblRemarks, 1, 1);

            // Items grid
            dgvItems = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                GridColor = Color.FromArgb(220, 220, 220),
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 9f),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(150, 4, 15);  
            dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvItems.EnableHeadersVisualStyles = false;

            // Summary footer
            var summaryPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 72,
                BackColor = Color.FromArgb(150, 4, 15), 
                Padding = new Padding(12, 8, 12, 8)
            };

            lblTotal = SummaryLabel("Grand Total:  ₱0.00", new Point(12, 8));
            lblPayment = SummaryLabel("Payment:       ₱0.00", new Point(12, 32));
            lblChange = SummaryLabel("Change:          ₱0.00", new Point(300, 8));
            lblChange.ForeColor = Color.FromArgb(243, 156, 18);
            summaryPanel.Controls.AddRange(new Control[] { lblTotal, lblPayment, lblChange });

            // Assemble right panel (order matters for Dock)
            detailPanel.Controls.Add(dgvItems);       // Fill — must be added before Bottom/Top docks
            detailPanel.Controls.Add(summaryPanel);   // Bottom
            detailPanel.Controls.Add(metaPanel);      // Top (added after Fill so it sits on top)
            detailPanel.Controls.Add(lblDetailTitle); // Top

            splitMain.Panel2.Controls.Add(detailPanel);

            Controls.Add(splitMain);
            Controls.Add(topPanel);
        }

        // ─── Load master list ─────────────────────────────────────────
        private void LoadTransactions()
        {
            dgvTransactions.Columns.Clear();
            dgvTransactions.Rows.Clear();

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "TxnID", HeaderText = "ID", Width = 50 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "DateTime", HeaderText = "Date/Time", FillWeight = 120 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cashier", HeaderText = "Cashier", FillWeight = 100 });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total", Width = 80 });

            int limit = (int)nudLimit.Value;

            try
            {
                using (var conn = new SqlConnection(ConnStr))
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP (@limit)
                            TransactionID, DateTime, CashierName, TotalAmount
                        FROM Transactions
                        ORDER BY DateTime DESC";

                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@limit", limit);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = dgvTransactions.Rows[dgvTransactions.Rows.Add()];
                                row.Cells["TxnID"].Value = reader["TransactionID"];
                                row.Cells["DateTime"].Value = Convert.ToDateTime(reader["DateTime"]).ToString("MM/dd/yy hh:mm tt");
                                row.Cells["Cashier"].Value = reader["CashierName"];
                                row.Cells["Total"].Value = "₱" + Convert.ToDecimal(reader["TotalAmount"]).ToString("N2");
                            }
                        }
                    }
                }

                // Auto-select first row
                if (dgvTransactions.Rows.Count > 0)
                    dgvTransactions.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions:\n" + ex.Message, "DB Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Load detail when a row is selected ──────────────────────
        private void DgvTransactions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0) return;

            var selectedRow = dgvTransactions.SelectedRows[0];
            if (selectedRow.Cells["TxnID"].Value == null) return;

            int txnId = Convert.ToInt32(selectedRow.Cells["TxnID"].Value);
            LoadTransactionDetail(txnId);
        }

        private void LoadTransactionDetail(int transactionId)
        {
            try
            {
                using (var conn = new SqlConnection(ConnStr))
                {
                    conn.Open();

                    // ── Header info ──
                    string headerQuery = @"
                        SELECT TransactionID, DateTime, CashierName,
                               TotalAmount, Payment, Change, Remarks
                        FROM Transactions
                        WHERE TransactionID = @id";

                    using (var cmd = new SqlCommand(headerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", transactionId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblDetailTitle.Text = $"  Transaction #{transactionId}";
                                lblTxnID.Text = $"Transaction ID:  {transactionId}";
                                lblDateTime.Text = $"Date & Time:  {Convert.ToDateTime(reader["DateTime"]):MM/dd/yyyy hh:mm tt}";
                                lblCashier.Text = $"Cashier:  {reader["CashierName"]}";
                                lblRemarks.Text = $"Remarks:  {reader["Remarks"]}";

                                decimal total = Convert.ToDecimal(reader["TotalAmount"]);
                                decimal payment = Convert.ToDecimal(reader["Payment"]);
                                decimal change = Convert.ToDecimal(reader["Change"]);

                                lblTotal.Text = $"Grand Total:   ₱{total:N2}";
                                lblPayment.Text = $"Payment:        ₱{payment:N2}";
                                lblChange.Text = $"Change:           ₱{change:N2}";
                            }
                        }
                    }

                    // ── Items ──
                    dgvItems.Columns.Clear();
                    dgvItems.Rows.Clear();

                    dgvItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Item", HeaderText = "Item", FillWeight = 160 });
                    dgvItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qty", HeaderText = "Qty", Width = 55 });
                    dgvItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Unit Price", Width = 90 });
                    dgvItems.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", Width = 90 });

                    string detailQuery = @"
                        SELECT p.ProductName, td.Qty, td.Price,
                               (td.Qty * td.Price) AS Subtotal
                        FROM TransactionDetails td
                        JOIN Products p ON td.ProductID = p.ProductID
                        WHERE td.TransactionID = @id";

                    using (var cmd = new SqlCommand(detailQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", transactionId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var row = dgvItems.Rows[dgvItems.Rows.Add()];
                                row.Cells["Item"].Value = reader["ProductName"];
                                row.Cells["Qty"].Value = reader["Qty"];
                                row.Cells["Price"].Value = "₱" + Convert.ToDecimal(reader["Price"]).ToString("N2");
                                row.Cells["Subtotal"].Value = "₱" + Convert.ToDecimal(reader["Subtotal"]).ToString("N2");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading detail:\n" + ex.Message, "DB Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Helpers ──────────────────────────────────────────────────
        private Button MakeButton(string text, Color bg, Point loc, Size size)
        {
            var btn = new Button
            {
                Text = text,
                BackColor = bg,
                ForeColor = Color.White,
                Location = loc,
                Size = size,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        private Label MetaLabel(string text) => new Label
        {
            Text = text,
            AutoSize = false,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 9f),
            ForeColor = Color.FromArgb(26, 26, 26),
            TextAlign = ContentAlignment.MiddleLeft
        };

        private Label SummaryLabel(string text, Point loc) => new Label
        {
            Text = text,
            Location = loc,
            AutoSize = true,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 10f, FontStyle.Bold)
        };
    }
}