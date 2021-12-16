using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static BuddyDbContext db;
        static DataAccessFactory()
        {
            db = new BuddyDbContext();
        }
        public static IRepository<User,int> UserDataAccess()
        {
            return new UserRepo(db);
        }
        public static IRepository<Post, int> PostDataAccess()
        {
            return new PostRepo(db);
        }
        public static IRepository<OAuth, int> OAuthDataAccess()
        {
            return new OAuthRepo(db);
        }
        public static IRepository<Profile, int> ProfileDataAccess()
        {
            return new ProfileRepo(db);
        }
        public static IRepository<Log, int> LogDataAccess()
        {
            return new LogRepo(db);
        }
        public static IRepository<EmailLog, int> EmailLogDataAccess()
        {
            return new EmailLogRepo(db);
        }
    }
}
