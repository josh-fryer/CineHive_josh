using HiveData.DAO;
using HiveData.IDAO;
using HiveData.Models;
using HiveData.Repository;
using HiveServices.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveServices.Service
{
    public class FriendService : IFriendService
    {
        private IFriendDAO friendDAO;
        private INotificationDAO notificationDAO;

        public FriendService()
        {
            friendDAO = new FriendDAO();
            notificationDAO = new NotificationDAO();
        }

        // when user clicks on accept on request do this
        public void AddFriend(string userId, int friendProfileId)
        {
            using (var context = new CineHiveContext())
            {         
                // get user profiles
                var user = context.UserProfiles.First(x => x.UserId == userId);
                var reqSender = context.UserProfiles.Find(friendProfileId);
                friendDAO.AddFriend(userId, reqSender.UserId, context);

                // delete any notification of add friend request from user
                var reqNotification = user.Notifications.FirstOrDefault(x => x.senderProfileID == friendProfileId);
                if (reqNotification != null)
                {
                    context.Notifications.Remove(reqNotification);
                }          

                // send notification
                string userName = user.Firstname + " " + user.Lastname;
                Notification n = notificationDAO.CreateNotification("addedFriend", userName, null, context);
                notificationDAO.AddNotificationToColl(reqSender.UserId, n, context);
                context.SaveChanges();
            }
        }

        public void SendFriendReq(string userId, string friendId)
        {
            using (var context = new CineHiveContext())
            {
                friendDAO.SendFriendReq(userId, friendId, context);
                // send notification
                var sender = context.UserProfiles.First(x => x.UserId == userId);
                var receiver = context.UserProfiles.First(u => u.UserId == friendId);
                string senderName = sender.Firstname + " " + sender.Lastname;
                Notification n = notificationDAO.CreateNotification("friendRequestRec", senderName, sender, context);
                notificationDAO.AddNotificationToColl(friendId, n, context);
                context.SaveChanges();
            }
        }

        public void RemoveFriend(string friendId, string userId)
        {
            using (var context = new CineHiveContext())
            {
                friendDAO.RemoveFriend(friendId, userId, context);
                context.SaveChanges();
            }
        }
    }
}
