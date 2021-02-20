using System.Collections.Generic;
using Craftsman.Domain.Bases;

namespace Craftsman.Domain.Interfaces
{
    public interface INotifications
    {
        bool HasNotifications();
        void AddNotification(List<Notification> notifications);
        void AddNotification(Notification notifications);
        void AddNotification(string key, string message);
        IReadOnlyCollection<Notification> GetNotifications();
    }
}