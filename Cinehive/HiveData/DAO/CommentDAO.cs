using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.IDAO;
using HiveData.Models;
using HiveData.Repository;

namespace HiveData.DAO
{
    public class CommentDAO : ICommentDAO
    {
        public PostComment GetComment(int id, CineHiveContext context)
        {
            return context.PostComments.Find(id);
        }
        public void EditComment(PostComment postComment, CineHiveContext context)
        {
            postComment.Edited = true;
            postComment.DateCommented = DateTime.Now;
            context.Entry(postComment).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteComment(PostComment postComment, CineHiveContext context)
        {
            context.PostComments.Remove(postComment);
            context.SaveChanges();
        }

    }
}
