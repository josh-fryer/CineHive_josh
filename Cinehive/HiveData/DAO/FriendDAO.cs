using HiveData.IDAO;
using HiveData.Models;
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
        public void AddFriend(string userId, string friendId, CineHiveContext context)
        {
            //string userid = HttpContext.Current.User.Identity.GetUserId();
            // find friend UserProfile
            var friend = context.UserProfiles.First(u => u.UserId == friendId);
            // find User's Userprofile
            var user = context.UserProfiles.First(u => u.UserId == userId);


            // Add friend UserProfile to current user's friends collection
            user.Friends.Add(friend);
            // add current User to Friend's friends collection
            friend.Friends.Add(user);

            // remove friend request from both collections
            foreach(var req in user.ReceivedFriendReq.ToList())
            {
                int reqID = req.Id;
                foreach(var fReq in friend.SentFriendReq.ToList())
                {
                    if (reqID == fReq.Id)
                    {
                        context.FriendRequests.Remove(context.FriendRequests.Find(reqID));                       
                    }
                }               
            }      
        }

        public void SendFriendReq(string userId, string friendId, CineHiveContext context)
        {
            var friend = context.UserProfiles.First(u => u.UserId == friendId);
            var user = context.UserProfiles.First(u => u.UserId == userId);
            // create request
            DateTime date = DateTime.Now;
            FriendRequest request = new FriendRequest()
            {
                DateSent = date,
                IsAccepted = false
            };

            friend.ReceivedFriendReq.Add(request);           
            context.SaveChanges(); // add request to db
            // add friend req to users sent collection
            user.SentFriendReq.Add(friend.ReceivedFriendReq.First(x => x.DateSent == date));
        }


    }
}
