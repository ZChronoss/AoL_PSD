using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AoL_PSD.Handler;
using AoL_PSD.Model;

namespace AoL_PSD.Views
{
    public partial class Premium : System.Web.UI.Page
    {
        UserHandler uh = new UserHandler();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            User currentUser = (User)Session["User"];
            if (currentUser != null)
            {
                uh.updatePremium(currentUser);
            }


            Response.Redirect("~/Views/Home.aspx");
        }
    }
}