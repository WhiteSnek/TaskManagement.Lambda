using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Lambda.Dtos
{
    public class TaskDetailDto
    {
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public required Guid UserId;
    }
}
