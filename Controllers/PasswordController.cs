using BuddyHub.Models.VirtualModel;
using BuddyHub.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuddyHub.Controllers
{
    public class PasswordController : Controller
    {
        // GET: Password
        [HttpGet]
        [Authorize]
        public ActionResult SetRecoveryPassword()
        {
            int FK_Users_Id = (int)Session["UserId"];
            RecoveryPasswordData rpd = new RecoveryPasswordData();
            rpd = RecoveryPasswordRepository.FindUser(FK_Users_Id);
            return View(rpd);
        }

        [HttpPost]
        [Authorize]
        public ActionResult SetRecoveryPassword(RecoveryPasswordData rpd)
        {
            if (ModelState.IsValid)
            {
                int FK_Users_Id = (int)Session["UserId"];
                RecoveryPasswordRepository.SetQuestionAnswer(rpd, FK_Users_Id);
                return RedirectToAction("SetRecoveryPassword");
            }
            return View(rpd);
        }

        [HttpGet]
        public ActionResult GetRecoveryPassword()
        {
            int UserId = (int)Session["UserId"];
            RecoveryPasswordData r = RecoveryPasswordRepository.FindUser(UserId);
            if (r == null)
            {
                return RedirectToAction("RecoveryNotSet");
            }
            RecoveryPasswordData rpd = new RecoveryPasswordData();
            return View(rpd);
        }

        [HttpPost]
        public ActionResult GetRecoveryPassword(RecoveryPasswordData rpd)
        {
            int UserId = (int)Session["UserId"];
            RecoveryPasswordData r = RecoveryPasswordRepository.FindUser(UserId);
            if((rpd.QuestionOne == r.QuestionOne.Trim()) && (rpd.QuestionOneAnswer == r.QuestionOneAnswer.Trim()) && (rpd.QuestionTwo == r.QuestionTwo.Trim()) && (rpd.QuestionTwoAnswer == r.QuestionTwoAnswer.Trim()))
            {
                return RedirectToAction("ChangePassword");
            }
            return View(rpd);
        }

        [HttpGet]
        public ActionResult CheckingUsername()
        {
            UserData u = new UserData();
            return View(u);
        }

        [HttpPost]
        public ActionResult CheckingUsername(UserData u)
        {
            if(ModelState.IsValid)
            {
                var user = UserRepo.FindUser(u.Username);
                if (user == null)
                {
                    ModelState.AddModelError("Username", "No username found");
                    return View(u);
                }
                Session["UserId"] = user.Id;
                Session["Username"] = user.Username;
                return RedirectToAction("GetRecoveryPassword");
            }
            return View(u);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            ChangePassData cpd = new ChangePassData();
            return View(cpd);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassData cpd)
        {
            if(ModelState.IsValid)
            {
                string Username = (string)Session["Username"];
                ChangePasswordRepository.ChangePassword(Username, cpd.Password);
                return RedirectToAction("Login", "User");
            }
            return View(cpd);
        }

        [HttpGet]
        public ActionResult RecoveryNotSet()
        {
            return View();
        }

    }
}