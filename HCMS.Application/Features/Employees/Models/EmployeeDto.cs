

using HCMS.Domain.Enums;

namespace HCMS.Application.Features
{
    public class EmployeeDto
    {

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string BusinessUnit { get; set; }
        public string JobTitle { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly EmployementDate { get; set; }
        public Gender Gender { get; set; }
        public MartialStatus MartialStatus { get; set; }
    }
}
