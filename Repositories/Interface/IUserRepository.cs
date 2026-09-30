using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Lambda.Models;

namespace TaskManagement.Lambda.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<UserModel?> GetUserByUserIdAsync(Guid userId);
    }
}
