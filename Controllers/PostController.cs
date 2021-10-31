using BuddyHub.Models.VirtualModel;
using BuddyHub.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuddyHub.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreatePost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreatePost(PostData pd)
        {
            int UserId = (int)Session["UserId"];
            PostRepository.CreatePost(pd, UserId);
            return View();
        }
    }
}