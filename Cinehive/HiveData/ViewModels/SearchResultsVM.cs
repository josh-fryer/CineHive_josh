using HiveData.Models;
using HiveData.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HiveData.ViewModels
{
    public class SearchResultsVM
    {
        public IList<Post> PostResults { get; set; }
        public IList<UserProfile> UserResults { get; set; }
        public IList<Movie> MovieResults { get; set; }
        public int totalMovieResults { get; set; } 

        private CineHiveContext context = new CineHiveContext();


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
            string userpicture = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.ImagePath).FirstOrDefault();
            return userpicture;
        }

        public bool IsUserPost(int id)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId(); // current user
            var postUserId = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id)
                .FirstOrDefault())).Select(v => v.UserId).FirstOrDefault();
            if (userid == postUserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetProfileId(int id)
        {
            var profileid = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.ProfileId).FirstOrDefault();
            return profileid;
        }

        public bool AwardGiven(int id)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            var postAwards = context.Awards.Where(a => a.Post.PostId == id).ToList();
            var userProfile = context.UserProfiles.Where(u => u.UserId == userid).FirstOrDefault();
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

        public int GetAwards(int id)
        {
            var totalAwards = context.Awards.Where(a => a.Post.PostId == id).Count();
            return totalAwards;
        }


        public UserProfile FindUserProfile(int id)
        {
            return context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id)
                .FirstOrDefault())).FirstOrDefault();
        }

        public int GetCommentsCount(int id)
        {
            int count = 0;
            count = context.Posts.Find(id).PostComments.Count;
            return count;
        }
    }
}
