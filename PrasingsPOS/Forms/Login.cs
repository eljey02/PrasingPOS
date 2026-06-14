using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class Login : Form
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
    int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
    int nWidthEllipse, int nHeightEllipse);
        public Login()

        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            this.AcceptButton = btnLogin;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=Lj\\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True"))
                {
                    conn.Open();

                    string query = "SELECT UserID, Role, FullName, PasswordHash FROM Users WHERE Username=@user AND Status='Active'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedPassword = reader["PasswordHash"].ToString();

                        if (string.Equals(txtPassword.Text, storedPassword, StringComparison.Ordinal))
                        {
                            int userIdFromDB = Convert.ToInt32(reader["UserID"]);
                            string role = reader["Role"].ToString();
                            string fullName = reader["FullName"].ToString();

                            reader.Close();

                            if (role == "Cashier")
                            {
                                POS cashierForm = new POS(fullName, userIdFromDB);
                                cashierForm.Show();
                                this.Hide();
                            }
                            else if (role == "Admin")
                            {
                                AdminDashboard adminForm = new AdminDashboard(fullName);
                                adminForm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                button1.Text = "";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                button1.Text = "";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnLogin.Region = System.Drawing.Region.FromHrgn(
        CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 12, 12)
        );
            txtUsername.Region = System.Drawing.Region.FromHrgn(
        CreateRoundRectRgn(0, 0, txtUsername.Width, txtUsername.Height, 12, 12)
        );
            txtPassword.Region = System.Drawing.Region.FromHrgn(
        CreateRoundRectRgn(0, 0, txtPassword.Width, txtPassword.Height, 12, 12)
        );
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "Are you sure you want to exit?",
       "Confirm Exit",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }
    }
}