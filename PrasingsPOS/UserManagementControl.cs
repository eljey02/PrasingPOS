using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class UserManagementControl : UserControl
    {
        private string connectionString =
            @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        public UserManagementControl()
        {
            InitializeComponent();   // must be first
            SetupGridColumns();      // define columns manually
            LoadUsers();             // safe to call after controls exist
        }

        // -------------------------------
        // Add User Button
        // -------------------------------
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addForm = new AddUserForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers(); // refresh grid after adding
            }
        }

        // -------------------------------
        // Edit User Button
        // -------------------------------
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            string username = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
            string role = dgvUsers.CurrentRow.Cells["Role"].Value.ToString();
            string status = dgvUsers.CurrentRow.Cells["Status"].Value.ToString();

            EditUserForm editForm = new EditUserForm(userId, username, role, status);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers(); // refresh grid after editing
            }
        }

        // -------------------------------
        // Define Columns Manually
        // -------------------------------
        private void SetupGridColumns()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            // UserID column
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "UserID";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "UserID";
            colId.Width = 60; // fixed width
            dgvUsers.Columns.Add(colId);

            // Username column (fills remaining space)
            DataGridViewTextBoxColumn colUser = new DataGridViewTextBoxColumn();
            colUser.Name = "Username";
            colUser.HeaderText = "Username";
            colUser.DataPropertyName = "Username";
            colUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // ✅ fill mode
            dgvUsers.Columns.Add(colUser);

            // Role column
            DataGridViewTextBoxColumn colRole = new DataGridViewTextBoxColumn();
            colRole.Name = "Role";
            colRole.HeaderText = "Role";
            colRole.DataPropertyName = "Role";
            colRole.Width = 100; // fixed width
            dgvUsers.Columns.Add(colRole);

            // Status column
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "Status";
            colStatus.HeaderText = "Status";
            colStatus.DataPropertyName = "Status";
            colStatus.Width = 80; // fixed width
            dgvUsers.Columns.Add(colStatus);
        }

        // -------------------------------
        // Load Users Method
        // -------------------------------
        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, Username, Role, Status FROM Users";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvUsers.DataSource = dt; // bind to manual columns

                // ✅ Update total users label
                lblTotalUsers.Text = "Total Users: " + dt.Rows.Count.ToString();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this user?",
                                                   "Confirm Delete",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Users WHERE UserID = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", userId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("User deleted successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadUsers(); // refresh grid and total users count
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT UserID, Username, Role, Status 
                         FROM Users 
                         WHERE Username LIKE @search";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + searchText + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvUsers.DataSource = dt;

                // ✅ Update total users label based on search resultsasdasdasdasdasd
                lblTotalUsers.Text = "Total Users Found: " + dt.Rows.Count.ToString();
            }
        }
    }
}
