using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Lambda.Dtos;

namespace TaskManagement.Lambda.Services.Interface
{
    public interface ITaskService
    {
        Task<TaskDetailDto> GetTaskDetailsByTaskIdAsync(Guid taskId);
    }
}
