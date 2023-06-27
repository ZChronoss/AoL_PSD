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
                MusicGridView.Columns[6].Visible = true;
                notPremiumPlaySong.Visible = false;
            }

            if(mh.getMusicCount() == 0)
            {
                notPremiumPlaySong.Visible = false;
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

        protected void notPremiumPlaySong_Click(object sender, EventArgs e)
        {
            Music randMusic = mh.getRandomSong();
            String loc = "../Song/" + randMusic.FileLocation;

            Response.Write("<audio controls> < source src = '" + loc + "' type = 'audio/ogg' /></ audio > ");
        }
    }
}