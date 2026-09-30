using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManagement.Lambda.Dtos
{
    public class NotificationEvent
    {
        [Required]
        public Guid TaskId { get; set; }
    }
}
