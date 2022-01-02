using AppStatus.Api.Framework.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace AppStatus.Api.Shared
{
    public class DependencyResolver
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ISecurity, Security>();
            services.AddScoped<IJwtManager, JwtManager>();
            services.AddSingleton<INotificationHandler, NotificationHandler>();
        }
    }
}
