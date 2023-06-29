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
            // balikin user ke login kalo udh session dah end
            if (Session["User"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }

            User curUser = (User)Session["User"];
            // buat tampilin music di playlist
            List<Playlist> playlistmusics = ph.GetPlaylistMusics(curUser.Id);
            PlaylistGridView.DataSource = playlistmusics;
            PlaylistGridView.DataBind();

            // buat tampilin Musics
            List<Music> themusics = mh.GetMusics();
            MusicGridView.DataSource = themusics;
            MusicGridView.DataBind();            

            // ngecek tampilin PREMIUM ato ngga            
            if(curUser.IsPremium == 1)
            {
                premiumBtn.Visible = false;
                premiumUserLabel.Visible = true;
                MusicGridView.Columns[6].Visible = true;
                MusicGridView.Columns[7].Visible = true;
                notPremiumLbl.Visible = false;
                playlistLbl.Visible = true;
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

            // cek playlistnya udah ada apa belom
            bool valid = ph.sameMusic(id, user.Id);

            if (valid)
            {
                // execute
                ph.addToPlaylist(user, id);
                Response.Redirect("~/Views/Home.aspx");
            }
            else
            {
                AddPlaylistError.Visible = true;
            }


            
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

        protected void PlaylistGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = MusicGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

            User curUser = (User)Session["User"];

            ph.deletePlaylist(curUser.Id, id);
            Response.Redirect("~/Views/Home.aspx");
        }
    }
}