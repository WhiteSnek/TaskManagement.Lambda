using Microsoft.EntityFrameworkCore;
using TaskManagement.Lambda.Models;

namespace TaskManagement.Lambda.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
