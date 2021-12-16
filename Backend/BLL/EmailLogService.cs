using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmailLogService
    {
        public static string EntryEmailByUsername(string username)
        {
            var _user = UserService.GetUserByUsername(username);
            EmailLog _emailLog = DataAccessFactory.EmailLogDataAccess().Get().Where(x => x.Fk_User_Id == _user.Id).LastOrDefault();
            if (_emailLog == null)
            {
                _emailLog = new EmailLog()
                {
                    Fk_User_Id = _user.Id,
                    EmailToken = Guid.NewGuid().ToString(),
                    Created_At = DateTime.Now,
                    Status = 0     // Unconfirmed Email
                };
                DataAccessFactory.EmailLogDataAccess().Add(_emailLog);
            }
            return _emailLog.EmailToken;
        }
        public static bool ConfirmEmailStatus(string token)
        {
            EmailLog _emailLog = DataAccessFactory.EmailLogDataAccess().Get().Where(x => x.EmailToken == token).LastOrDefault();
            if(_emailLog == null)
            {
                return false;
            }
            else
            {
                _emailLog.Status = 1;
                DataAccessFactory.EmailLogDataAccess().Edit(_emailLog.Id, _emailLog);
                return true;
            }


        }
    }
}
