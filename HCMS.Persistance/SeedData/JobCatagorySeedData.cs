using HCMS.Domain.Enum;
using HCMS.Domain.Job;
using HCMS.Persistance.DBContext;

namespace HCMS.Persistance.SeedData
{
    public static class JobCatagorySeedData
    {
        public static async Task SeedAsync (HCMSDBContext context)
        {
            if (context.JobCatagories.Any()) return;
            var jobCatagories = new List<JobCatagory>()
            {
                new JobCatagory() {Value=JobCatagoryEnum.Clerical ,Name="Clerical",Description="Clerical" },
                new JobCatagory() {Value=JobCatagoryEnum.Non_Clerical ,Name="Non_Clerical",Description="Non_Clerical" },
                new JobCatagory() {Value=JobCatagoryEnum.Professional ,Name="Professional",Description="Professional" },
                new JobCatagory() {Value=JobCatagoryEnum.Managerial ,Name="Managerial",Description="Managerial" }
            };
            await context.JobCatagories.AddRangeAsync(jobCatagories);
        }
    }
}
