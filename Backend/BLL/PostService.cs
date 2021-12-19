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
            /* var config = new MapperConfiguration(cfg => cfg.CreateMap<PostDto, Post>());
             var mapper = new Mapper(config);*/
            DataAccessFactory.PostDataAccess().Add(Mapper.Map<Post>(post));
        }

        public static IEnumerable<PostDto> GetAllPost()
        {
            return DataAccessFactory.PostDataAccess().Get().Select(Mapper.Map<Post, PostDto>);
        }

        public static IEnumerable<PostDto> GetPostById(int id)
        {
            var posts = DataAccessFactory.PostDataAccess().Get().Select(Mapper.Map<Post, PostDto>);

            var data = (from p in posts
                        where p.Id == id
                        select p);
            return data;
        }

        public static IEnumerable<PostDto> GetPostByUserId(int id)
        {
            var posts = DataAccessFactory.PostDataAccess().Get().Select(Mapper.Map<Post, PostDto>);

            var data = (from p in posts
                        where p.FK_Users_Id == id
                        select p);
            return data;
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
