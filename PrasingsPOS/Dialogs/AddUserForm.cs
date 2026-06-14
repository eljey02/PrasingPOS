using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class AddUserForm : Form
    {
        private string connectionString =
            @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        public AddUserForm()
        {
            InitializeComponent();

            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Cashier");

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");
            cmbStatus.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                cmbRole.SelectedItem == null ||
                cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Users (Username, PasswordHash, Role, Status, FullName)
                         VALUES (@username, @passwordHash, @role, @status, @fullName)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@passwordHash", txtPassword.Text);
                cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@fullName", txtFullName.Text);

                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show(
                        $"Username \"{txtUsername.Text}\" already exists.\nPlease choose a different username.",
                        "Duplicate Username",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            MessageBox.Show("User added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
        }
    }
}