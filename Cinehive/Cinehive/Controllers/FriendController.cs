using HiveServices.IService;
using HiveServices.Service;
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

        public FriendController()
        {
            friendService = new FriendService();
        }

        public ActionResult AddFriend(string friendId)
        {
            friendService.AddFriend(friendId);
            // redirect to notifications
            return RedirectToAction("Index", "Notification");
        }

        public ActionResult SendFriendReq(int friendProfileId,string friendUserId)
        {
            friendService.SendFriendReq(friendUserId);
            // redirect to same friend profile
            return RedirectToAction("ViewProfile", "Profile", new { id = friendProfileId });
        }



        public ActionResult RemoveFriend()
        {
            // remove friend from current users friends collection
            // !Not implemented yet!
            return View();
        }

    }
}