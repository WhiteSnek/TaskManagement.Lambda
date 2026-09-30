using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Lambda.Dtos;
using TaskManagement.Lambda.Services.Interface;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace TaskManagement.Lambda
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input">The event for the Lambda function handler to process.</param>
        /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
        /// <returns></returns>
        private readonly ServiceProvider _serviceProvider;
        public Function()
        {
            _serviceProvider = Startup.ConfigureServices();
        }
        public async Task FunctionHandler(NotificationEvent input, ILambdaContext context)
        {
            using var scope = _serviceProvider.CreateScope();

            var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
            context.Logger.LogInformation(
               $"Processing notification: {input}");

            var messageId = await notificationService.SendNotificationAsync(input);
            context.Logger.LogInformation($"FCM message sent successfully: {messageId}");

        }
    }
}
