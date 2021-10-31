using BuddyHub.Models.EntityFramework;
using BuddyHub.Models.VirtualModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyHub.Repo
{
    public static class PostRepository
    {
        static buddyhubEntities db;
        static PostRepository()
        {
            db = new buddyhubEntities();
        }
        public static List<PostData> GetPostData()
        {
            var posts = (from u in db.Users
                         join p in db.Posts on u.Id equals p.FK_Users_Id
                         select new PostData()
                         {
                             PostId = p.Id,
                             PostText = p.PostsText,
                             CreatedAt = (DateTime)p.CreatedAt,
                             Status = (int)p.Status,
                             Username = u.Username,
                             Likes = (from l in db.Likes where l.FK_Posts_Id==p.Id select l).ToList(),
                             Comments = (from c in db.Comments where c.FK_Posts_Id == c.Id select c).ToList()
                         }).ToList();
            return posts;
        }
        public static PostData GetPostDataById(int id)
        {
            var posts = (from u in db.Users
                         join p in db.Posts on u.Id equals p.FK_Users_Id 
                         where p.Id == id
                         select new PostData()
                         {
                             PostId = p.Id,
                             PostText = p.PostsText,
                             CreatedAt = (DateTime)p.CreatedAt,
                             Status = (int)p.Status,
                             Username = u.Username
                         }).ToList().FirstOrDefault();
            return posts;
        }

        public static void CreatePost(PostData pd, int UserId)
        {
            Post p = new Post()
            {
                PostsText = pd.PostText,
                CreatedAt = DateTime.Now,
                Status = 1,
                FK_Users_Id = UserId
            };
            db.Posts.Add(p);
            db.SaveChanges();

        }
    }
}