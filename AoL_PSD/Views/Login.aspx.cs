using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AoL_PSD.Controller;

namespace AoL_PSD.Views
{
    public partial class Login : System.Web.UI.Page
    {
        UserController uc = new UserController();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {            
            String username = UsernameTextBox.Text;
            String password = PasswordTextBox.Text;
            bool remember = RememberMe.Checked;

            List<bool> validation = uc.Login(username, password, remember);
            bool valid = true;

            if (!validation[0])
            {
                UsernameEmpty.Visible = true;
                valid = false;
            }
            else
            {
                UsernameEmpty.Visible = false;
            }

            if (!validation[1])
            {
                PasswordEmpty.Visible = true;
                valid = false;
            }
            else
            {
                PasswordEmpty.Visible = false;
            }

            if (!validation[2])
            {
                NoUser.Visible = true;
                valid = false;
            }
            else
            {
                NoUser.Visible = false;
            }

            if (valid)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }
    }
}