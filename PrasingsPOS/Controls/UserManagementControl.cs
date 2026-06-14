using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PrasingsPOS
{
    public partial class UserManagementControl : UserControl
    {
        private string connectionString =
            @"Data Source=Lj\SQLEXPRESS;Initial Catalog=PrasingPOS_DB;Integrated Security=True";

        [DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        [DllImport("Gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        public UserManagementControl()
        {
            InitializeComponent();   
            SetupGridColumns();      
            LoadUsers();             
        }

       
        private void ApplyRoundRegion(Control control)
        {
            IntPtr hRgn = CreateRoundRectRgn(0, 0, control.Width, control.Height, 12, 12);
            control.Region = System.Drawing.Region.FromHrgn(hRgn);
            DeleteObject(hRgn);
        }

       
        // Add User Button
   
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addForm = new AddUserForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

       
        // Edit User Button
      
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["UserID"].Value);
            string username = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();
            string fullName = dgvUsers.CurrentRow.Cells["FullName"].Value.ToString();
            string role = dgvUsers.CurrentRow.Cells["Role"].Value.ToString();
            string status = dgvUsers.CurrentRow.Cells["Status"].Value.ToString();

            EditUserForm editForm = new EditUserForm(userId, username, fullName, role, status);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

      
        // Define Columns Manually

        private void SetupGridColumns()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "UserID";
            colId.HeaderText = "ID";
            colId.DataPropertyName = "UserID";
            colId.Width = 60;
            dgvUsers.Columns.Add(colId);

            DataGridViewTextBoxColumn colUser = new DataGridViewTextBoxColumn();
            colUser.Name = "Username";
            colUser.HeaderText = "Username";
            colUser.DataPropertyName = "Username";
            colUser.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUsers.Columns.Add(colUser);

            DataGridViewTextBoxColumn colFullName = new DataGridViewTextBoxColumn();
            colFullName.Name = "FullName";
            colFullName.HeaderText = "Full Name";
            colFullName.DataPropertyName = "FullName";
            colFullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUsers.Columns.Add(colFullName);

            DataGridViewTextBoxColumn colRole = new DataGridViewTextBoxColumn();
            colRole.Name = "Role";
            colRole.HeaderText = "Role";
            colRole.DataPropertyName = "Role";
            colRole.Width = 100;
            dgvUsers.Columns.Add(colRole);

            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.Name = "Status";
            colStatus.HeaderText = "Status";
            colStatus.DataPropertyName = "Status";
            colStatus.Width = 80;
            dgvUsers.Columns.Add(colStatus);

            dgvUsers.RowsDefaultCellStyle.BackColor = Color.White;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 220);
            dgvUsers.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgvUsers.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT UserID, Username, FullName, Role, Status FROM Users";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsers.DataSource = dt;
                    lblTotalUsers.Text = "Total Users: " + dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
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

                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user:\n" + ex.Message, "Database Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // FIX #5: Wrapped in try/catch so DB failures show a friendly error
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"SELECT UserID, Username, FullName, Role, Status 
                     FROM Users 
                     WHERE Username LIKE @search";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@search", "%" + searchText + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUsers.DataSource = dt;
                    lblTotalUsers.Text = "Total Users Found: " + dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching users:\n" + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserManagementControl_Load(object sender, EventArgs e)
        {
            // FIX #2: Use helper to apply rounded region and free GDI handle immediately
            ApplyRoundRegion(panel2);
            ApplyRoundRegion(btnAddUser);
            ApplyRoundRegion(btnEditUser);
            ApplyRoundRegion(btnDeleteUser);
        }
    }
}