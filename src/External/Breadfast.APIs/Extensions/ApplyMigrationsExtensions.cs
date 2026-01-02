using Breadfast.Infrastructure.Persistence.Data.Database;
using Breadfast.Infrastructure.Persistence.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Breadfast.APIs.Extensions
{
    public static class ApplyMigrationsExtensions
    {
        public static async Task ApplyMigrations(this WebApplication app)
        {


            using var scope = app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var dbContext = service.GetRequiredService<BreadfastDbContext>();
            var loggerFactory =  service.GetRequiredService<ILoggerFactory>();

            try
            {
            await  dbContext.Database.MigrateAsync(); 
            await BreadfastDbContextSeed.SeedAsync(dbContext);

            }
            catch (Exception ex)
            {
              var logger =   loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error has occured during apply the migration");
                
            }

             
          
        }
    }
}
