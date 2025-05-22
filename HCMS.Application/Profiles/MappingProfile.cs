using AutoMapper;
using HCMS.Application.Features.Employees;
using HCMS.Application.Features.Jobs;
using HCMS.Domain;
using HCMS.Domain.Job;


namespace HCMS.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateEmployeeProfileCommand, Employee>().ReverseMap();
            CreateMap<Job,JobDto>().ReverseMap();

        }
    }
}
