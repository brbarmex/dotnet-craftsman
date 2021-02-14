using System.Collections.Generic;
using FP.DotNet.Domain.Bases;

namespace FP.DotNet.Shared.Interfaces
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