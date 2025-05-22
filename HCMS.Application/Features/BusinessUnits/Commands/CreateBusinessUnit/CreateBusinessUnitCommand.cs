using HCMS.Domain.BusinessUnit;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Application.Features.BusinessUnits.Commands.CreateBusinessUnit
{
    public record CreateBusinessUnitCommand( string BusinessUnitName, int ParentId, int businessUnitTypeId, string AreaCode ,string Address ) : IRequest<int>;

    public class CreateBusinessUnitCommandHandler : IRequestHandler<CreateBusinessUnitCommand, int>
    {
        private readonly IDataService dataService;

        public CreateBusinessUnitCommandHandler(IDataService dataService) => this.dataService = dataService;

        public async Task<int> Handle(CreateBusinessUnitCommand request, CancellationToken cancellationToken)
        {

            var businessUnitList = await dataService.BusinessUnits.ToListAsync();

            var parentBuisnessUnit = businessUnitList.Where(bu => bu.Id == request.ParentId).FirstOrDefault();
            var gParentBusinessUnit = businessUnitList.Where(bu => bu.Id == parentBuisnessUnit.ParentId).FirstOrDefault();


            var businessUnit = new BusinessUnit()
            {
                BusinessUnitID = string.Concat(
                        new string(gParentBusinessUnit.Name.Take(5).ToArray()), "/",
                        new string(parentBuisnessUnit.Name.Take(5).ToArray()), "/",   
                        new string(request.BusinessUnitName.Take(5).ToArray())   
                    ),
                Name = request.BusinessUnitName,
                ParentId = request.ParentId,
                Type=request.businessUnitTypeId,
                AreaCode=request.AreaCode,
                Address=request.Address,
            };

            dataService.BusinessUnits.Add(businessUnit);
            await dataService.SaveAsync(cancellationToken);
            return businessUnit.Id;
        }

    }
}