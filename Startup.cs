using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Lambda.Services;
using TaskManagement.Lambda.Services.Interface;
using TaskManagement.Lambda.Data;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Lambda.Repositories.Interface;
using TaskManagement.Lambda.Repositories;

namespace TaskManagement.Lambda
{
    public static class Startup
    {
        public static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            var firebaseCreds = Environment.GetEnvironmentVariable("FIREBASE_CREDENTIALS");

            if (string.IsNullOrWhiteSpace(firebaseCreds))
            {
                throw new InvalidOperationException(
                    "FIREBASE_CREDENTIALS environment variable is not configured.");
            }
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "DB_CONNECTION_STRING is missing from environment variables."
                );
            }

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString)
            );
            // Register application services
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddSingleton<IFirebaseService>(
                _ => new FirebaseService(firebaseCreds));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            return services.BuildServiceProvider();
        }
    }
}