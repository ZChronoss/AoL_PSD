using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AoL_PSD.Views
{
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home.aspx");
        }

        protected void AddSong_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AddSong.aspx");
        }

        protected void Premium_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Premium.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            string[] cookies = Response.Cookies.AllKeys;

            foreach (string cookie in cookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            Session.Abandon();
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}