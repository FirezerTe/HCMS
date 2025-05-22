using HCMS.Application.Features.BusinessUnits;
using HCMS.Application.Features.Jobs.JobTitles;
using HCMS.Domain.BusinessUnit;
using HCMS.Domain.Job;

namespace HCMS.API.Dto
{
    public class LookupDto
    {
        public List<JobTitleDto> JobTitles { get; set; }
        public List<JobCatagory> JobCatagories { get; set;}
        public List<JobGrade> JobGrades { get; set;}
        public List <BusinessUnitDto > BusinessUnits { get; set; }
        public List<BusinessUnitType>  BusinessUnitTypes { get; set; }
    }
}
