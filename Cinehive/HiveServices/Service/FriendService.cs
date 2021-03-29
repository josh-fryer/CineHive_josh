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
        public void AddFriend(string userId, string friendId)
        {
            using (var context = new CineHiveContext())
            {
                friendDAO.AddFriend(userId, friendId, context);
                // send notification
                var user = context.UserProfiles.First(x => x.UserId == userId);
                string userName = user.Firstname + " " + user.Lastname;
                Notification n = notificationDAO.CreateNotification("addedFriend", userName, context);
                notificationDAO.AddNotificationToColl(friendId, n, context);
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
                string senderName = sender.Firstname + " " + sender.Lastname;
                Notification n = notificationDAO.CreateNotification("friendRequestRec", senderName, context);
                notificationDAO.AddNotificationToColl(friendId, n, context);
                context.SaveChanges();
            }
        }
    }
}
