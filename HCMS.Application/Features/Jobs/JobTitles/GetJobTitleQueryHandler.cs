using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HCMS.Application.Features.Jobs.JobTitles
{
    public record GetJobTitleQuery:IRequest<List<JobTitleDto>>;
    internal class GetJobTitleQueryHandler:IRequestHandler<GetJobTitleQuery ,List<JobTitleDto>>
    {
        private readonly IDataService dataService;

        public GetJobTitleQueryHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task<List<JobTitleDto>> Handle (GetJobTitleQuery request,CancellationToken cancellationToken)
        {
            var jobTitleList = await dataService.JobTitles.ToListAsync();
            var newjobTitleList = new List<JobTitleDto>();
            var jobCatagoryList= await dataService.JobCatagories.ToListAsync();
            var jobGradeList = await dataService.JobGrades.ToListAsync();
            foreach (var bu in jobTitleList)
            {
      
                    var jobCatagory = jobCatagoryList.Where(j => ((int)j.Value) == bu.JobCatagoryId).FirstOrDefault();

                var jobGrade=jobGradeList.Where(j => ((int)j.Value)==bu.JobGradeId).FirstOrDefault();
                var jobTitle = new JobTitleDto()
                {
                    Id=bu.Id,
                    Title = bu.Title,
                    Description = bu.Description,
                    JobCatagory = jobCatagory.Name,
                    JobGrade=jobGrade.Name,
                };
                newjobTitleList.Add(jobTitle);
            }
            return newjobTitleList;
        }
    }
}
