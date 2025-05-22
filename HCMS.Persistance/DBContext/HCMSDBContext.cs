using HCMS.Domain.BusinessUnit;
using HCMS.Domain.EmailTemplet;
using HCMS.Domain;
using HCMS.Domain.Job;
using HCMS.Domain.User;
using HCMS.Services.DataService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMS.Persistence;

namespace HCMS.Persistance.DBContext
{
    public class HCMSDBContext : IdentityDbContext<HRUser, HRRole, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>, IDataService
    {
        public HCMSDBContext(DbContextOptions<HCMSDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HCMSDBContext).Assembly);
            modelBuilder.HasSequence<int>("EmployeeId");
        }
        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }  
        public DbSet<JobCatagory> JobCatagories { get; set; }
        public DbSet<JobGrade> JobGrades {  get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<BusinessUnitType> BusinessUnitTypes { get; set; }
        public void Save()
        {
            this.SaveChanges();
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await SaveChangesAsync(cancellationToken);
        }
    }

}
