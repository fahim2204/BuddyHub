﻿using BuddyHub.Models.EntityFramework;
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
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginData ld)
        {
            if (ModelState.IsValid)
            {
                var user = UserRepo.GetAuthenticateUser(ld);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Username.ToString(), false);
                    Session["UserId"] = user.Id;
                    Session["Username"] = user.Username;
                    Session["Name"] = user.Name;
                    return RedirectToAction("Index", "Home");
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
                if (UserRepo.IsUsernameUnique(rd.Username))
                {
                    UserRepo.RegisterUser(rd);
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