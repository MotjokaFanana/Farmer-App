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
    public partial class AddFarmerSc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddFarmer_Click(object sender, EventArgs e)
        {
            // Retrieve values from textboxes
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text; // Hash the password before storing it in the database
            string email = txtEmail.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string address = txtAddress.Text;

            // Hash the password
            string passwordHash = HashPassword(password);

            // Create a connection string
            string connectionString = "Data Source=NAITH-PC;Initial Catalog=AGRI2;Integrated Security=True;Encrypt=false;Application Name=EntityFramework";

            // Create SQL query to insert the farmer details into the database
            string query = @"INSERT INTO Farmer (FirstName, LastName, Username, PasswordHash, Email, PhoneNumber, Address)
                     VALUES (@FirstName, @LastName, @Username, @PasswordHash, @Email, @PhoneNumber, @Address);";

            // Create SqlConnection and SqlCommand objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameters to the command
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@Address", address);

                // Open the connection
                connection.Open();

                // Execute the query
                int rowsAffected = command.ExecuteNonQuery();

                // Check if the insert was successful
                if (rowsAffected > 0)
                {
                    // Insert successful, optionally redirect the user to another page
                    Response.Redirect("EmployeeMainSc.aspx");
                }
                else
                {
                    // Insert failed, handle the error (e.g., display an error message)
                    // You can use a label to display the error message

                    lblErrorMessage.Text = "Failed to add the farmer. Please try again.";
                    lblErrorMessage.Visible = true; // Make the label visible


                }
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {


            Response.Redirect("EmployeeMainSc.aspx");


        }


            // HashPassword method to hash the password before storing it in the database
            private string HashPassword(string password)
        {
            // Implement your password hashing logic here
            // For example, using SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

    }
}