using UserNotebook.Core.Repositories;
using UserNotebook.Core.Services;

namespace UsersNotebook.Helpers
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();    
        }
    }
}
