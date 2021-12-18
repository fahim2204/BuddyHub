using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class PostRepo : IRepository<Post, int>
    {
        readonly BuddyDbContext db;

        public PostRepo(BuddyDbContext db)
        {
            this.db = db;
        }

        public void Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Post entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> Get()
        {
            throw new NotImplementedException();
        }

        public Post Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
