using System.Collections.Generic;
using Craftsman.Shared.Bases;

namespace Craftsman.Shared.Interfaces
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