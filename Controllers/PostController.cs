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

        [Authorize]
        [HttpGet]
        public ActionResult EditPost(int PoId)
        {
            int UserId = (int)Session["UserId"];
            var post = PostRepository.GetPostDataById(PoId);
            if(post.FK_Users_Id == UserId)
            {
                return View(post);
            }
            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        [HttpPost]
        public ActionResult EditPost(PostData pd, int PoId)
        {
            var b = PostRepository.EditPost(pd, PoId);
            if(b)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(pd);
        }

        [Authorize]
        public ActionResult RemovePost(int PoId)
        {
            int UserId = (int)Session["UserId"];
            bool b = PostRepository.RemovePost(PoId, UserId);         
            return RedirectToAction("Index", "Home");
        }
    }
}