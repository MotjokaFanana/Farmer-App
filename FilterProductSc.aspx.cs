using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Agri_Energy_Connect_Web_Application
{
    public partial class FilterProductSc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFilterProducts_Click(object sender, EventArgs e)
        {
            // Retrieve the category filter text from the textbox
            string categoryFilter = txtFilterCategory.Text;

            // Create a connection string
            string connectionString = "Data Source=NAITH-PC;Initial Catalog=AGRI2;Integrated Security=True;Encrypt=false;Application Name=EntityFramework";

            // Create SQL query to select records based on the category and include farmer information
            string query = @"SELECT p.Name AS ProductName, p.ProductionDate, f.FirstName, f.LastName
                     FROM Product p
                     INNER JOIN Farmer f ON p.FarmerID = f.FarmerID
                     WHERE p.Category = @Category";

            // Create a list to store the results
            List<string> results = new List<string>();

            // Create SqlConnection and SqlCommand objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Add parameter for the category filter
                command.Parameters.AddWithValue("@Category", categoryFilter);

                // Open the connection
                connection.Open();

                // Execute the query and read the results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Iterate through the results and add them to the list
                    while (reader.Read())
                    {
                        string productName = reader["ProductName"].ToString();
                        string productionDate = reader["ProductionDate"].ToString();
                        string farmerName = $"{reader["FirstName"]} {reader["LastName"]}";

                        // Format the result with HTML
                        string formattedResult = $"<b>Name:</b> {productName}<br />Production Date: {productionDate}<br />Added by: {farmerName}";
                        results.Add(formattedResult);
                    }
                }
            }

            // Display the results or error message in the text section
            if (results.Count > 0)
            {
                textSection.Text = string.Join("<br /><br />", results);
            }
            else
            {
                textSection.Text = "No products found for the specified category.";
            }
        }


        protected void btnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeMainSc.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeMainSc.aspx");
        }
    }
}
