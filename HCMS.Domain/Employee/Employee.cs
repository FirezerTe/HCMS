using HCMS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain
{
    public class Employee
    {

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int BusinessUnitID { get; set; }
        public int JobTitleId { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly EmployementDate { get; set; }
        public Gender Gender {  get; set; }
        public MartialStatus MartialStatus { get; set; }
    }
}
