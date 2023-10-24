using DinkToPdf;
using DinkToPdf.Contracts;
using UserNotebook.Core.Repositories;
using UserNotebook.Core.Services;
using UsersNotebook.Middlewares;

namespace UsersNotebook.Helpers
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
#if DEBUG
            string libwkhtmltoxPath = configuration["LibwkhtmltoxPath"];
            if (!string.IsNullOrEmpty(libwkhtmltoxPath))
            {
                new CustomAssemblyLoadContext().LoadUnmanagedLibrary(libwkhtmltoxPath);
            }
#endif
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddScoped<IReportService, ReportService>();
        }
    }
}
