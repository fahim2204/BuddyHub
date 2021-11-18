using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserService
    {
        public static IEnumerable<User> GetAllUser()
        {
            return DataAccessFactory.UserDataAccess().Get();
        }
    }
}
