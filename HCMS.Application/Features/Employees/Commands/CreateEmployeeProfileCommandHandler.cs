using AutoMapper;
using HCMS.Application.Features.Employees;
using HCMS.Domain;
using HCMS.Services.DataService;
using MediatR;


namespace HCMS.Application.Features.Employees.Commands
{
    public class CreateEmployeeProfileCommandHandler:IRequestHandler <CreateEmployeeProfileCommand,int>
    {
        private readonly IMapper mapper;
        private readonly IDataService dataService;
        public CreateEmployeeProfileCommandHandler(IMapper mapper,IDataService dataService)
        { 
           this.mapper=mapper;
           this.dataService=dataService;
        }
        public Task<int> Handle (CreateEmployeeProfileCommand request ,CancellationToken cancellationToken)
        {
            var employee=mapper.Map<Employee>(request);


            dataService.Employees.Add(employee);

            dataService.Save();
            return Task.FromResult(employee.Id);
        }
    }
}
