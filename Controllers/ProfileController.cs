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
        [Authorize]
        public ActionResult ViewProfile(string Username)
        {
            return View(ProfileRepository.GetProfileData(Username));
        }
        [Authorize]
        public ActionResult WorkProfile(string Username)
        {
            return View(ProfileRepository.GetProfileData(Username));
        }
        public ActionResult DeleteWorkProfile(string Username, int OpId)
        {
            WorkProfileRepository.DeleteWorkProfile(OpId);
            return Redirect("/Profile/"+Username);
        }
        [Authorize]
        public ActionResult Posts(string Username)
        {
            return View(ProfileRepository.GetProfileData(Username));
        }
        [HttpGet]
        [Authorize]
        public ActionResult Edit()
        {

            int UserId = (int)Session["UserId"];
            var temp = ProfileRepository.GetProfileData(UserId);

            return View(temp);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Edit(ProfileData p)
        {
            var db = new buddyhubEntities();
            int UserId = (int)Session["UserId"];
            var temp = ProfileRepository.GetProfileData(UserId);
            ProfileRepository.UpdateName(UserId, p.Name);
            ProfileRepository.UpdateProfile(UserId, p);
            return Redirect("/Profile/"+p.Username);
        }
    }
}