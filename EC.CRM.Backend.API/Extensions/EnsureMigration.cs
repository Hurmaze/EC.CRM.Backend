using Microsoft.EntityFrameworkCore;

namespace EC.CRM.Backend.API.Extensions
{
    public static class EnsureMigration
    {
        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : DbContext
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!
                        .CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<T>();
                context!.Database.Migrate();
            }
        }
    }
}
