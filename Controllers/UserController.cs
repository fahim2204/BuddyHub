using BuddyHub.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BuddyHub.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            var db = new buddyhubEntities();
            return View(db.Users.ToList());
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            var db = new buddyhubEntities();
            var user = (from usr in db.Users
                        where usr.Username == u.Username && usr.Password == u.Password
                        select usr).FirstOrDefault();
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                return RedirectToAction("Index", "Home");
            }
            return View(u);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Registration(User u)
        {
            var db = new buddyhubEntities();
            var user = (from usr in db.Users
                       where usr.Username == u.Username
                       select usr).FirstOrDefault();
            if(user != null)
            {
                ModelState.AddModelError("Username", "Username already taken, choose another username");
                return View(u);
            }

 /*           if(u.Password != u.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "Password does not match");
                return View(u);
            }*/
            u.Type = "general";
            u.Status = 1;
            db.Users.Add(u);
            db.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}