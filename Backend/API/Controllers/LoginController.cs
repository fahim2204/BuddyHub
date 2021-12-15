using BLL;
using BOL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Api/Login")]
        public IHttpActionResult DoLogin(LoginDto _user)
        {
            if (ModelState.IsValid)
            {
                if (UserService.IsAuthenticUser(_user))
                {
                    return Ok(LogService.GetTokenByUsername(_user.Username));
                }
                else
                {
                    return BadRequest("Already Registered!!");
                }
            }
            else
            {
                return BadRequest("Didn't Fullfill Validation");
            }
        }
    }
}
