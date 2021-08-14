using System.Collections.Generic;
using System.Linq;
using PBL3.Models;
using PBL3.Repositories;

namespace PBL3.Features.NotificationManagement
{
    public class NotificationService: INotificationService
    {
        private readonly IRepository<Notification> _notificationRepo;
        public NotificationService(IRepository<Notification> notificationRepo)
        {
            _notificationRepo = notificationRepo;
        }
        public List<Notification> GetAllNotifications()
        {
            return _notificationRepo.GetAll().ToList();
        }
        public Notification GetNotificationByID(int notificationID)
        {
            return _notificationRepo.GetById(notificationID);
        }
        public void AddNotification(Notification notification)
        {
            _notificationRepo.Insert(notification);
            _notificationRepo.Save();
        }
        public void UpdateNotification(Notification notification)
        {
            _notificationRepo.Update(notification);
            _notificationRepo.Save();
        }
    }
}