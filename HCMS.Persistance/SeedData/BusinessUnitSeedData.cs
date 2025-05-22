using HCMS.Domain.BusinessUnit;
using HCMS.Domain.Enum;
using HCMS.Persistance.DBContext;

namespace HCMS.Persistance.SeedData
{
    public class BusinessUnitSeedData
    {
        public static async Task SeedAsync(HCMSDBContext context)
        {
            if (context.BusinessUnits.Any()) return;
            var businessUnits = new List<BusinessUnit>()
            {
                new BusinessUnit() { Name="BerhanBank"  ,BusinessUnitID="Bank" ,ParentId=1, Type=1,AreaCode="001",Address="Addis Ababa Bole", },

            };
            await context.BusinessUnits.AddRangeAsync(businessUnits);
        }
    }
}
