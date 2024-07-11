using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agri_Energy_Connect_Web_Application
{
    public partial class FarmerMainSc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");

        }

        protected void btnViewProductListing_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProducts.aspx");

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FarmerLoginSc.aspx");
        }
    }
}