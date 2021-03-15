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
        public Like like { get; set; }



        public string GetFirstName(int id)
        {
            string Firstname = context.UserProfiles.Where(c => c.ProfileId == id).Select(j => j.Firstname).FirstOrDefault();
            return (Firstname);
        }
        public string GetLastName(int id)
        {
            string Lastname = context.UserProfiles.Where(c => c.ProfileId == id).Select(j => j.Lastname).FirstOrDefault();
            return (Lastname);
        }
        public string GetUserPicture(int id)
        {
            string userpicture = context.UserProfiles.Where(c => c.ProfileId == id).Select(j => j.ImagePath).FirstOrDefault();
            return (userpicture);
        }
        public bool HasLiked()
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();

            var check = context.Likes.Where(c => c.UserId == userid).Select(j => j.LikeId);

            if (check == null)
            {
                return false;
            }

            return true;
        }
    }
}
