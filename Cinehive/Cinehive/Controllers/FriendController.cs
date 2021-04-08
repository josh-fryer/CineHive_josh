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

        public ActionResult AddFriend(int friendId)
        {
            friendService.AddFriend(User.Identity.GetUserId(), friendId);           
            // redirect user to same page user is on. with JS?
            return RedirectToAction("Index", "Home");
        }

        // for accepting from notification
        public ActionResult AcceptFriendReq(int friendId)
        {
            friendService.AddFriend(User.Identity.GetUserId(), friendId);
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
            friendService.RemoveFriend(User.Identity.GetUserId(), friendUserId);
            return RedirectToAction("ViewProfile", "Profile", new { id = friendProfileId });
        }

    }
}