using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiveData.Repository;
using HiveData.Models;
using Microsoft.AspNet.Identity;

namespace Cinehive.Controllers
{
    public class NotificationController : Controller
    {
        private readonly CineHiveContext context = new CineHiveContext();

        [Authorize]
        public ActionResult Index()
        {
            string userid = User.Identity.GetUserId();

            var UserNotifications = context.Notifications.Where(c => c.ReceiverId == userid).OrderByDescending(c => c.DateReceived);

            return View(UserNotifications.ToList());
        }
        public ActionResult TestSendNotification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TestSendNotification(Notification notification)
        {
            
            string userid = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                notification = new Notification()
                {
                    SenderId = userid,
                    ReceiverId = userid,
                    DateReceived = DateTime.Now,
                    IsRead = false,
                    Message = notification.Message,
                };

                context.Notifications.Add(notification);
                context.SaveChanges();

            }      

           
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DeleteNotification(int? id)
        {
            Notification notification = context.Notifications.Find(id);

            context.Notifications.Remove(notification);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}