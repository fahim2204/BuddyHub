using BuddyHub.Models.EntityFramework;
using BuddyHub.Models.VirtualModel;
using BuddyHub.Repo;
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
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginData ld)
        {
            if (ModelState.IsValid)
            {
                UserRepo ur = new UserRepo();
                var user = ur.GetAuthenticateUser(ld);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username.ToString(), false);
                    Session["UserId"] = user.Id; 
                    return RedirectToAction("SetRecoveryPassword", "Password");
                }
            }
             return View(ld);

        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationData rd)
        {

            if (ModelState.IsValid)
            {
                UserRepo ur = new UserRepo();
                if (ur.IsUsernameUnique(rd.Username))
                {
                    ur.RegisterUser(rd);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Username", "Username already taken, choose another username");
                } 
            }
            return View(rd);


        }
    }
}