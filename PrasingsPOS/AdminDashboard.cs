using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }
        private void LoadModule(UserControl module)
        {
            panelMain.Controls.Clear();       // remove previous module
            module.Dock = DockStyle.Fill;     // make it fill the panel
            panelMain.Controls.Add(module);   // add the new module
        }

        private void user_Load(object sender, EventArgs e)
        {
            timer1.Start();

        
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
                // Show the login form again
                Login loginForm = new Login();
                loginForm.Show();

                // Hide the current dashboard
                this.Hide();
            }
            else
            {
                // Do nothing, stay on dashboard
            }

            // Hide the current dashboard
            this.Hide();

           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadModule(new UserManagementControl());

            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.FlatAppearance.BorderSize = 0; // removes border

            btnUser.FlatStyle = FlatStyle.Flat;
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            btnUser.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadModule(new DashboardControl());
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.FlatAppearance.BorderSize = 0; // removes border

            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            btnDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadModule(new ProductsControl());
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.FlatAppearance.BorderSize = 0; // removes border

            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            btnProducts.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadModule(new ReportsControl());

            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.FlatAppearance.BorderSize = 0; // removes border

            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            btnReports.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadModule(new InventoryControl());

            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.FlatAppearance.BorderSize = 0; // removes border

            btnInventory.FlatStyle = FlatStyle.Flat;
            btnInventory.FlatAppearance.BorderSize = 0;
            btnInventory.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 48); // highlight color
            btnInventory.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28); // pressed color
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void productsControl1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
