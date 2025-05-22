using HCMS.Services.DataService;
using MediatR;
using HCMS.Domain.Job;

namespace HCMS.Application.Features.Jobs.JobTitles
{
    public  class AddJobTitleCommandHandler:IRequestHandler<AddJobTitleCommand,int>
    {
        private readonly IDataService  dataservice; 
        public AddJobTitleCommandHandler(IDataService dataservice)
        {
            this.dataservice = dataservice;
        }
        public async Task<int> Handle  (AddJobTitleCommand command,CancellationToken cancellationToken)
        {
            var newJobTitle = new JobTitle()
            {
                Title = command.Title,
                Description= command.Description,
                JobCatagoryId= command.JobCatagoryId,
                JobGradeId= command.JobGradeId,

            };
             dataservice.JobTitles.AddAsync(newJobTitle);
            await dataservice.SaveAsync(cancellationToken);
            return newJobTitle.Id;
        }
    }
}
