using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Lambda.Dtos;
using TaskManagement.Lambda.Services.Interface;

namespace TaskManagement.Lambda.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IFirebaseService _firebaseService;
        public NotificationService(IFirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }
        public async Task<string> SendNotificationAsync(NotificationEvent input)
        {
            var taskId = input.TaskId;
            var token = Environment.GetEnvironmentVariable("FCM_TOKEN");
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException(
                    "FCM_TOKEN environment variable is not configured.");
            }
            string title = "Test Task";
            string body = "Test body";
            var response = await _firebaseService.SendPushNotificationAsync(token, title, body, taskId);
            return response;
        }

    }
}
