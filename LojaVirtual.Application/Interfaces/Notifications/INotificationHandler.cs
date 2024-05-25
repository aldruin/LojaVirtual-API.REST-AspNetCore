using LojaVirtual.Domain.Notifications;

namespace LojaVirtual.Application.Interfaces.Notifications;

public interface INotificationHandler
{
    List<Notification> GetNotifications();
    bool HasNotification();
    bool AddNotification(Notification notification);
    bool AddNotification(string key, string message);
}