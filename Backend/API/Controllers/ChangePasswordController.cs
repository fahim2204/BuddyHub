using BLL;
using BOL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ChangePasswordController : ApiController
    {
        [HttpPost]
        [Route("Api/ChangePassword")]
        public IHttpActionResult ChangePassword(ChangePasswordDto cp)
        {
            if (ModelState.IsValid)
            {
                return Ok(ChangePasswordService.ChangePassword(cp));
            }
            else
            {
                return BadRequest("Didn't Fullfill Validation");
            }

        }
    }
}
