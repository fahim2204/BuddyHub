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
    public class OAuthService
    {
        public static IEnumerable<OAuth> GetAllOAuth()
        {

            //OAuth _oAuth = DataAccessFactory.OAuthDataAccess().Get();
            //var temp2 = DataAccessFactory.UserDataAccess().Get().Where(u=> u.Id == _oAuth.FK_Users_Id);


            return DataAccessFactory.OAuthDataAccess().Get();
        }

        public static OAuthDto GetOAuthById(int id)
        {
            var _OAuth = DataAccessFactory.OAuthDataAccess().Get(id);
            var _User = DataAccessFactory.UserDataAccess().Get(id);
            if (_OAuth != null )
            {
                var temp = Mapper.Map<OAuthDto>(_OAuth);
                return Mapper.Map<OAuth, OAuthDto>(_OAuth);
            }
            else
            {
                return null;

            }
        }

        public static bool RegisterOAuth(OAuthDto OAuth)
        {
            if(OAuth == null) { return false; }
            else
            {
                var _user = new User()
                {
                    Name = OAuth.Name,
                    Username = OAuth.Username,
                    Type = "general",
                    Status = 1,
                    Password = OAuth.Password
                };
                DataAccessFactory.UserDataAccess().Add(_user);
                var  fk_uid = UserService.GetUserByUsername(OAuth.Username).Id;
                var _oAuth = new OAuth()
                {
                    FK_Users_Id = fk_uid,
                    OriginId = OAuth.OriginId,
                    OriginName = OAuth.OriginName
                };
                DataAccessFactory.OAuthDataAccess().Add(_oAuth);
                return true;
            }
        }

        public static bool DeleteOAuthById(int id)
        {
            var _OAuth = DataAccessFactory.OAuthDataAccess().Get(id);
            if (_OAuth == null) { return false; }
            else
            {
                DataAccessFactory.OAuthDataAccess().Delete(id);
                return true;
            }
        }

        public static bool EditOAuth(int id, OAuthDto OAuth)
        {
            var _OAuth = DataAccessFactory.OAuthDataAccess().Get(id);

            if (_OAuth == null) { return false; }
            else
            {
                DataAccessFactory.OAuthDataAccess().Edit(id, Mapper.Map<OAuthDto, OAuth>(OAuth));
                return true;
            }
        }
    }
}
