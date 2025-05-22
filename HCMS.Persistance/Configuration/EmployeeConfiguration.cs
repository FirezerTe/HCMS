using HCMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Persistance.Configuration
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public  void Configure (EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.EmployeeId)
                .IsRequired()
                .HasDefaultValueSql("NEXT VALUE FOR EMPLOYEEID");
            builder.HasIndex(X => X.EmployeeId).IsUnique(true).IsClustered(false);
        }
    }
}
