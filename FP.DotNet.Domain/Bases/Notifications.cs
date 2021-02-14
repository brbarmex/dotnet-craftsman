namespace FP.DotNet.Domain.Bases
{
    public class Notifications
    {
        public Notifications(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; }
        public string Message { get; }
    }
}