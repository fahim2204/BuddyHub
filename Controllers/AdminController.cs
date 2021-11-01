using BuddyHub.Auth;
using BuddyHub.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuddyHub.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [AdminAccess]
        public ActionResult Index()
        {
            return View();
        }
        [AdminAccess]
        public ActionResult AllUser()
        {
            return View(ProfileRepository.GetAllProfileData());
        }
        [AdminAccess]
        public ActionResult AllPost()
        {
            return View(PostRepository.GetPostData());
        }
    }
}