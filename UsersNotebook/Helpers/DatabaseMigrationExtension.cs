using Microsoft.EntityFrameworkCore;
using UsersNotebook.Data.Context;

namespace UsersNotebook.Helpers
{
    public static class DatabaseMigrationExtension
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.Migrate();
            }

            return app;
        }
    }
}
