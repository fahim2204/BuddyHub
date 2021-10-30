﻿using BuddyHub.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuddyHub.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var db = new buddyhubEntities();
            return View(db.Users.ToList());
        }
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
        [Route("Registration")]
        public ActionResult Registration()
        {
            return View();
        }
    }
}