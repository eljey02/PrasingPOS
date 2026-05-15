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

            // Populate Role ComboBox
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Cashier");

            // Populate Status ComboBox
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Active");
            cmbStatus.Items.Add("Inactive");
            cmbStatus.SelectedIndex = 0; // default Active
        }

       
        

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
              string.IsNullOrWhiteSpace(txtPassword.Text) ||
              cmbRole.SelectedItem == null ||
              cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // ✅ Correct column names based on your table
                string query = @"INSERT INTO Users (Username, PasswordHash, Role, Status)
                                 VALUES (@username, @passwordHash, @role, @status)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@passwordHash", txtPassword.Text); // later: hash this
                cmd.Parameters.AddWithValue("@role", cmbRole.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());

                conn.Open();
                cmd.ExecuteNonQuery();
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
    }
}
