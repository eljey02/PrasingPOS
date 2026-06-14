using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class EditUserForm : Form
    {
        private int userId;
        private string connectionString =
            @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        public EditUserForm(int id, string username, string fullName, string role, string status)
        {
            InitializeComponent();
            userId = id;

            txtUsername.Text = username;
            txtUsername.ReadOnly = true;

            txtFullName.Text = fullName; // ✅ populate full name

            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Cashier");
            cmbRole.SelectedItem = role;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");
            cmbStatus.SelectedItem = status;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter a full name.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Users 
                                 SET Role = @role, Status = @status, FullName = @fullName"
                                 + (string.IsNullOrWhiteSpace(txtPassword.Text) ? "" : ", PasswordHash = @password") +
                                 " WHERE UserID = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@fullName", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@id", userId);

                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("User updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
        }
    }
}