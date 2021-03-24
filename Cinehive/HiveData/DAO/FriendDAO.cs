using HiveData.IDAO;
using HiveData.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HiveData.DAO
{
    public class FriendDAO : IFriendDAO
    {
        public void AddFriend(string friendUserId, CineHiveContext context)
        {
            // find friend UserProfile
            var friend = context.UserProfiles.First(u => u.UserId == friendUserId);

            // get current userId
            string userid = HttpContext.Current.User.Identity.GetUserId();
            // Add friend UserProfile to current user's friends collection
            context.UserProfiles.First(u => u.UserId == userid).Friends.Add(friend);
            context.SaveChanges();
        }
    }
}
