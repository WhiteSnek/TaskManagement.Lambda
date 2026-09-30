using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using TaskManagement.Lambda.Services.Interface;

namespace TaskManagement.Lambda.Services
{
    public class FirebaseService : IFirebaseService
    {
        private readonly FirebaseMessaging _messaging;
        public FirebaseService(string serviceAccountJson)
        {
            var app = FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromJson(serviceAccountJson)
            });
            _messaging = FirebaseMessaging.GetMessaging(app);
        }

        public async Task<string> SendPushNotificationAsync(string token, string title, string body, Guid taskId)
        {
            var message = new Message
            {
                Token = token,
                Notification = new Notification
                {
                    Title = title,
                    Body = body
                },
                Data = new Dictionary<string, string>
                {
                    ["type"] = "TASK_REMINDER",
                    ["taskId"] = taskId.ToString()
                }
            };

            return await _messaging.SendAsync(message);
        }
    }
}
