using HCMS.Domain.Enums;
using HCMS.Services.DataService;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace HCMS.Application.Features.Employees.Queries
{
    public record GetEmployeeListQuery:IRequest<List<EmployeeDto>>;
   public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeDto>>
    {
        private readonly IDataService dataService;
        public GetEmployeeListQueryHandler(IDataService dataService)
        {
            this.dataService = dataService;
        }
        public async Task< List<EmployeeDto>> Handle (GetEmployeeListQuery query ,CancellationToken cancellationToken)
        {
            var employeeList = await dataService.Employees.ToListAsync();
            var newemployeeList = new List<EmployeeDto>();
            var businessUnitList = await dataService.BusinessUnits.ToListAsync();
            var jobTitleList = await dataService.JobTitles.ToListAsync();
            foreach (var emp in employeeList)
            {

                var businessUnit = businessUnitList.Where(bu => bu.Id == emp.BusinessUnitID).FirstOrDefault();
                var jobTitle = jobTitleList.Where(j => j.Id== emp.JobTitleId).FirstOrDefault();
                var employee = new EmployeeDto()
                {
                    EmployeeName = emp.Name,
                    EmployeeId = emp.EmployeeId,
                    BusinessUnit = businessUnit.Name,
                    JobTitle = jobTitle.Title,
                    BirthDate=emp.BirthDate,
                    EmployementDate=emp.EmployementDate,
                    MartialStatus=emp.MartialStatus,
                    Gender=emp.Gender,
                };
                newemployeeList.Add(employee);
            }
            return newemployeeList;
        }
    }
}
