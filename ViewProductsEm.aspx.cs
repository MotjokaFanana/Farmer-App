using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agri_Energy_Connect_Web_Application
{
    public partial class ViewProductsEm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewListings_Click(object sender, EventArgs e)
        {
            // Clear previous content
            productList.Controls.Clear();

            // Create a connection string
            string connectionString = "Data Source=NAITH-PC;Initial Catalog=AGRI2;Integrated Security=True;Encrypt=false;Application Name=EntityFramework";

            // Create SQL query to select all products with farmer information
            string query = @"SELECT p.Name AS ProductName, p.Category, p.ProductionDate, f.FirstName, f.LastName
                            FROM Product p
                            INNER JOIN Farmer f ON p.FarmerID = f.FarmerID";

            // Create a list to store the results
            List<string> results = new List<string>();

            // Create SqlConnection and SqlCommand objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Open the connection
                connection.Open();

                // Execute the query and read the results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Iterate through the results and add them to the list
                    while (reader.Read())
                    {
                        string productName = reader["ProductName"].ToString();
                        string category = reader["Category"].ToString();
                        string productionDate = reader["ProductionDate"].ToString();
                        string farmerName = $"{reader["FirstName"]} {reader["LastName"]}";

                        // Format the result with HTML
                        string formattedResult = $"<b>Name:</b> {productName}<br />Category: {category}<br />Production Date: {productionDate}<br />Farmer: {farmerName}";
                        results.Add(formattedResult);
                    }
                }
            }

            // Display the results in the product list section
            foreach (string result in results)
            {
                // Add a line break between each product
                Label breakLabel = new Label();
                breakLabel.Text = "<br />";
                productList.Controls.Add(breakLabel);

                // Add the product details
                Label productLabel = new Label();
                productLabel.Text = result + "<br />";
                productList.Controls.Add(productLabel);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeMainSc.aspx");
        }
    }
}