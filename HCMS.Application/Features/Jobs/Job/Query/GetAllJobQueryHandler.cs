using AutoMapper;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Features.Jobs
{
    public class GetAllJobQueryHandler : IRequestHandler<GetAllJobQuery, List<JobDto>>
    {
        private readonly IDataService dataService;
        private readonly IMapper mapper;
        public GetAllJobQueryHandler(IDataService dataService, IMapper mapper)
        {
            this.dataService = dataService;
            this.mapper = mapper;
        }
        public async Task<List<JobDto>> Handle(GetAllJobQuery query, CancellationToken cancellation)
        {
            var jobList = await dataService.Jobs.ToListAsync();
            var jobTitleList = await dataService.JobTitles.ToListAsync();
            var businessUnitList = await dataService.BusinessUnits.ToListAsync();
            var modifiedJobList = new List<JobDto>();
            foreach (var job in jobList)
            {
                var jobTitle = jobTitleList.Where(jt => jt.Id == job.JobTitleId).FirstOrDefault();
                var businessUnit = businessUnitList.Where(bu => bu.Id == job.BusinessUnitId).FirstOrDefault();
                var newJob = new JobDto()
                {
                    JobTitle = jobTitle.Title,
                    BusinessUnit = businessUnit.Name,
                    Vacant=job.IsVacant.ToString(),

                };
                modifiedJobList.Add(newJob);
            }
            return modifiedJobList;
        }
    }
}
