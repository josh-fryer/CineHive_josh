using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.DAO;
using HiveData.Models;
using HiveData.Repository;

namespace HiveData.IDAO
{
    public interface INotificationDAO
    {
        Notification GetNotification(int id, CineHiveContext context);
        IList<Notification> GetUserNotifications(CineHiveContext context);
        void DeleteNotification(Notification notification, CineHiveContext context);
        Notification CreateNotification(string type, string msgDetail,
            UserProfile profile,CineHiveContext context);
        void AddNotificationToColl(string userId, Notification n, CineHiveContext context);


    }
}
