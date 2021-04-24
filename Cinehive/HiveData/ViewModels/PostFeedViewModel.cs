using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;
using HiveData.Repository;
using PagedList;
using Microsoft.AspNet.Identity;
using System.Web;

namespace HiveData.ViewModels
{ 
    public class PostFeedViewModel
    {
        CineHiveContext context = new CineHiveContext();

        public UserProfile UserProfile { get; set; }
        public IPagedList<Post> PostList { get; set; }
        public Post Post { get; set; }
        public PostComment PostComment { get; set; }
        public IList<PostComment> CommentList { get; set; }

        public string GetFirstName(int id)
        {
            string Firstname = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.Firstname).FirstOrDefault();          
            return Firstname;
        }

        public string GetLastName(int id)
        {
            string Lastname = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.Lastname).FirstOrDefault();
            return Lastname;
        }

        public string GetUserPicture(int id)
        {
            string userpicture = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.ImagePath).FirstOrDefault();
            return userpicture;
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

        // check if user has given award to post
        public bool AwardGiven(int id)
        {
            var postAwards = context.Awards.Where(a => a.Post.PostId == id).ToList();
            var userProfile = context.UserProfiles.Find(UserProfile.ProfileId);
            if (postAwards.Count > 0)
            {
                if(userProfile.Awards.Intersect(postAwards).Any())
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

        public int GetAwards(int id)
        {
            var totalAwards = context.Awards.Where(a => a.Post.PostId == id).Count();
            return totalAwards;
        }

        public int GetPostId(int id)
        {
            var post = context.Posts.Where(c => c.PostComments.Contains(context.PostComments.Where(i => i.CommentId == id).FirstOrDefault())).Select(v => v.PostId).FirstOrDefault();

            return post;
        }

        //for comments
        public string CommentFirstName(int id)
        {

            string Firstname = context.UserProfiles.Where(c => c.Comments.Contains(context.PostComments.Where(i => i.CommentId == id).FirstOrDefault())).Select(v => v.Firstname).FirstOrDefault();

            return (Firstname);
        }

        public string CommentLastName(int id)
        {
            string Lastname = context.UserProfiles.Where(c => c.Comments.Contains(context.PostComments.Where(i => i.CommentId == id).FirstOrDefault())).Select(v => v.Lastname).FirstOrDefault();
            return (Lastname);
        }

        public string CommentPicture(int id)
        {
            string userpicture = context.UserProfiles.Where(c => c.Comments.Contains(context.PostComments.Where(i => i.CommentId == id).FirstOrDefault())).Select(v => v.ImagePath).FirstOrDefault();
            return (userpicture);
        }

        public int GetCommentsCount(int id)
        {
            int count = 0;
            count = context.Posts.Find(id).PostComments.Count;
            return count;
        }
    }
}
