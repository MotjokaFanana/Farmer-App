using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Agri_Energy_Connect_Web_Application
{
    public partial class AddProduct : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Retrieve the farmer ID from the session
            int farmerID = (int)Session["FarmerID"];

            string productName = txtProductName.Text;
            string category = txtCategory.Text;
            DateTime productionDate = DateTime.Parse(txtProductionDate.Text);

            // Create a connection string
            string connectionString = "Data Source=NAITH-PC;Initial Catalog=AGRI2;Integrated Security=True;Encrypt=false;Application Name=EntityFramework";

            // Create an SQL query to insert the product details along with the farmer ID
            string query = "INSERT INTO Product (Name, Category, ProductionDate, FarmerID) VALUES (@Name, @Category, @ProductionDate, @FarmerID)";

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command object with the SQL query and connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command to prevent SQL injection
                    command.Parameters.AddWithValue("@Name", productName);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@ProductionDate", productionDate);
                    command.Parameters.AddWithValue("@FarmerID", farmerID);

                    // Execute the command to insert the product details into the database
                    command.ExecuteNonQuery();
                }
            }

            // Redirect to a success page or display a success message
            Response.Redirect("FarmerMainSc.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FarmerMainSc.aspx");
        }
    }
}
