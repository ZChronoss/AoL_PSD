using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoL_PSD.Model;

namespace AoL_PSD.Factory
{
    public class UserFactory
    {
        public User CreateUser(string username, string email, string password)
        {
            User newUser = new User()
            {
                Username = username,
                Email = email,
                Password = password,
                IsPremium = 0
            };

            return newUser;
        }
    }
}