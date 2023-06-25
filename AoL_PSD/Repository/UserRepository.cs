using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoL_PSD.Model;
using AoL_PSD.Factory;

namespace AoL_PSD.Repository
{
    public class UserRepository
    {
        Database1Entities db = new Database1Entities();
        public User Login(String username, String password)
        {
            User user = db.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            return user;          
        }

        public void Register(string username, string email, string password)
        {
            User newUser = UserFactory.CreateUser(username, email, password);
            db.Users.Add(newUser);
            db.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            User user = db.Users.Where(x => x.Email == email).FirstOrDefault();
            return user;
        }

        public void EditPremium(User user)
        {
            User premiumUser = db.Users.Where(x => x.Id == user.Id).FirstOrDefault();

            if (premiumUser != null)
            {
                premiumUser.IsPremium = 1;
                db.SaveChanges();
            }
        }
    }
}