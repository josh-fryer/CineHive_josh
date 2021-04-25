using HiveData.Models;
using HiveData.Repository;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HiveData.ViewModels
{
    public class FilteredSearchVM
    {
        public IPagedList<Post> PostList { get; set; }
        public IList<Movie> MovieList { get; set; }
        public IPagedList<UserProfile> UserList { get; set; }

        CineHiveContext context = new CineHiveContext();

        public string GetUserPicture(int id)
        {
            string userpicture = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.ImagePath).FirstOrDefault();
            return (userpicture);
        }

        public string GetFirstName(int id)
        {
            string Firstname = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.Firstname).FirstOrDefault();

            return (Firstname);
        }

        public string GetLastName(int id)
        {
            string Lastname = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.Lastname).FirstOrDefault();
            return (Lastname);
        }

        public int GetProfileId(int id)
        {
            var profileid = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.ProfileId).FirstOrDefault();
            return (profileid);
        }

        public bool IsUserPost(int id)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();
            var profileid = context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id).FirstOrDefault())).Select(v => v.UserId).FirstOrDefault();
            if (userid == profileid)
            {
                return true;
            }
            else
            {
                return false;
            }
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

        public UserProfile FindUserProfile(int id)
        {
            return context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id)
                .FirstOrDefault())).FirstOrDefault();
        }

        public int GetAwards(int id)
        {
            var totalAwards = context.Awards.Where(a => a.Post.PostId == id).Count();
            return totalAwards;
        }

        public int GetCommentsCount(int id)
        {
            int count = 0;
            count = context.Posts.Find(id).PostComments.Count;
            return count;
        }
    }

}

