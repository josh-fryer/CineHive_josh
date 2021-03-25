using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiveData.Repository;
using HiveData.Models;
using Microsoft.AspNet.Identity;
using HiveServices.IService;
using HiveServices.Service;

namespace Cinehive.Controllers
{
    public class NotificationController : Controller
    {
        private readonly CineHiveContext context = new CineHiveContext();
        private INotificationService notificationService;

        public NotificationController()
        {
            notificationService = new NotificationService();
        }

        [Authorize]
        public ActionResult Index() // returns view of all notifications
        {
            return View(notificationService.GetUserNotifications());
        }

        public ActionResult TestSendNotification()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestSendNotification(Notification notification) //Temporary action
        {         
            string userid = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                UserProfile userProfile = context.UserProfiles.First(c => c.UserId == userid);
                notification = new Notification()
                {
                    DateReceived = DateTime.Now,
                    IsRead = false,
                    Message = notification.Message,
                };

                userProfile.Notifications.Add(notification);
                context.SaveChanges();

            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteNotification(int id)
        {
            try
            {
                notificationService.DeleteNotification(id);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction(""); //error page
            }

        }
    }
}