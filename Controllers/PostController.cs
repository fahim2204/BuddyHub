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
        public ActionResult View(int id)
        {
            return View(PostRepository.GetPostDataById(id));
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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditPost(int id) 
        {
            //System.Diagnostics.Debug.WriteLine(PoId);

            string UserId = (string)Session["Username"];
            var post = PostRepository.GetPostDataById(id);
            if (post.Username != UserId)
            {
                return RedirectToAction("Index", "Home");

            }
            return View(post);

        }


        [Authorize]
        [HttpPost]
        public ActionResult EditPost(PostData pd, int id)
        {
            var b = PostRepository.EditPost(pd, id);
            if(b)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(pd);
        }

        [Authorize]
        public ActionResult RemovePost(int id)
        {
            int UserId = (int)Session["UserId"];
            bool b = PostRepository.RemovePost(id, UserId);         
            return RedirectToAction("Index", "Home");
        }
    }
}