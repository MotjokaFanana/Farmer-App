using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Agri_Energy_Connect_Web_Application
{
    public partial class RegistrationSc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Create a connection string
            string connectionString = "Data Source=NAITH-PC;Initial Catalog=AGRI2;Integrated Security=True;Encrypt=false;Application Name=EntityFramework";

            // Create a SQL query to insert data into the Employee table
            string query = "INSERT INTO Employee (FirstName, LastName, Username, PasswordHash) VALUES (@FirstName, @LastName, @Username, @PasswordHash)";

            // Hash the password
            string hashedPassword = HashPassword(txtPassword.Text);

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command object with the SQL query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command to prevent SQL injection
                    command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    command.Parameters.AddWithValue("@Username", txtUsername.Text);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                    // Execute the command (insert data into the database)
                    command.ExecuteNonQuery();
                }
            }

            // Redirect to the login page
            Response.Redirect("LoginSc.aspx");
        }

        // Function to hash the password
        private string HashPassword(string password)
        {
            // Convert the password to bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Compute the hash of the password bytes
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convert the hash bytes to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginSc.aspx");
        }
    }
}
