using HCMS.Domain.Job;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Application.Features.Jobs.JobCatagories
{
    public record GetJobCatagoryQuery:IRequest<List<JobCatagory>>;
    internal class GetJobCatagoryQueryHandler:IRequestHandler<GetJobCatagoryQuery ,List<JobCatagory>>
    {
        private readonly IDataService dataService;

        public GetJobCatagoryQueryHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task<List<JobCatagory>> Handle (GetJobCatagoryQuery request,CancellationToken cancellationToken)
        {
            return await dataService.JobCatagories.ToListAsync(cancellationToken);
        }
    }
}
