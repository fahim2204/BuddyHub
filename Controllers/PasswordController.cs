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
            }
            return View(rpd);
        }
    }
}