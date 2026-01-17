using Breadfast.Domain.Entities.User;
using Breadfast.Infrastructure.Persistence.Data.Database;
using Breadfast.Infrastructure.Persistence.Data.Seeding;
using Breadfast.Infrastructure.Persistence.Identity.Data;
using Microsoft.AspNetCore.Identity;
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
            var identiydbContext = service.GetRequiredService<ApplicationIdentityDbContext>();
            var loggerFactory =  service.GetRequiredService<ILoggerFactory>();

            try
            {
                await dbContext.Database.MigrateAsync();
                await BreadfastDbContextSeed.SeedAsync(dbContext);


                var _userManager = service.GetRequiredService<UserManager<ApplcationUser>>();   
                await identiydbContext.Database.MigrateAsync();
                await ApplicationDbContextUserSeeding.SeedUserAsync(_userManager);
            }
            catch (Exception ex)
            {
              var logger =   loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error has occured during apply the migration");
                
            }

             
          
        }
    }
}
