
using HCMS.Domain.User;
using HCMS.Persistance.DBContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SMS.Persistence;
using SMS.Persistence.SeedData;
using System.Reflection.Emit;


namespace HCMS.Persistance.SeedData
{
    public class Seed
    {
  
        public static async Task SeedData (HCMSDBContext context,UserManager <HRUser> userManager,RoleManager<HRRole> roleManager)
        {
      
            await JobCatagorySeedData.SeedAsync(context);
            await JobGradeSeedData.SeedAsync(context);
            //  await UserRoleSeedData.SeedAsync(context);
            await RolesAndPermisssionsSeedData.SeedAsync(roleManager);
            await EmailTempleteSeedData.SeedAsync(context);
            await UserSeedData.SeedAsync (userManager,context);
            await BusinessUnitTypeSeedData.SeedAsync(context);
            await BusinessUnitSeedData.SeedAsync(context);
            await context.SaveChangesAsync ();

        }
    }
}
