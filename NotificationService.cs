
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace AndroidPushService
{
    public class NotificationService : INotificationService
    {
        private NotificationServiceConfig Config { get; }

        private const string FirebaseSendEndpoint = "https://fcm.googleapis.com/fcm/send";

        public NotificationService(NotificationServiceConfig config)
        {
            Config = config;
        }

        public void SendPushNotification(string title, string body, string deviceToken, NotificationConfig notificationConfig = null)
        {

            if (notificationConfig == null)
            {
                notificationConfig = new NotificationConfig();
            }

            var serializer = new JavaScriptSerializer();

            WebRequest request = WebRequest.Create(FirebaseSendEndpoint);
            request.Method = "post";
            request.ContentType = "application/json";
            var data = new
            {
                to = deviceToken,
                notification = new
                {
                    body,
                    title,
                    sound = !string.IsNullOrEmpty(notificationConfig.Sound) ? "Default" : notificationConfig.Sound

                }
            };

            var json = serializer.Serialize(data);
            Byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.Headers.Add($"Authorization: key={Config.ServerKey}");
            request.Headers.Add($"Sender: id={Config.SenderId}");
            request.ContentLength = byteArray.Length;

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = request.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse == null)
                        {
                            throw new NullReferenceException(nameof(dataStreamResponse));
                        }
                    }
                }
            }
        }
    }
}
