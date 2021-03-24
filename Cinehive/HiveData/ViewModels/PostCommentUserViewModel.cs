using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;
using HiveData.Repository;

namespace HiveData.ViewModels
{
    public class PostCommentUserViewModel
    {
        CineHiveContext context = new CineHiveContext();


        public UserProfile UserProfile { get; set; }
        public Post Post { get; set; }
        public PostComment PostComment { get; set; }
        public IList<PostComment> CommentList { get; set; }



        public string GetFirstName(int id)
        {

            string Firstname = context.UserProfiles.Where(c => c.Comments.Contains(context.PostComments.Where(i => i.CommentId == id).FirstOrDefault())).Select(v => v.Firstname).FirstOrDefault();

            return (Firstname);
        }
        public string GetLastName(int id)
        {
            string Lastname = context.UserProfiles.Where(c => c.Comments.Contains(context.PostComments.Where(i => i.CommentId == id).FirstOrDefault())).Select(v => v.Lastname).FirstOrDefault();
            return (Lastname);
        }
        public string GetUserPicture(int id)
        {
            string userpicture = context.UserProfiles.Where(c => c.Comments.Contains(context.PostComments.Where(i => i.CommentId == id).FirstOrDefault())).Select(v => v.ImagePath).FirstOrDefault();
            return (userpicture);
        }
    }
}
