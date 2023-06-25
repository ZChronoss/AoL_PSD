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
            if(Session["User"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }

            User curUser = (User)Session["User"];
            if(curUser.IsPremium == 1)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            if(paymentMethod.SelectedValue != "")
            {
                User curUser = (User)Session["User"];
                curUser = uh.EditPremium(curUser.Id);
                Session["User"] = curUser;
                ErrorLabel.Visible = false;

                Response.Redirect("~/Views/Home.aspx");
            }
            else
            {
                ErrorLabel.Visible = true;
            }
        }
    }
}