using System;

namespace AndroidPushService
{
    class Program
    {
        /// <summary>
        /// This is the token of the device where test message is delivered
        /// Replace this with your own device token.
        /// </summary>
        private const string TestDeviceToken = "";

        /// <summary>
        /// Server key (from Firebase Cloud messaging console)
        /// </summary>
        private const string ServerKey = "";

        /// <summary>
        /// Sender ID  (from Firebase Cloud messaging console)
        /// </summary>
        private const long SenderId = 0;

        static void Main(string[] args)
        {
            var notificationService = new NotificationService(new NotificationServiceConfig(ServerKey, SenderId));

            try
            {
                notificationService.SendPushNotification("Hello world!", "What are you up to?", TestDeviceToken);
                Console.WriteLine("Successfully send");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stacktrace: {ex.StackTrace}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
