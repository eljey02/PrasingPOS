using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace PrasingsPOS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true; // mask password
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                string connString = ConfigurationManager
                    .ConnectionStrings["PrasingPOS_DB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // ✅ Include Status check
                    string query = @"SELECT Role, Status 
                                     FROM Users 
                                     WHERE Username=@user 
                                       AND PasswordHash=@pass";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text); // ⚠️ later: hash this

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string status = reader["Status"].ToString();
                        string role = reader["Role"].ToString();

                        if (status != "Active")
                        {
                            MessageBox.Show("Account is inactive. Contact admin.",
                                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (role == "Admin")
                        {
                            AdminDashboard adminForm = new AdminDashboard();
                            adminForm.Show();
                            this.Hide();
                        }
                        else if (role == "Cashier")
                        {
                            POS cashierForm = new POS();
                            cashierForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Unknown role detected.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Toggle password visibility
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                button1.Text = "Hide";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                button1.Text = "Show";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // optional custom UI paint
        }
    }
}
