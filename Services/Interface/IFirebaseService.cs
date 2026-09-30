using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Lambda.Services.Interface
{
    public interface IFirebaseService
    {
        Task<string> SendPushNotificationAsync(string token, string title, string body, Guid taskId);
    }
}
