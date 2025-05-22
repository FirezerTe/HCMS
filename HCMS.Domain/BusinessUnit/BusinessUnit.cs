using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain.BusinessUnit
{
    public class BusinessUnit
    {
        [Key]
        public int Id { get; set; }
        public string BusinessUnitID { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int Type { get; set; }
        public string AreaCode { get; set; }
        public string Address { get; set; }

    }
}
