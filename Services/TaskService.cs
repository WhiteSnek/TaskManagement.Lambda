using TaskManagement.Lambda.Dtos;
using TaskManagement.Lambda.Repositories.Interface;
using TaskManagement.Lambda.Services.Interface;

namespace TaskManagement.Lambda.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<TaskDetailDto> GetTaskDetailsByTaskIdAsync(Guid taskId)
        {
            var task = await _taskRepository.GetTaskByTaskIdAsync(taskId);
            if(task == null)
            {
                throw new KeyNotFoundException("Task not found!");
            }
            var response = new TaskDetailDto
            {
                Title = task.Title,
                Description = task.Description,
                UserId = task.UserId
            };
            return response;
        }
    }
}
