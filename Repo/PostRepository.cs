﻿using BuddyHub.Models.EntityFramework;
using BuddyHub.Models.VirtualModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyHub.Repo
{
    public class PostRepository
    {
        static buddyhubEntities db;
        static PostRepository()
        {
            db = new buddyhubEntities();
        }
        public List<PostData> GetPostData()
        {
            var posts = (from u in db.Users
                         join p in db.Posts on u.Id equals p.FK_Users_Id
                         select new PostData()
                         {
                             PostId = p.Id,
                             PostText = p.PostsText,
                             CreatedAt = (DateTime)p.CreatedAt,
                             Status = (int)p.Status,
                             Username = u.Username
                         }).ToList();
            return posts;
        }
        public PostData GetPostDataById(int id)
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
    }
}