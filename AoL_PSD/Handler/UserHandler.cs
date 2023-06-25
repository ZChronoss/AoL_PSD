using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoL_PSD.Model;
using AoL_PSD.Repository;

namespace AoL_PSD.Handler
{
    public class UserHandler
    {
        UserRepository ur = new UserRepository();
        public User Login(String username, String password)
        {
            User user = ur.Login(username, password);
            return user;
        }

        public void Register(string username, string email, string password)
        {
            ur.Register(username, email, password);
        }

        public User GetUserByEmail(string email)
        {
            User user = ur.GetUserByEmail(email);
            return user;
        }

        public User EditPremium(int userId)
        {
            User premUser = ur.EditPremium(userId);
            return premUser;
        }
    }
}