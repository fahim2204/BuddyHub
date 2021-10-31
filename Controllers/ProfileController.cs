using BuddyHub.Models.EntityFramework;
using BuddyHub.Models.VM;
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
            int UserId = (int)Session["UserId"];
            ProfileRepository pr = new ProfileRepository();
            var temp = pr.GetProfileData(UserId);
            return View(temp);
        }
        public ActionResult View(string Username)
        {
            string UserName = "fahim";
            ProfileRepository pr = new ProfileRepository();
            var temp = pr.GetProfileData(UserName);
            return View(temp);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            int UserId = (int)Session["UserId"];
            ProfileRepository pr = new ProfileRepository();
            var temp = pr.GetProfileData(UserId);
            return View(temp);
        }
        [HttpPost]
        public ActionResult Edit(ProfileData p)
        {
            var db = new buddyhubEntities();
            int UserId = (int)Session["UserId"];
            ProfileRepository pr = new ProfileRepository();
            var temp = pr.GetProfileData(UserId);
            pr.UpdateName(UserId, p.Name);
            pr.UpdateProfile(UserId, p);
            return RedirectToAction("Index", "Profile");
        }
    }
}