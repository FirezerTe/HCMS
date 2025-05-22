using HCMS.Domain.BusinessUnit;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Application.Features.BusinessUnits
{
    public record GetBusinessUnitTypeQuery:IRequest<List<BusinessUnitType>>;
    internal class GetBusinessUnitTypeQueryHandler:IRequestHandler<GetBusinessUnitTypeQuery ,List<BusinessUnitType>>
    {
        private readonly IDataService dataService;

        public GetBusinessUnitTypeQueryHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task<List<BusinessUnitType>> Handle (GetBusinessUnitTypeQuery request,CancellationToken cancellationToken)
        {
            return await dataService.BusinessUnitTypes.ToListAsync(cancellationToken);
        }
    }
}
