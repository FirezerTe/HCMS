

using HCMS.Domain.User;
using HCMS.Persistance.DBContext;
using HCMS.Persistance.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMS.Persistence;

namespace SMS.Api
{
    public static class DataSeeder
    {
        public static async Task<WebApplication> SeedData(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                using (var context = scope.ServiceProvider.GetRequiredService<HCMSDBContext>())
                {
                    try
                    {
                        var userManager = services.GetRequiredService<UserManager<HRUser>>();
                        var roleManager = services.GetRequiredService<RoleManager<HRRole>>();
                        await Seed.SeedData( context , userManager , roleManager);
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<HCMSDBContext>>();
                        logger.LogError(ex, "Error occurred  during migration");
                        throw;
                    }
                }
            }
            return app;
        }
    }
}

