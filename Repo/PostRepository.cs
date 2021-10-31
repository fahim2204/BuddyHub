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
                             Username = u.Username,
                              Likes = (from l in db.Likes where l.FK_Posts_Id == p.Id select l).ToList(),
                             Comments = (from c in db.Comments where c.FK_Posts_Id == c.Id select c).ToList()
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

        public static bool EditPost(PostData pd, int PoId)
        {
            var post = db.Posts.Single(p => p.Id == PoId);
            post.PostsText = pd.PostText;
            db.SaveChanges();
            return true;
        }

        public static bool RemovePost(int PoId, int UserId)
        {
            var post = db.Posts.Find(PoId);
            if(post.FK_Users_Id == UserId)
            {
                db.Posts.Remove(post);
                db.SaveChanges();
                return true;
            }
            return false;
            
        }
        public static void CreateLike(string username,int postId)
        {
            var user = UserRepo.FindUser(username);
            if (!IsPostLikedByUser(user.Id, postId))
            {
                db.Likes.Add(new Like() { FK_Users_Id = user.Id, FK_Posts_Id = postId });
                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Post is Liked");

            }
            else
            {
                var like = (from l in db.Likes where l.FK_Posts_Id == postId && l.FK_Users_Id == user.Id select l).FirstOrDefault();
                db.Likes.Remove(like);
                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Post is Uniked");

            }

        }
        public static bool IsPostLikedByUser(int uid, int postId)
        {
            return db.Likes.Any(l => l.FK_Posts_Id == postId && l.FK_Users_Id==uid);
        }
    }
}