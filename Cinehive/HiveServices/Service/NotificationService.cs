﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveServices.IService;
using HiveData.Repository;
using HiveData.Models;
using HiveData.DAO;
using HiveData.IDAO;

namespace HiveServices.Service
{
    public class NotificationService : INotificationService
    {
        private INotificationDAO notificationDAO;
        
        public NotificationService()
        {
            notificationDAO = new NotificationDAO();
        }
        public Notification GetNotification(int id)
        {
            using (var context = new CineHiveContext())
            {
                return notificationDAO.GetNotification(id, context);
            }
        }
        public IList<Notification> GetUserNotifications()
        {
            using (var context = new CineHiveContext())
            {
                return notificationDAO.GetUserNotifications(context);
            }
        }
        public void DeleteNotification(int id)
        {
            using (var context = new CineHiveContext())
            {
                Notification notification = notificationDAO.GetNotification(id, context);
                notificationDAO.DeleteNotification(notification, context);
            }
        }
    }
}
