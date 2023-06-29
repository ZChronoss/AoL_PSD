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
        PlaylistHandler ph = new PlaylistHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            // buat tampilin music di playlist
            List<Playlist> playlistmusics = ph.GetPlaylistMusics();
            PlaylistGridView.DataSource = playlistmusics;
            PlaylistGridView.DataBind();

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
                notPremiumLbl.Visible = false;
            }

            Music randMusic = mh.getRandomSong();

            if (randMusic == null)
            {
                noMusicLbl.Visible = true;
            }
            else
            {
                String loc = "../Song/" + randMusic.FileLocation;
                audioLiteral.Text = "<audio controls> <source src='../Song/" + loc + "' type='audio/ogg' /></audio>";
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

        protected void MusicGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // buat musicID
            GridViewRow row = MusicGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

            // buat userID
            User user = (User)Session["User"];

            // execute
            ph.addToPlaylist(user, id);
            
        }
    }
}