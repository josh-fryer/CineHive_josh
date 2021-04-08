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
        // msgDetail for personalized info inside message.
        // UserProfile is optional.
        public Notification CreateNotification(string type, string msgDetail, UserProfile profile, CineHiveContext context)
        {
            Notification notification = new Notification();
            switch (type)
            {
                case "addedFriend":
                    notification.DateReceived = DateTime.Now;
                    notification.IsRead = false;
                    notification.Message = msgDetail + " accepted your friend request!";
                    notification.Type = type;                    
                    break;
                case "friendRequestRec":
                    notification.DateReceived = DateTime.Now;
                    notification.IsRead = false;
                    notification.Message = "You have received a friend request from " + msgDetail;
                    notification.Type = type;
                    notification.senderProfileID = profile.ProfileId;
                    break;
                default:
                    break;
            }

            return notification;
        }

        public void AddNotificationToColl(string userId, Notification n, CineHiveContext context)
        {
            context.UserProfiles.First(x=>x.UserId == userId).Notifications.Add(n);
        }

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
        }
    }
}
