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
            if (!IsPostBack)
            {
                User currentUser = uh.GetCurrentUser();
                Session["CurrentUser"] = currentUser; // Store the current user in a session variable for easy access
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            User currentUser = uh.GetCurrentUser();
            if (currentUser != null)
            {
                uh.updatePremium(currentUser);
            }


            Response.Redirect("~/Views/Home.aspx");
        }
    }
}