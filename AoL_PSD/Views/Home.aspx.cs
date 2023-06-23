using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AoL_PSD.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void premiumBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Premium.aspx");
        }

        protected void addSongBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AddSong.aspx");
        }
    }
}