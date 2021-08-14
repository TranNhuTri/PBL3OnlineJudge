using System.Collections.Generic;
using PBL3.Models;

namespace PBL3.Features.NotificationManagement
{
    public interface INotificationService
    {
        List<Notification> GetAllNotifications();
        Notification GetNotificationByID(int notificationID);
        void AddNotification(Notification notification);
        void UpdateNotification(Notification notification);
    }
}