using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Lambda.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public required string IdpUserId { get; set; }
        public required string FullName { get; set; }
        public string FirebaseToken { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
