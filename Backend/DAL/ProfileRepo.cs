using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProfileRepo : IRepository<Profile,int>
    {
        readonly BuddyDbContext db;
        public ProfileRepo(BuddyDbContext db) => this.db = db;

        public void Add(Profile Profile)
        {
                db.Profiles.Add(Profile);
                db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _Profile = db.Profiles.FirstOrDefault(u => u.FK_Users_Id == id);
            db.Profiles.Remove(_Profile);
            db.SaveChanges();
           
        }

        public void Edit(int id, Profile Profile)
        {
            var _Profile = db.Profiles.FirstOrDefault(u => u.FK_Users_Id == id);
            
            db.Entry(_Profile).CurrentValues.SetValues(Profile);
            db.Entry(_Profile).Property(x => x.FK_Users_Id).IsModified = false;
            db.SaveChanges();
        }

        public Profile Get(int id) => db.Profiles.FirstOrDefault(u => u.FK_Users_Id == id);

        public IEnumerable<Profile> Get() => db.Profiles;
       

    }
}
