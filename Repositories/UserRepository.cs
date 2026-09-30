using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManagement.Lambda.Data;
using TaskManagement.Lambda.Models;
using TaskManagement.Lambda.Repositories.Interface;

namespace TaskManagement.Lambda.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserModel?> GetUserByUserIdAsync(Guid userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }
    }
}
