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
                var logger = serviceScope.ServiceProvider.GetService<ILogger<AppDbContext>>();

                try
                {
                    logger.LogInformation("Migrating database...");
                    context.Database.Migrate();
                    logger.LogInformation("Database migration completed successfully.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            return app;
        }
    }
}
