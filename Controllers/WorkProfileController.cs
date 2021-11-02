using BuddyHub.Models.VirtualModel;
using BuddyHub.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuddyHub.Controllers
{
    public class WorkProfileController : Controller
    {
        // GET: WorkProfile
        public ActionResult ShowWorkProfile()
        {
            int UserId = (int)Session["UserId"];
            List<WorkProfileData> wp = WorkProfileRepository.ShowWorkProfile(UserId);
            return View(wp);
        }

        [HttpGet]
        public ActionResult AddWorkProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWorkProfile(WorkProfileData wpd)
        {
            int UserId = (int)Session["UserId"];
            if (ModelState.IsValid)
            {
                WorkProfileRepository.AddWorkProfile(UserId, wpd);
                return RedirectToAction("ShowWorkProfile");
            }
            return View(wpd);
        }

        [HttpGet]
        public ActionResult EditWorkProfile(int id)
        {
            WorkProfileData wpd = WorkProfileRepository.FindWorkProfileById(id);
            return View(wpd);
        }

        [HttpPost]
        public ActionResult EditWorkProfile(WorkProfileData wpd)
        {
            int UserId = (int)Session["UserId"];
            if (ModelState.IsValid)
            {
                WorkProfileRepository.EditWorkProfile(wpd);
                return RedirectToAction("ShowWorkProfile");
            }
            return View(wpd);
        }
    }
}