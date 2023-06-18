using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AoL_PSD.Controller;
using AoL_PSD.Model;

namespace AoL_PSD.Views
{
    public partial class Register : System.Web.UI.Page
    {
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                Response.Redirect("~/Views/Home.aspx");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            String username = UsernameTextBox.Text;
            String email = EmailTextBox.Text;
            String password = PasswordTextBox.Text;
            String confPass = ConfPasswordTextBox.Text;

            List<bool> validation = uc.Register(username, email, password, confPass);
            bool valid = true;

            // username
            if (!validation[0])
            {
                UsernameValid.Visible = true;
                valid = false;
            }
            else
            {
                UsernameValid.Visible = false;
            }

            // email
            if (!validation[1])
            {
                EmailValid.Visible = true;
                valid = false;
            }
            else
            {
                EmailValid.Visible = false;
            }

            // password
            if (!validation[2])
            {
                PasswordValid.Visible = true;
                valid = false;
            }
            else
            {
                PasswordValid.Visible = false;
            }

            // same user
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
                Response.Redirect("~/Views/Login.aspx");
            }
        }
    }
}