using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Application.Features.BusinessUnits.Queries
{
    public record GetBusinessUnitsQuery:IRequest<List<BusinessUnitDto>>;
   public class GetBusinessUnitQueryHandler:IRequestHandler<GetBusinessUnitsQuery, List<BusinessUnitDto>>
    {
        private readonly IDataService dataService;
        public GetBusinessUnitQueryHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task< List<BusinessUnitDto>> Handle (GetBusinessUnitsQuery query ,CancellationToken cancellationToken)
        {
            var businessUnitList= await dataService.BusinessUnits.ToListAsync(cancellationToken);
            var businessUnitType= await dataService.BusinessUnitTypes.ToListAsync(cancellationToken);

            var newBusinessUnitList = new List<BusinessUnitDto>();
            foreach (var bu in businessUnitList) {
                var parentBusinessUnit= businessUnitList.Where(b=>b.Id==bu.ParentId).FirstOrDefault();
                var businessUnitTypeInfo = businessUnitType.Where(b => ((int)b.Value) == bu.Type).FirstOrDefault();
                var businessUnit = new BusinessUnitDto()
                {  
                    Id = bu.Id,
                    Name = bu.Name,
                    BusinessUnitID = bu.BusinessUnitID,
                    ParentBusinessUnit = parentBusinessUnit.Name,
                    Type = businessUnitTypeInfo.Name,
                    AreaCode= bu.AreaCode,
                    Addres=bu.Address

                };
                newBusinessUnitList.Add(businessUnit);
            }
            return newBusinessUnitList;
        }
    }
}
