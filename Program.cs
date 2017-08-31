namespace AndroidPushService
{
    class Program
    {
        /// <summary>
        /// This is the token of the device where test message is delivered
        /// Replace this with your own device token.
        /// </summary>
        private const string TestDeviceToken = "eP1yB2dxYb0:APA91bFTKbq1bzO2IOORq8r5Urz5D7AuoS7-1RAqacIYmh3s6F5jiNNFb__HB-O9Hcqug5kIzWcibxYycfS-nzQWseue3CrT1sOA1J_bmIzBDoDJPsSGvhPo88gzpLWD_8_pFvOvR-dT";

        /// <summary>
        /// Server key (from Firebase Cloud messaging console)
        /// </summary>
        private const string ServerKey = "AAAAhNNQjeY:APA91bHGy7kgUuuy9h6ZTHGXFK8Zieg6GMnWjkdMmWyiboWyg1fcxag6W8kOWWeGakK6euXj2nVNgA4VCK8ZYe4x25dQvlMIxiPSR_dUzpA7TVrMYPvMPnXR6hlZeml0_z-mTVmvKqoD";

        /// <summary>
        /// Sender ID  (from Firebase Cloud messaging console)
        /// </summary>
        private const long SenderId = 570480954854;

        static void Main(string[] args)
        {
            var notificationService = new NotificationService(new NotificationServiceConfig(ServerKey, SenderId));

            notificationService.SendPushNotification("Hello world!", "What are you up to?", TestDeviceToken);
        }
    }
}
