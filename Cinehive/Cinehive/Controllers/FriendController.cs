using HiveData.Repository;
using HiveServices.IService;
using HiveServices.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinehive.Controllers
{
    public class FriendController : Controller
    {
        private IFriendService friendService;
        private INotificationService notificationService;

        public FriendController()
        {
            friendService = new FriendService();
            notificationService = new NotificationService();
        }

        public ActionResult AddFriend(string friendId)
        {
            friendService.AddFriend(User.Identity.GetUserId(), friendId);
            // redirect to notifications
            return RedirectToAction("Index", "Notification");
        }

        public ActionResult SendFriendReq(int friendProfileId, string friendUserId)
        {
            friendService.SendFriendReq(User.Identity.GetUserId(), friendUserId);
            // redirect to same friend profile
            return RedirectToAction("ViewProfile", "Profile", new { id = friendProfileId });
        }

        public ActionResult Remove(int friendProfileId, string friendUserId)
        {
            RemoveFriend(User.Identity.GetUserId(), friendUserId);
            return RedirectToAction("ViewProfile", "Profile", new { id = friendProfileId });
        }

        public void RemoveFriend(string friendId, string userId)
        {
            CineHiveContext context = new CineHiveContext();
            var friend = context.UserProfiles.First(u => u.UserId == friendId);
           
            var user = context.UserProfiles.First(u => u.UserId == userId);

            user.Friends.Remove(friend);
            friend.Friends.Remove(user);
            context.SaveChanges();
           
            //return RedirectToAction("Index", "Notification");

        }

    }
}