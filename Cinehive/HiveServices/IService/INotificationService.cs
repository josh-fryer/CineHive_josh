using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveData.Models;

namespace HiveServices.IService
{
    public interface INotificationService
    {
        Notification GetNotification(int id);
        Notification CreateNotification(string type, string msgDetail, UserProfile profile);
        IList<Notification> GetUserNotifications();
        void DeleteNotification(int id);
    }
}
