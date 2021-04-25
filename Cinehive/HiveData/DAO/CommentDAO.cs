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
        }

        public void DeleteCommentAwards(PostComment postComment, CineHiveContext context)
        {
            var awards = context.Awards.Where(a => a.PostComment.CommentId == postComment.CommentId).ToList();
            if (awards.Count >= 1)
            {
                context.Awards.RemoveRange(awards);
            }           
        }

        public void GiveAward(int id, string userId, CineHiveContext context)
        {
            UserProfile profile = context.UserProfiles.First(x => x.UserId == userId);
            PostComment comment = context.PostComments.Find(id);
            Award award = new Award();

            comment.Awards++;
            award.PostComment = comment;

            profile.Awards.Add(award);
        }

        public void RevokeAward(int id, string userId, CineHiveContext context)
        {
            UserProfile profile = context.UserProfiles.First(x => x.UserId == userId);
            PostComment comment = context.PostComments.Find(id);
            Award award = profile.Awards.Where(x => x.PostComment == comment).FirstOrDefault();

            comment.Awards--;

            profile.Awards.Remove(award);
            context.Awards.Remove(award);
        }

    }
}
