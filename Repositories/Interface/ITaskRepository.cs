using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Lambda.Models;

namespace TaskManagement.Lambda.Repositories.Interface
{
    public interface ITaskRepository
    {
        Task<TaskModel?> GetTaskByTaskIdAsync(Guid taskId);
    }
}
