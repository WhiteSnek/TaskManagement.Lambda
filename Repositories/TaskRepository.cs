using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Lambda.Data;
using TaskManagement.Lambda.Models;
using TaskManagement.Lambda.Repositories.Interface;

namespace TaskManagement.Lambda.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _dbContext;
        public TaskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskModel?> GetTaskByTaskIdAsync(Guid taskId)
        {
            var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
            return task;
        }
    }
}
