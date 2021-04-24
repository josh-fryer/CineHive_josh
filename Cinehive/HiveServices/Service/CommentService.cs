using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveServices.IService;
using HiveData.Models;
using HiveData.Repository;
using HiveData.DAO;
using HiveData.IDAO;
using HiveServices.Service;

namespace HiveServices.Service
{
    public class CommentService : ICommentService
    {
        private ICommentDAO commentDAO;

        public CommentService()
        {
            commentDAO = new CommentDAO();
        }

        public PostComment GetComment(int id)
        {
            using (var context = new CineHiveContext())
            {
                return commentDAO.GetComment(id, context);
            }
        }

        public void EditComment(PostComment postComment)
        {
            using (var context = new CineHiveContext())
            {
                commentDAO.EditComment(postComment, context);
            }
        }

        public void DeleteComment(int id)
        {
            using (var context = new CineHiveContext())
            {
                PostComment postComment = commentDAO.GetComment(id, context);
                commentDAO.DeleteCommentAwards(postComment, context);
                commentDAO.DeleteComment(postComment, context);

                context.SaveChanges();
            }
        }

        public void RevokeAward(int id, string userId)
        {
            using (var context = new CineHiveContext())
            {
                commentDAO.RevokeAward(id, userId, context);
                context.SaveChanges();
            }
        }

        public void GiveAward(int id, string userId)
        {
            using (var context = new CineHiveContext())
            {
                commentDAO.GiveAward(id, userId, context);
                context.SaveChanges();
            }
        }

    }
}
