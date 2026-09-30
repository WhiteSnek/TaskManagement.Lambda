using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManagement.Lambda.Services.Interface
{
    public interface IUserService
    {
        Task<string> GetFirebaseTokenFromUserIdAsync(Guid userId);
    }
}
