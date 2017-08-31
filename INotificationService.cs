
namespace AndroidPushService
{
    public interface INotificationService
    {
        /// <summary>
        /// Sends push notification to given Android device.
        /// To get/send token see your FirebaseInstanceIdService onTokenRefresh and sendRegistrationToServer methods (in Android project)
        /// </summary>
        /// <param name="deviceToken">Token of the device</param>
        /// <param name="title">Title of the notification body</param>
        /// <param name="body">Message of the notification</param>
        /// <param name="notificationConfig">Config of the notification (https://firebase.google.com/docs/cloud-messaging/http-server-ref)</param>
        /// 
        void SendPushNotification(string title, string body, string deviceToken, NotificationConfig notificationConfig = null);
    }
}
