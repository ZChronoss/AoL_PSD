using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AoL_PSD.Model;
using AoL_PSD.Controller;
using AoL_PSD.Handler;

namespace AoL_PSD.Views
{
    public partial class AddSong : System.Web.UI.Page
    {
        MusicController mc = new MusicController();
        MusicHandler mh = new MusicHandler();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }

            if (IsPostBack == false)
            {
                List<Genre> genres = mh.GetGenres();

                GenreDropList.DataSource = genres;

                GenreDropList.DataTextField = "Name"; // ini sesuai sama nama di model [ini yang bakal ditampilin]
                GenreDropList.DataValueField = "Id"; // ini yang bakal jadi valuenya
                GenreDropList.DataBind();
                GenreDropList.Items.Insert(0, new ListItem("--Select--", String.Empty));                
            }
        }

        protected void addMusicBtn_Click(object sender, EventArgs e)
        {
            if (SongFile.HasFile)
            {                
                FileValid.Visible = false;

                User user = (User)Session["User"];
                string title = TitleTextBox.Text;
                string genre = GenreDropList.SelectedValue;
                string fileName = SongFile.FileName.Remove(SongFile.FileName.Length - 5) + user.Id;
                string fileExt = SongFile.FileName.Remove(0, SongFile.FileName.Length - 4);
                List<bool> validation = mc.AddMusic(user, title, genre, fileName, fileExt);
                bool valid = true;

                if (!validation[0])
                {
                    TitleValid.Visible = true;
                    valid = false;
                }
                else
                {
                    TitleValid.Visible = false;
                }

                if (!validation[1])
                {
                    GenreValid.Visible = true;
                    valid = false;
                }
                else
                {
                    GenreValid.Visible = false;
                }

                if (!validation[2])
                {
                    FileValid2.Visible = true;
                    valid = false;
                }
                else
                {
                    FileValid2.Visible = false;
                }

                if (!validation[3])
                {
                    ErrorLabel.Visible = true;
                    valid = false;
                }
                else
                {
                    ErrorLabel.Visible = false;
                }

                if (valid)
                {
                    SongFile.SaveAs(Server.MapPath("~/Song/") + fileName + fileExt);
                }
            }
            else
            {
                FileValid.Visible = true;
            }
        }
    }
}