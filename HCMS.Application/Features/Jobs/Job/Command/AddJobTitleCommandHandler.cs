using HCMS.Domain.Job;
using HCMS.Services.DataService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Features.Jobs
{
    public class AddJobCommandHandler:IRequestHandler<AddJobCommand,int>
    {
        private readonly IDataService dataService;
        public AddJobCommandHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task<int> Handle (AddJobCommand command,CancellationToken cancellationToken)
        {
            var newJob = new Job()
            {
                JobTitleId = command.JobTitleId,
                BusinessUnitId = command.BusinessUnitId,
                IsVacant = false
            };

            await dataService.Jobs.AddAsync(newJob);
            await dataService.SaveAsync(cancellationToken);
            return newJob.Id;
        }

    }
}
