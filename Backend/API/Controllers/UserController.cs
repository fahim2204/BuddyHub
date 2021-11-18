using AutoMapper;
using BLL;
using BOL;
using BOL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        [Route("Api/User")]
        public IEnumerable<User> Get()
        {
            return UserService.GetAllUser();

        }
    }
}
