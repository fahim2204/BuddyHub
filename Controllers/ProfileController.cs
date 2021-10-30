using BuddyHub.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuddyHub.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            ProfileRepository pr = new ProfileRepository();
            var temp = pr.GetProfileData();
            return View(temp);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}