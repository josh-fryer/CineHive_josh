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
                var friend = context.UserProfiles.First(x => x.UserId == friendId);
                string friendName = friend.Firstname + " " + friend.Lastname;
                Notification n = notificationDAO.CreateNotification("addedFriend", friendName, context);
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
                var friend = context.UserProfiles.First(x => x.UserId == friendId);
                string friendName = friend.Firstname + " " + friend.Lastname;
                Notification n = notificationDAO.CreateNotification("friendRequestRec", friendName, context);
                notificationDAO.AddNotificationToColl(friendId, n, context);
                context.SaveChanges();
            }
        }
    }
}
