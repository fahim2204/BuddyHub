using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepo : IRepository<User,int>
    {
        readonly BuddyDbContext db;
        public UserRepo(BuddyDbContext db) => this.db = db;

        public bool Add(User user)
        {
            if (user != null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            var _user = db.Users.FirstOrDefault(u => u.Id == id);
            if (_user != null)
            {
                db.Users.Remove(_user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Edit(int id, User user)
        {
            var _user = db.Users.FirstOrDefault(u => u.Id == id);
            if(_user != null)
            {
                db.Entry(_user).CurrentValues.SetValues(user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public User Get(int id) => db.Users.FirstOrDefault(u => u.Id == id);

        public IEnumerable<User> Get() => db.Users;
       

    }
}
