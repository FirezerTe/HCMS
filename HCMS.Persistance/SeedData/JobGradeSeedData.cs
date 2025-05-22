using HCMS.Domain.Enum;
using HCMS.Domain.Job;
using HCMS.Persistance.DBContext;

namespace HCMS.Persistance.SeedData
{
    public class JobGradeSeedData
    {
        public static async Task SeedAsync(HCMSDBContext context)
        {
            if (context.JobCatagories.Any()) return;
            var jobGrades = new List<JobGrade>()
            {
                new JobGrade() {Value=JobGradeEnum.JobGradeOne ,Name="JobGradeOne",Description="Clerical" },
                new JobGrade() {Value=JobGradeEnum.JobGradeTwo ,Name="JobGradeOne",Description="Non_Clerical" },
                new JobGrade() {Value=JobGradeEnum.JobGradeThree ,Name="JobGradeOne",Description="Professional" },
                new JobGrade() {Value=JobGradeEnum.JobGradeFour ,Name="JobGradeOne",Description="Managerial" }
            };
            await context.JobGrades.AddRangeAsync(jobGrades);
        }
    }
}
