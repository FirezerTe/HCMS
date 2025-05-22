using HCMS.Domain.Job;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HCMS.Persistance.Configuration
{
    public class JobGradeConfiguration:IEntityTypeConfiguration<JobGrade>
    {
        public void Configure (EntityTypeBuilder<JobGrade> builder)
        {
            builder.HasKey(x => x.Value);
            builder.Property(x => x.Name).HasConversion<string>();
        }
    }
}
