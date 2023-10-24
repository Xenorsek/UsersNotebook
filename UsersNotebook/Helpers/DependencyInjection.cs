using UserNotebook.Core.Repositories;
using UserNotebook.Core.Services;
using UsersNotebook.Middlewares;

namespace UsersNotebook.Helpers
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();    
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<IReportService, ReportService>();
        }
    }
}
