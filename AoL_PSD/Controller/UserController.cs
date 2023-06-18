using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using AoL_PSD.Model;
using AoL_PSD.Handler;

namespace AoL_PSD.Controller
{
    public class UserController
    {
        UserHandler uh = new UserHandler();
        public List<bool> Login(String username, String password, bool remember)
        {
            List<bool> validation = new List<bool>();
            bool valid = true;
            for (int i = 0; i < 3; i++)
            {
                validation.Add(true);
            }

            if (username.Length == 0)
            {
                validation[0] = false;
                valid = false;
            }

            if (password.Length == 0)
            {
                validation[1] = false;
                valid = false;
            }

            if (valid)
            {
                User user = uh.Login(username, password);

                if (user == null)
                {
                    validation[2] = false;
                }
                else
                {
                    if (remember)
                    {
                        HttpCookie cookie = new HttpCookie("user_cookie");
                        cookie.Value = user.Id.ToString();
                        cookie.Expires = DateTime.Now.AddHours(1);
                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }

                    HttpContext.Current.Session["User"] = user;                  
                }
            }

            return validation;
        }

        public List<bool> Register(string username, string email, string password, string confPass)
        {
            List<bool> validation = new List<bool>();
            bool valid = true;
            for (int i = 0; i < 4; i++)
            {
                validation.Add(true);
            }

            if (!usernameValid(username))
            {
                validation[0] = false;
                valid = false;
            }

            if (!emailValid(email))
            {
                validation[1] = false;
                valid = false;
            }

            if (!passwordValid(password, confPass))
            {
                validation[2] = false;
                valid = false;
            }

            if (existSameEmail(email))
            {
                validation[3] = false;
                valid = false;
            }

            if (valid)
            {
                uh.Register(username, email, password);
            }

            return validation;
        }

        private bool usernameValid(string username)
        {
            if (username.Length >= 5 && username.Length <= 15)
            {
                string trimUname = Regex.Replace(username, @"\s", "");

                if (trimUname.All(Char.IsLetter))
                {
                    return true;
                    // Kalo format username betul
                }
            }

            return false;
            // Kalo format username salah
        }

        private bool emailValid(string email)
        {
            if (email.EndsWith(".com") && email.Length != 0)
            {
                return true;
            }

            return false;
        }

        private bool passwordValid(string password, string confPass)
        {
            if (password == confPass && password.Length != 0)
            {
                return true;
            }

            return false;
        }

        private bool existSameEmail(string email)
        {
            User sameUser = uh.GetUserByEmail(email);
            if (sameUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}