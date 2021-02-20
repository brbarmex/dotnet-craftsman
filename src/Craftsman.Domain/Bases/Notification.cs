namespace Craftsman.Domain.Bases
{
    public sealed class Notification
    {
        public Notification(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; }
        public string Message { get; }
    }
}