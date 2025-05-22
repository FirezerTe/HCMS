using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain.Job
{
    public class JobType
    {
        [Key]
        public int Id { get; set; }
        public string JobTypeName { get; set; }
        public string JobTypeDescription { get; set; }
    }
}
