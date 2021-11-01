using BuddyHub.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyHub.Repo
{
    public static class ChangePasswordRepository
    {
        static buddyhubEntities db;
        static ChangePasswordRepository()
        {
            db = new buddyhubEntities();
        }

        public static void ChangePassword(string username, string password)
        {
            User u = db.Users.Single(usr => usr.Username == username);
            u.Password = password;
            db.SaveChanges();
        }

    }
}