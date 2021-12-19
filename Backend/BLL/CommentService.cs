using AutoMapper;
using BOL;
using BOL.Dto;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommentService
    {
        public static void AddComment(CommentDto comment)
        {
            DataAccessFactory.CommentDataAccess().Add(Mapper.Map<Comment>(comment));
        }

        public static CommentDto GetCommentById(int id)
        {
            var comments = DataAccessFactory.CommentDataAccess().Get().Select(Mapper.Map<Comment, CommentDto>);

            var data = (from c in comments
                        where c.Id == id
                        select c).FirstOrDefault();
            return data;
        }

        public static IEnumerable<CommentDto> GetCommentByPostId(int id)
        {
            var comments = DataAccessFactory.CommentDataAccess().Get().Select(Mapper.Map<Comment, CommentDto>);

            var data = (from c in comments
                        where c.FK_Posts_Id == id
                        select c);
            return data;
        }

        public static bool EditComment(CommentDto comment)
        {
            var _comment = DataAccessFactory.CommentDataAccess().Get(comment.Id);

            if (_comment == null) { return false; }
            else
            {
                DataAccessFactory.CommentDataAccess().Edit(Mapper.Map<CommentDto, Comment>(comment));
                return true;
            }
        }

        public static bool DeleteComment(int id)
        {
            var _comment = DataAccessFactory.CommentDataAccess().Get(id);

            if (_comment == null) { return false; }
            else
            {
                DataAccessFactory.CommentDataAccess().Delete(id);
                return true;
            }
        }
    }
}
