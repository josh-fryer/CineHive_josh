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

        public ActionResult AddFriend(string userId)
        {
            // add friend to current users friends collection
            return View();
        }

        public ActionResult RemoveFriend()
        {
            // remove friend from current users friends collection
            // !Not implemented yet!
            return View();
        }

    }
}