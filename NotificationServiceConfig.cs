
namespace AndroidPushService
{
    /// <summary>
    /// Configuration of the notification service. To get data see Project details of your Firebase app - https://console.firebase.google.com/
    /// </summary>
    public class NotificationServiceConfig
    {
        /// <summary>
        /// Server key 
        /// </summary>
        public string ServerKey { get; }

        /// <summary>
        /// Sender ID
        /// </summary>
        public long SenderId { get; }

        public NotificationServiceConfig(string serverKey, long senderId)
        {
            ServerKey = serverKey;
            SenderId = senderId;
        }
    }
}
