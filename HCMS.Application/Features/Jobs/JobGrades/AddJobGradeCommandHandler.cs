using HCMS.Domain.Job;
using HCMS.Services.DataService;
using MediatR;

namespace HCMS.Application.Features.Jobs.JobGrades
{
    public class AddJobGradeCommandHandler:IRequestHandler<AddJobGradeCommand,string>
    {
        private readonly IDataService dataService;
        public AddJobGradeCommandHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task<string> Handle (AddJobGradeCommand command,CancellationToken cancellationToken)
        {
            var maxJobGrade = dataService.JobGrades.OrderBy(job=>job.Value).LastOrDefault();
            var jobGrade = new JobGrade()
            {
                Value = maxJobGrade.Value+1,
                Name = command.Name,
                Description = command.Description,
            };
            await dataService.JobGrades.AddAsync(jobGrade);
            await dataService.SaveAsync(cancellationToken);
            return jobGrade.Value.ToString();

        }
    }
}
