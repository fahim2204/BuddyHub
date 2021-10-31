using BuddyHub.Models.EntityFramework;
using BuddyHub.Models.VirtualModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyHub.Repo
{
    public static class UserRepo
    {
        static buddyhubEntities db;
        static UserRepo()
        {
            db = new buddyhubEntities();
        }
        public static User GetAuthenticateUser(LoginData ld)
        {
            var user = (from u in db.Users
                        where u.Username == ld.Username && u.Password == ld.Password
                        select u).FirstOrDefault();
             return user;

        }
        public static void RegisterUser(RegistrationData ld)
        {
            User user = new User()
            {
                Username = ld.Username,
                Password = ld.Password,
                Name = ld.Name,
                Type = "general",
                Status = 1
            };
            db.Users.Add(user);
            db.SaveChanges();
        }
        public static bool IsUsernameUnique(string username)
        {
            return !db.Users.Any(u => u.Username == username);
        }

        public static UserData FindUser(string username)
        {
            var user = (from usr in db.Users
                        where usr.Username == username
                        select usr).FirstOrDefault();
            if(user == null)
            {
                return null;
            }
            UserData u = new UserData()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                Type = user.Type,
                Status = user.Status
            };
            return u;
        }
    }
}