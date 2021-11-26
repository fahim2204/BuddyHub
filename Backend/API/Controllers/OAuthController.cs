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
    public class OAuthController : ApiController
    {

        [HttpGet]
        [Route("Api/OAuth")]
        public IHttpActionResult GetOAuth()
        {
            var _oAuth = OAuthService.GetAllOAuth();
            if (_oAuth == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_oAuth);
            }
        }
        [HttpPost]
        [Route("Api/OAuth")]
        public IHttpActionResult CreateOAuth(OAuthDto oAuth)
        {
            if (ModelState.IsValid)
            {
                OAuthService.RegisterOAuth(oAuth);
                return Ok("User Registered Successfully");
            }
            else
            {
                return BadRequest("Didn't Fullfill Validation");
            }

        }
    }
}
