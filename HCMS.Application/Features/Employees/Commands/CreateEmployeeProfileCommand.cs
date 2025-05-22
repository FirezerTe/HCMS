using HCMS.Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HCMS.Application.Features.Employees
{
    public class CreateEmployeeProfileCommand:IRequest<int>
    {

       // public int Id { get; set; }
       // public string EmployeeId { get; set; }
        public string Name { get; set; }
        public int BusinessUnitID { get; set; }
        public int JobTitleId { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly EmployementDate { get; set; }
        public Gender Gender { get; set; }
        public MartialStatus MartialStatus { get; set; }
    }
}
