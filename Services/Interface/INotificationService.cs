using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Lambda.Dtos;

namespace TaskManagement.Lambda.Services.Interface
{
    public interface INotificationService
    {
        Task<string> SendNotificationAsync(NotificationEvent input); 
    }
}
