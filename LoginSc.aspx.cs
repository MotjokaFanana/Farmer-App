using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agri_Energy_Connect_Web_Application
{
    public partial class LoginSc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Create a connection string
            string connectionString = "Data Source=NAITH-PC;Initial Catalog=AGRI2;Integrated Security=True;Encrypt=false;Application Name=EntityFramework";

            // Get the username and password from the textboxes
            string username = txtUsername.Text;
            string password = txtPassword.Text; // Raw user-entered password

            // Hash the user-entered password
            string hashedPassword = HashPassword(password);

            // Create a SQL query to select the employee with the provided username and hashed password
            string query = "SELECT EmployeeID FROM Employee WHERE Username = @Username AND PasswordHash = @PasswordHash";

            // Create a variable to store the employee ID if found
            int employeeID = -1;

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command object with the SQL query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword); // Use the hashed password for comparison

                    // Execute the command and get the result (employee ID)
                    object result = command.ExecuteScalar();

                    // Check if the result is not null
                    if (result != null)
                    {
                        // If found, store the employee ID
                        employeeID = Convert.ToInt32(result);
                    }
                }
            }

            // Check if employeeID is not -1 (indicating a valid employee)
            if (employeeID != -1)
            {
                // Employee is valid, redirect to the dashboard or another page
                Response.Redirect("EmployeeMainSc.aspx");
            }
            else
            {
                // Employee not found or invalid credentials, show an error message
                // For example, you can display a label with an error message
                lblErrorMessage.Text = "Invalid username or password";
            }
        }


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


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationSc.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoleSc.aspx");
        }
    }
}