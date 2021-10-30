using BuddyHub.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuddyHub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PostRepository pr = new PostRepository();
            return View(pr.GetPostData());
        }
    }
}