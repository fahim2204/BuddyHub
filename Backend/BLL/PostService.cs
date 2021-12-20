using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BOL;
using BOL.Dto;
using DAL;

namespace BLL
{
    public class PostService
    {
        public static void Add(PostDto post)
        {
            DataAccessFactory.PostDataAccess().Add(Mapper.Map<Post>(post));
        }

        public static IEnumerable<PostDto> GetAllPost()
        {
            var po = new List<PostDto>();
            var posts =  DataAccessFactory.PostDataAccess().Get().Select(Mapper.Map<Post, PostDto>);
            foreach(var p in posts)
            {
                var user = UserService.GetUserById(p.FK_Users_Id);
                var comments = CommentService.GetCommentByPostId(p.Id);
                var likes = LikeService.GetLikeByPostId(p.Id);
                p.Name = user.Name;
                p.Username = user.Username;
                p.CommentCount = comments.Count();
                p.LikeCount = likes.Count();
                po.Add(p);
            }
            return po;
        }

        public static PostDto GetPostById(int id)
        {
            var posts = DataAccessFactory.PostDataAccess().Get().Select(Mapper.Map<Post, PostDto>);

            var data = (from p in posts
                        where p.Id == id
                        select p).FirstOrDefault();
            var user = UserService.GetUserById(data.FK_Users_Id);
            var comments = CommentService.GetCommentByPostId(data.Id);
            var likes = LikeService.GetLikeByPostId(data.Id);
            data.Name = user.Name;
            data.Username = user.Username;
            data.CommentCount = comments.Count();
            data.LikeCount = likes.Count();
            return data;
        }

        public static IEnumerable<PostDto> GetPostByUserId(int id)
        {
            var posts = DataAccessFactory.PostDataAccess().Get().Select(Mapper.Map<Post, PostDto>);

            var data = (from p in posts
                        where p.FK_Users_Id == id
                        select p);
            var po = new List<PostDto>();
            foreach (var p in data)
            {
                var user = UserService.GetUserById(p.FK_Users_Id);
                var comments = CommentService.GetCommentByPostId(p.Id);
                var likes = LikeService.GetLikeByPostId(p.Id);
                p.Name = user.Name;
                p.Username = user.Username;
                p.CommentCount = comments.Count();
                p.LikeCount = likes.Count();
                po.Add(p);
            }
            return po;
        }

        public static bool EditPost(PostDto post)
        {
            var _post = DataAccessFactory.PostDataAccess().Get(post.Id);

            if (_post == null) { return false; }
            else
            {
                DataAccessFactory.PostDataAccess().Edit(Mapper.Map<PostDto, Post>(post));
                return true;
            }
        }

        public static bool DeletePost(int id)
        {
            var _post = DataAccessFactory.PostDataAccess().Get(id);

            if (_post == null) { return false; }
            else
            {
                DataAccessFactory.PostDataAccess().Delete(id);
                return true;
            }
        }
    }
}
