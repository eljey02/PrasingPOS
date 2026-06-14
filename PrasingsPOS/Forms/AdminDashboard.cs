using System;
using System.Drawing;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard(string fullName)
        {
            InitializeComponent();
            label1.Text = "Hello, " + fullName + "!";
        }

        private void LoadModule(UserControl module)
        {
            panelMain.Controls.Clear();
            module.Dock = DockStyle.Fill;
            panelMain.Controls.Add(module);
        }

       
        private void StyleNavButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
        }

        private void user_Load(object sender, EventArgs e)
        {
            timer1.Start();

            DashboardControl dash = new DashboardControl();
            dash.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(dash);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void button6_Click(object sender, EventArgs e)
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
               
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadModule(new UserManagementControl());
            StyleNavButton(btnUser);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadModule(new DashboardControl());
            StyleNavButton(btnDashboard);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadModule(new ProductsControl());
            StyleNavButton(btnProducts);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadModule(new ReportsControl());
            StyleNavButton(btnReports);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadModule(new InventoryControl());
            StyleNavButton(btnInventory);
        }

     
        private void button2_Click_1(object sender, EventArgs e)
        {
            LoadModule(new PurchaseControl1());
            StyleNavButton(btnPurchase);
        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadModule(new SalesControl());
            StyleNavButton(btnSales);
        }

        
    }
}