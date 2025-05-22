using MediatR;

namespace HCMS.Application.Features.Jobs.JobCatagories
{
    public class AddJobCatagoryCommand:IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
