using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AoL_PSD.Model;

namespace AoL_PSD.Views
{
    public partial class AddSong : System.Web.UI.Page
    {
        Database1Entities db = new Database1Entities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                List<String> genres = (from genre in db.Genre select genre.Name).ToList();

                GenreDropList.DataSource = genres;
                GenreDropList.DataBind();
            }
        }

        protected void addMusicBtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile == true) // gw gtau ini pindahin ke MusicController gmn
            {
                String title = TitleTextBox.Text;
            }
            else
            {
                FileValid.Visible = true;
            }
        }
    }
}