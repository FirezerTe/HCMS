using HCMS.Domain.User;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SMS.Persistence.SeedData;

public static class RolesAndPermisssionsSeedData
{
    public static async Task SeedAsync(RoleManager<HRRole> roleManager)
    {
        await CreateHROfficerRole(roleManager);
        await CreateShareAdminSectionHeadRole(roleManager);
        await SystemAdminRole(roleManager);
    }

    private static async Task CreateHROfficerRole(RoleManager<HRRole> roleManager)
    {
        var HROfficerRole = await roleManager.FindByNameAsync(Roles.HROfficer);
        if (HROfficerRole == null)
        {
            HROfficerRole = new HRRole(Roles.HROfficer, "Officer", "Officer")
            {
                Id = Guid.NewGuid().ToString()
            };
            await roleManager.CreateAsync(HROfficerRole);
        }

    }

    private static async Task CreateShareAdminSectionHeadRole(RoleManager<HRRole> roleManager)
    {
        var shareAdminSectionHeadRole = await roleManager.FindByNameAsync(Roles.HRSectionHead);
        if (shareAdminSectionHeadRole == null)
        {
            shareAdminSectionHeadRole = new HRRole(Roles.HRSectionHead, " HR Section Head", "HR  Section Head");
            shareAdminSectionHeadRole.Id = Guid.NewGuid().ToString();
            await roleManager.CreateAsync(shareAdminSectionHeadRole);
        }

    }

    private async static Task SystemAdminRole(RoleManager<HRRole> roleManager)
    {
        var systemAdminRole = await roleManager.FindByNameAsync(Roles.ITAdmin);
        if (systemAdminRole == null)
        {
            systemAdminRole = new HRRole(Roles.ITAdmin, "IT Admin", "IT Admin");
            await roleManager.CreateAsync(systemAdminRole);
        }

    }


    private static async Task AddClaimToRole(RoleManager<HRRole> roleManager, HRRole HROfficerRole, IList<Claim> currentClaims, string claimType, string value)
    {
        if (!currentClaims.Any(claim => claim.Type == claimType && claim.Value == value))
            await roleManager.AddClaimAsync(HROfficerRole, new Claim(claimType, value));
    }
}
