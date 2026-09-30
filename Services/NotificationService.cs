using TaskManagement.Lambda.Dtos;
using TaskManagement.Lambda.Services.Interface;

namespace TaskManagement.Lambda.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IFirebaseService _firebaseService;
        private readonly IUserService _userService;
        private readonly ITaskService _taskService;
        public NotificationService(IFirebaseService firebaseService, IUserService userService, ITaskService taskService)
        {
            _firebaseService = firebaseService;
            _userService = userService;
            _taskService = taskService;
        }
        public async Task<string> SendNotificationAsync(NotificationEvent input)
        {
            var taskId = input.TaskId;
            var taskDetails = await _taskService.GetTaskDetailsByTaskIdAsync(taskId);

            string title = taskDetails.Title;
            string body = taskDetails.Description;
            var userId = taskDetails.UserId;

            var token = await _userService.GetFirebaseTokenFromUserIdAsync(userId);

            var response = await _firebaseService.SendPushNotificationAsync(token, title, body, taskId);
            return response;
        }

    }
}
