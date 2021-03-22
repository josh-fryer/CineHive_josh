using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HiveData.IDAO;
using HiveData.Models;
using HiveData.Repository;
using Microsoft.AspNet.Identity;

namespace HiveData.DAO
{
    public class NotificationDAO : INotificationDAO
    {
        public Notification GetNotification(int id, CineHiveContext context)
        {
            return context.Notifications.Find(id);
        }
        public IList<Notification> GetUserNotifications(CineHiveContext context)
        {
            string userid = HttpContext.Current.User.Identity.GetUserId();

            var UserNotifications = context.UserProfiles.Where(c => c.UserId == userid).FirstOrDefault();
            var resultNotification = UserNotifications.Notifications.ToList();

            return resultNotification; 
        }
        public void DeleteNotification(Notification notification, CineHiveContext context)
        {
            context.Notifications.Remove(notification);
            context.SaveChanges();
        }
    }
}
