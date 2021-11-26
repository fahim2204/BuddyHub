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
    public class RegistrationController : ApiController
    {
        [HttpPost]
        [Route("Api/Register")]
        public IHttpActionResult RegisterUser(RegistrationDto registrationDto)
        {
            if (ModelState.IsValid)
            {
                RegistrationService.RegisterUser(registrationDto);
                return Ok("Registered Successfully");
            }
            else
            {
                return BadRequest(ModelState);
            }
        } 
        [HttpGet]
        [Route("Api/Register")]
        public IHttpActionResult GetAllUser(RegistrationDto registrationDto)
        {
            var _users = RegistrationService.GetAllUser();
            if (_users == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_users);
            }
        }

    }
}
