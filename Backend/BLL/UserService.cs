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
    public class UserService
    {
        public static IEnumerable<UserDto> GetAllUser()
        {
            return DataAccessFactory.UserDataAccess().Get().Select(Mapper.Map<User,UserDto>);
        }

        public static UserDto GetUserById(int id)
        {
            var _User = DataAccessFactory.UserDataAccess().Get(id);
            if (_User != null )
            {
                return Mapper.Map<User, UserDto>(_User);
            }
            else
            {
                return null;

            }
        }

        public static bool RegisterUser(UserDto user)
        {
            if(user == null || !IsUsernameAvailble(user.Username)) { return false; }
            else
            {
                DataAccessFactory.UserDataAccess().Add(Mapper.Map<UserDto,User>(user));
                return true;
            }
        }

        public static bool DeleteUserById(int id)
        {
            var _User = DataAccessFactory.UserDataAccess().Get(id);
            if (_User == null) { return false; }
            else
            {
                DataAccessFactory.UserDataAccess().Delete(id);
                return true;
            }
        }

        public static UserDto GetUserByUsername(string username)
        {
            var _User = DataAccessFactory.UserDataAccess().Get().Where(u => u.Username == username).FirstOrDefault();
            if (_User != null)
            {
                return Mapper.Map<User, UserDto>(_User);
            }
            else
            {
                return null;

            }
        }
        public static bool IsUsernameAvailble(string username)
        {
            return GetUserByUsername(username) == null ? true : false;
        }

        public static bool EditUser(int id, UserDto user)
        {
            var _User = DataAccessFactory.UserDataAccess().Get(id);

            if (_User == null) { return false; }
            else
            {
                DataAccessFactory.UserDataAccess().Edit(id, Mapper.Map<UserDto, User>(user));
                return true;
            }
        }
    }
}
