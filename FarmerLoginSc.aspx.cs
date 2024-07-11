using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;

namespace Agri_Energy_Connect_Web_Application
{
    public partial class FarmerLoginSc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Get the username and password from the textboxes
            string username = txtUsername.Text;
            string password = txtPassword.Text; // Raw user-entered password

            // Hash the user-entered password
            string hashedPassword = HashPassword(password);

            // Create a connection string
            string connectionString = "Data Source=NAITH-PC;Initial Catalog=AGRI2;Integrated Security=True;Encrypt=false;Application Name=EntityFramework";

            // Create a SQL query to select the farmer with the provided username and hashed password
            string query = "SELECT FarmerID FROM Farmer WHERE Username = @Username AND PasswordHash = @PasswordHash";

            // Create a variable to store the farmer ID if found
            int farmerID = -1;

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

                    // Execute the command and get the result (farmer ID)
                    object result = command.ExecuteScalar();

                    // Check if the result is not null
                    if (result != null)
                    {
                        // If found, store the farmer ID
                        farmerID = Convert.ToInt32(result);
                    }
                }
            }

            // Check if farmerID is not -1 (indicating a valid farmer)
            if (farmerID != -1)
            {
                // Farmer is valid, store the farmer ID in the session
                Session["FarmerID"] = farmerID;

                // Redirect to the dashboard or another page
                Response.Redirect("FarmerMainSc.aspx");
            }
            else
            {
                // Farmer not found or invalid credentials, show an error message
                // For example, you can display a label with an error message
                lblErrorMessage.Text = "Invalid username or password";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Redirect to the registration page
            Response.Redirect("RegistrationPage.aspx");
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("RoleSc.aspx");
        }
    }
}
