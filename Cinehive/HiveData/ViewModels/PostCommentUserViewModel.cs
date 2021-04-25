using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HiveData.Models;
using HiveData.Repository;
using Microsoft.AspNet.Identity;

namespace HiveData.ViewModels
{
    public class PostCommentUserViewModel
    {
        CineHiveContext context = new CineHiveContext();

        public UserProfile UserProfile { get; set; }
        public Post Post { get; set; }
        public PostComment PostComment { get; set; }
        public IList<PostComment> CommentList { get; set; }


        public int GetCommProfileId(int id)
        {
            var profileid = context.UserProfiles.Where(c => c.Comments.Contains(context.PostComments.Where(i => i.CommentId == id).
                FirstOrDefault())).Select(v => v.ProfileId).FirstOrDefault();
            return profileid;
        }

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

        public bool AwardGiven(int id)
        {
            var postAwards = context.Awards.Where(a => a.Post.PostId == id).ToList();
            string userId = HttpContext.Current.User.Identity.GetUserId();
            var userProfile = context.UserProfiles.Where(u => u.UserId == userId).FirstOrDefault();
            if (postAwards.Count > 0)
            {
                if (userProfile.Awards.Intersect(postAwards).Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Get Post methods:
        public string GetPostFirstName(int id)
        {
            string Firstname = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.Firstname).FirstOrDefault();
            return Firstname;
        }

        public string GetPostLastName(int id)
        {
            string Lastname = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.Lastname).FirstOrDefault();
            return Lastname;
        }

        public string GetSharedUserPicture(int id)
        {
            string userpicture = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.ImagePath).FirstOrDefault();
            return userpicture;
        }

        public int GetAwards(int id)
        {
            var totalAwards = context.Awards.Where(a => a.Post.PostId == id).Count();
            return totalAwards;
        }

        public int GetProfileId(int id)
        {
            var profileid = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.ProfileId).FirstOrDefault();
            return profileid;
        }

        public bool IsUserPost(int id)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            var postUserID = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.UserId).FirstOrDefault();
            if (userid == postUserID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUserComment(int id)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            var commentUserID = context.UserProfiles.Where(c => c.Comments.Contains(context.PostComments.FirstOrDefault(i=>i.CommentId == id))).Select(j=>j.UserId).FirstOrDefault();
            if (userid == commentUserID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CommAwardGiven(int id)
        {
            var commentAwards = context.Awards.Where(a => a.PostComment.CommentId == id).ToList();
            string userId = HttpContext.Current.User.Identity.GetUserId();
            var userProfile = context.UserProfiles.Where(u => u.UserId == userId).FirstOrDefault();
            if (commentAwards.Count > 0)
            {
                if (userProfile.Awards.Intersect(commentAwards).Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int GetCommentAwards(int id)
        {
            var totalAwards = context.Awards.Where(a => a.PostComment.CommentId == id).Count();
            return totalAwards;
        }

    }
}
