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
    public class ProfilePostsViewModel
    {
        CineHiveContext context = new CineHiveContext();

        public UserProfile userProfile { get; set; }
        public IList<Post> Posts { get; set; }
        public IList<PostComment> PostComments { get; set; }
        public Post Post { get; set; }
        public PostComment PostComment { get; set; }


        public string GetFirstName(int id)
        {
            string Firstname = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).
                FirstOrDefault())).Select(v => v.Firstname).FirstOrDefault();
            return Firstname;
        }

        public string GetLastName(int id)
        {
            string Lastname = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).
                FirstOrDefault())).Select(v => v.Lastname).FirstOrDefault();
            return Lastname;
        }

        public string GetUserPicture(int id)
        {
            string userpicture = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).
                FirstOrDefault())).Select(v => v.ImagePath).FirstOrDefault();
            return userpicture;
        }

        public int GetAwards(int id)
        {
            var totalAwards = context.Awards.Where(a => a.Post.PostId == id).Count();
            return totalAwards;
        }

        public int GetPostId(int id)
        {
            var post = context.Posts.Where(c => c.PostComments.Contains(context.PostComments.Where(i => i.CommentId == id).
                FirstOrDefault())).Select(v => v.PostId).FirstOrDefault();
            return post;
        }

        public int GetProfileId(int id)
        {
            var profileid = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.ProfileId).FirstOrDefault();
            return profileid;
        }

        public bool AwardGiven(int id)
        {
            var award = context.UserProfiles.Where(c => c.Awards.Contains(context.Awards.Where(i => i.Post.PostId == id).FirstOrDefault())).Select(v => v.UserId).FirstOrDefault();

            if (award == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
