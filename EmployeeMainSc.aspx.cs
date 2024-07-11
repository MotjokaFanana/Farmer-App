using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agri_Energy_Connect_Web_Application
{
    public partial class EmployeeMainSc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddFarmer_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFarmerSc.aspx");


        }

        protected void btnFilterProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilterProductSc.aspx");


        }

        protected void btnViewProductList_Click(object sender, EventArgs e)
        {



            Response.Redirect("ViewProductsEm.aspx");



        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("LoginSc.aspx");
        }
    }
}
