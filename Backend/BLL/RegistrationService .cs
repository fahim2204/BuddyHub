using AutoMapper;
using BOL;
using BOL.Dto;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;


namespace BLL
{
    public class RegistrationService
    {
       
        public static bool RegisterUser(RegistrationDto user)
        {
            if(user == null) { return false; }
            else
            {
                DataAccessFactory.UserDataAccess().Add(Mapper.Map<RegistrationDto, User>(user));
                return true;
            }
        }
        public static IEnumerable<RegistrationDto> GetAllUser()
        {
            return DataAccessFactory.UserDataAccess().Get().Select(Mapper.Map<User, RegistrationDto>);
        }
    }
}
