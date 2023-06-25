using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AoL_PSD.Model;
using AoL_PSD.Handler;

namespace AoL_PSD.Views
{
    public partial class Home : System.Web.UI.Page
    {
        MusicHandler mh = new MusicHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            // buat tampilin Musics
            List<Music> themusics = mh.GetMusics();
            MusicGridView.DataSource = themusics;
            MusicGridView.DataBind();

            // balikin user ke login kalo udh session dah end
            if (Session["User"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }

            // ngecek tampilin PREMIUM ato ngga
            User curUser = (User)Session["User"];
            if(curUser.IsPremium == 1)
            {
                premiumBtn.Visible = false;
                premiumUserLabel.Visible = true;
            }
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