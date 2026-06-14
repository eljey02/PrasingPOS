using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class ReceiptForm : Form
    {
        private int _transactionId;
        private string _cashierName;
        private decimal _grandTotal, _payment, _change;
        private string _remarks;
        private DataGridView _dgv;

        // ── Colors ──────────────────────────────────────────────
        private readonly Color BG = Color.White;
        private readonly Color ACCENT = Color.FromArgb(192, 57, 43);   // #C0392B
        private readonly Color TEXT = Color.FromArgb(26, 26, 26);
        private readonly Color MUTED = Color.FromArgb(136, 136, 136);
        private readonly Color DIVIDER = Color.FromArgb(208, 208, 208);
        private readonly Color CHANGE_G = Color.FromArgb(39, 174, 96);
        private readonly Font MONO = new Font("Courier New", 9f);
        private readonly Font MONO_B = new Font("Courier New", 9f, FontStyle.Bold);
        private readonly Font TITLE = new Font("Segoe UI", 11f, FontStyle.Bold);
        private readonly Font SMALL = new Font("Courier New", 8f);

        public ReceiptForm(int txnId, string cashier, decimal total,
                           decimal payment, decimal change,
                           string remarks, DataGridView dgv)
        {
            _transactionId = txnId;
            _cashierName = cashier;
            _grandTotal = total;
            _payment = payment;
            _change = change;
            _remarks = string.IsNullOrWhiteSpace(remarks) ? "No remarks" : remarks;
            _dgv = dgv;

            BuildForm();
        }

        private void BuildForm()
        {
            this.Text = "Receipt — Transaction #" + _transactionId;
            this.Size = new Size(420, 720);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Font = MONO;

            // ── Outer scroll panel ───────────────────────────────
            Panel scroll = new Panel
            {
                AutoScroll = true,
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 16, 20, 70)
            };
            this.Controls.Add(scroll);

            // ── Receipt card ────────────────────────────────────
            Panel card = new Panel
            {
                Width = 360,
                AutoSize = true,
                BackColor = BG,
                Padding = new Padding(0)
            };
            card.Paint += (s, e) =>
            {
                // Red dashed top stripe
                using (var pen = new Pen(ACCENT, 5))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    e.Graphics.DrawLine(pen, 0, 2, card.Width, 2);
                }
            };
            scroll.Controls.Add(card);

            int y = 12;

            // ── Logo circle ─────────────────────────────────────
            Panel logo = new Panel
            {
                Width = 60,
                Height = 60,
                BackColor = ACCENT,
                Location = new Point((card.Width - 60) / 2, y)
            };
            logo.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(new SolidBrush(ACCENT),
                    new Rectangle(0, 0, logo.Width - 1, logo.Height - 1));
                using (var f = new Font("Segoe UI", 7f, FontStyle.Bold))
                    e.Graphics.DrawString("PRASING'S\nLECHON", f, Brushes.White,
                        new RectangleF(0, 14, logo.Width, logo.Height),
                        new StringFormat { Alignment = StringAlignment.Center });
            };
            card.Controls.Add(logo);
            y += 68;

            // ── Shop name ────────────────────────────────────────
            AddLabel(card, "PRASING'S LECHON SIZZLING", TITLE,
                     TEXT, 0, y, card.Width, 24, ContentAlignment.MiddleCenter);
            y += 22;
            AddLabel(card, "Official Receipt", SMALL,
                     MUTED, 0, y, card.Width, 18, ContentAlignment.MiddleCenter);
            y += 22;

            y = AddDivider(card, y, dashed: true);

            // ── Meta rows ────────────────────────────────────────
            y = AddMetaRow(card, "Transaction ID", "#TXN-" + _transactionId.ToString("D5"), y);
            y = AddMetaRow(card, "Date", DateTime.Now.ToString("MMMM dd, yyyy"), y);
            y = AddMetaRow(card, "Time", DateTime.Now.ToString("hh:mm tt"), y);
            y = AddMetaRow(card, "Cashier", _cashierName, y);
            y += 4;

            y = AddDivider(card, y, dashed: true);

            // ── Column headers ───────────────────────────────────
            Panel hdr = new Panel { Location = new Point(0, y), Width = card.Width, Height = 22, BackColor = Color.FromArgb(245, 245, 245) };
            AddLabel(hdr, "ITEM", SMALL, MUTED, 16, 0, 140, 22, ContentAlignment.MiddleLeft);
            AddLabel(hdr, "QTY", SMALL, MUTED, 156, 0, 30, 22, ContentAlignment.MiddleCenter);
            AddLabel(hdr, "PRICE", SMALL, MUTED, 190, 0, 70, 22, ContentAlignment.MiddleRight);
            AddLabel(hdr, "TOTAL", SMALL, MUTED, 270, 0, 70, 22, ContentAlignment.MiddleRight);
            card.Controls.Add(hdr);
            y += 22;

            // ── Line items ───────────────────────────────────────
            foreach (DataGridViewRow row in _dgv.Rows)
            {
                if (row.IsNewRow) continue;
                string item = row.Cells["ItemGrid"].Value?.ToString() ?? "";
                int qty = Convert.ToInt32(row.Cells["QtyGrid"].Value);
                decimal price = Convert.ToDecimal(row.Cells["PriceGrid"].Value);
                decimal tot = Convert.ToDecimal(row.Cells["TotalGrid"].Value);

                Panel r = new Panel { Location = new Point(0, y), Width = card.Width, Height = 28, BackColor = BG };
                r.Paint += (s, e) =>
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(240, 240, 240)),
                        16, 27, card.Width - 16, 27);
                AddLabel(r, item, MONO, TEXT, 16, 0, 140, 28, ContentAlignment.MiddleLeft);
                AddLabel(r, qty.ToString(), MONO, MUTED, 156, 0, 30, 28, ContentAlignment.MiddleCenter);
                AddLabel(r, "₱" + price.ToString("N2"), MONO, MUTED, 190, 0, 70, 28, ContentAlignment.MiddleRight);
                AddLabel(r, "₱" + tot.ToString("N2"), MONO_B, TEXT, 270, 0, 70, 28, ContentAlignment.MiddleRight);
                card.Controls.Add(r);
                y += 28;
            }

            y = AddDivider(card, y, dashed: true);

            // ── Totals ───────────────────────────────────────────
            y = AddTotalRow(card, "Subtotal", "₱" + _grandTotal.ToString("N2"), y, MUTED, TEXT);
            y = AddTotalRow(card, "Payment", "₱" + _payment.ToString("N2"), y, MUTED, TEXT);

            // Grand total bold line
            Panel gtLine = new Panel { Location = new Point(16, y), Width = card.Width - 32, Height = 1, BackColor = TEXT };
            card.Controls.Add(gtLine);
            y += 6;

            Panel gt = new Panel { Location = new Point(0, y), Width = card.Width, Height = 28, BackColor = BG };
            AddLabel(gt, "TOTAL", MONO_B, TEXT, 16, 0, 140, 28, ContentAlignment.MiddleLeft);
            AddLabel(gt, "₱" + _grandTotal.ToString("N2"), new Font("Courier New", 12f, FontStyle.Bold),
                     ACCENT, 0, 0, card.Width - 16, 28, ContentAlignment.MiddleRight);
            card.Controls.Add(gt);
            y += 30;

            y = AddTotalRow(card, "Change", "₱" + _change.ToString("N2"), y, MUTED, CHANGE_G);

            // ── Remarks ──────────────────────────────────────────
            if (_remarks != "No remarks")
            {
                y = AddDivider(card, y, dashed: true);
                AddLabel(card, "Remarks: " + _remarks, SMALL, MUTED, 16, y, card.Width - 32, 20, ContentAlignment.MiddleLeft);
                y += 22;
            }

            y = AddDivider(card, y, dashed: true);

            // ── Footer ───────────────────────────────────────────
            AddLabel(card, "Thank you for dining with us!", new Font("Segoe UI", 9f, FontStyle.Bold),
                     ACCENT, 0, y, card.Width, 22, ContentAlignment.MiddleCenter);
            y += 22;
            AddLabel(card, "Please come again · Prasing's Lechon Sizzling",
                     SMALL, MUTED, 0, y, card.Width, 18, ContentAlignment.MiddleCenter);
            y += 28;

            card.Height = y;

            // ── Bottom buttons ───────────────────────────────────
            Panel btnBar = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 56,
                BackColor = Color.FromArgb(250, 250, 250)
            };
            btnBar.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(DIVIDER), 0, 0, btnBar.Width, 0);

            Button btnClose = new Button
            {
                Text = "Close",
                Width = 120,
                Height = 36,
                Location = new Point(20, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = BG,
                ForeColor = TEXT,
                Font = new Font("Segoe UI", 9f)
            };
            btnClose.FlatAppearance.BorderColor = DIVIDER;
            btnClose.Click += (s, e) => this.Close();

            Button btnPrint = new Button
            {
                Text = "🖨 Print Receipt",
                Width = 180,
                Height = 36,
                Location = new Point(this.ClientSize.Width - 200, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = ACCENT,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold)
            };
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Click += BtnPrint_Click;

            btnBar.Controls.AddRange(new Control[] { btnClose, btnPrint });
            this.Controls.Add(btnBar);
        }

        // ── Helper: plain label ──────────────────────────────────
        private void AddLabel(Control parent, string text, Font font, Color color,
                               int x, int y, int w, int h, ContentAlignment align)
        {
            parent.Controls.Add(new Label
            {
                Text = text,
                Font = font,
                ForeColor = color,
                Location = new Point(x, y),
                Size = new Size(w, h),
                TextAlign = align
            });
        }

        // ── Helper: dashed / solid divider ──────────────────────
        private int AddDivider(Panel card, int y, bool dashed = false)
        {
            Panel d = new Panel { Location = new Point(16, y + 4), Width = card.Width - 32, Height = 1 };
            d.Paint += (s, e) =>
            {
                using (var pen = new Pen(DIVIDER))
                {
                    if (dashed) pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    e.Graphics.DrawLine(pen, 0, 0, d.Width, 0);
                }
            };
            card.Controls.Add(d);
            return y + 12;
        }

        // ── Helper: meta key/value row ───────────────────────────
        private int AddMetaRow(Panel card, string key, string val, int y)
        {
            Panel r = new Panel { Location = new Point(0, y), Width = card.Width, Height = 22, BackColor = BG };
            AddLabel(r, key, MONO, MUTED, 16, 0, 160, 22, ContentAlignment.MiddleLeft);
            AddLabel(r, val, MONO_B, TEXT, 0, 0, card.Width - 16, 22, ContentAlignment.MiddleRight);
            card.Controls.Add(r);
            return y + 22;
        }

        // ── Helper: total row ────────────────────────────────────
        private int AddTotalRow(Panel card, string label, string val,
                                int y, Color labelColor, Color valColor)
        {
            Panel r = new Panel { Location = new Point(0, y), Width = card.Width, Height = 24, BackColor = BG };
            AddLabel(r, label, MONO, labelColor, 16, 0, 160, 24, ContentAlignment.MiddleLeft);
            AddLabel(r, val, MONO_B, valColor, 0, 0, card.Width - 16, 24, ContentAlignment.MiddleRight);
            card.Controls.Add(r);
            return y + 24;
        }

        // ── Print ────────────────────────────────────────────────
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintReceipt;
            PrintPreviewDialog preview = new PrintPreviewDialog { Document = pd };
            preview.ShowDialog();
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = 40f;
            float yPos = 20f;
            float w = e.PageBounds.Width - 80f;

            Font fTitle = new Font("Courier New", 11f, FontStyle.Bold);
            Font fBody = new Font("Courier New", 9f);
            Font fBold = new Font("Courier New", 9f, FontStyle.Bold);
            Font fSmall = new Font("Courier New", 8f);
            Brush bText = Brushes.Black;
            Brush bMut = Brushes.Gray;
            Brush bAcc = new SolidBrush(ACCENT);

            Action<string, Font, Brush, StringAlignment> line = (txt, f, b, a) =>
            {
                StringFormat sf = new StringFormat { Alignment = a };
                g.DrawString(txt, f, b, new RectangleF(x, yPos, w, 20), sf);
                yPos += 18;
            };
            Action dash = () =>
            {
                g.DrawLine(Pens.LightGray, x, yPos + 4, x + w, yPos + 4);
                yPos += 12;
            };

            line("PRASING'S LECHON SIZZLING", fTitle, bAcc, StringAlignment.Center);
            line("Official Receipt", fSmall, bMut, StringAlignment.Center);
            yPos += 6; dash();

            line("Transaction: #TXN-" + _transactionId.ToString("D5"), fBody, bText, StringAlignment.Near);
            line("Date: " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt"), fBody, bText, StringAlignment.Near);
            line("Cashier: " + _cashierName, fBody, bText, StringAlignment.Near);
            yPos += 4; dash();

            foreach (DataGridViewRow row in _dgv.Rows)
            {
                if (row.IsNewRow) continue;
                string item = row.Cells["ItemGrid"].Value?.ToString() ?? "";
                int qty = Convert.ToInt32(row.Cells["QtyGrid"].Value);
                decimal price = Convert.ToDecimal(row.Cells["PriceGrid"].Value);
                decimal tot = Convert.ToDecimal(row.Cells["TotalGrid"].Value);

                string left = $"{item} x{qty}";
                string right = $"₱{price:N2}  ₱{tot:N2}";
                g.DrawString(left, fBody, bText, new RectangleF(x, yPos, w * 0.6f, 18));
                g.DrawString(right, fBody, bText, new RectangleF(x, yPos, w, 18),
                    new StringFormat { Alignment = StringAlignment.Far });
                yPos += 18;
            }

            dash();
            line($"Total:    ₱{_grandTotal:N2}", fBold, bText, StringAlignment.Far);
            line($"Payment: ₱{_payment:N2}", fBody, bMut, StringAlignment.Far);
            line($"Change:  ₱{_change:N2}", fBold, new SolidBrush(CHANGE_G), StringAlignment.Far);
            yPos += 8; dash();
            line("Thank you for dining with us!", fBold, bAcc, StringAlignment.Center);
        }
    }
}