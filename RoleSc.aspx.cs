using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agri_Energy_Connect_Web_Application
{
    public partial class RoleSc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFarmer_Click(object sender, EventArgs e)
        {
            Response.Redirect("FarmerLoginSc.aspx");

        }

        protected void btnEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginSc.aspx");
        }
    }
}