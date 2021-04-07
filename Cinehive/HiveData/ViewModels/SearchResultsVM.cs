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

        public bool AwardGiven(int id)
        {
            var award = context.UserProfiles.Where(c => c.Awards.Contains(context.Awards.Where(i => i.PostId == id).
                FirstOrDefault())).Select(v => v.UserId).FirstOrDefault();
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
             //int id = context.Posts.Find(post.PostId);
             //UserProfile userProfile =
                    //context.UserProfiles.FirstOrDefault(x => x.Posts.Contains(context.Posts.Find(id)));

            return context.UserProfiles.Where(c => c.Posts.Contains(context.Posts.Where(i => i.PostId == id)
                .FirstOrDefault())).FirstOrDefault();
        }

    }


}
