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
            var temp = ProfileRepository.GetProfileData();
            return View(temp);
        }
        [HttpGet]
        public ActionResult Edit()
        {
            var temp = ProfileRepository.GetProfileData();
            return View(temp);
        }
    }
}