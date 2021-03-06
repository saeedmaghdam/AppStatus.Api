using AppStatus.Api.Framework.Services.Account;
using AppStatus.Api.Framework.Services.Application;
using AppStatus.Api.Framework.Services.Company;
using AppStatus.Api.Framework.Services.Object;
using AppStatus.Api.Service.Account;
using AppStatus.Api.Service.Application;
using AppStatus.Api.Service.Company;
using AppStatus.Api.Service.Object;
using Microsoft.Extensions.DependencyInjection;

namespace AppStatus.Api.Service
{
    public class DependencyResolver
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IObjectService, ObjectService>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
}
