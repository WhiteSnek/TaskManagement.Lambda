using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Lambda.Services;
using TaskManagement.Lambda.Services.Interface;

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
            // Register application services
            services.AddScoped<INotificationService, NotificationService>();
            services.AddSingleton<IFirebaseService>(
                _ => new FirebaseService(firebaseCreds));
            return services.BuildServiceProvider();
        }
    }
}