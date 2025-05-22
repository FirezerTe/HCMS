using System.ComponentModel.DataAnnotations;

namespace HCMS.Application.Features.BusinessUnits
{
    public class BusinessUnitDto
    {
    
        public int Id { get; set; }
        public string BusinessUnitID { get; set; }
        public string Name { get; set; }
        public string ParentBusinessUnit { get; set; }
        public int ParentBusinessUnitID { get; set; }
        public string Type { get; set; }
        public string AreaCode { get; set; }
        public string Addres {  get; set; }

    }
}
