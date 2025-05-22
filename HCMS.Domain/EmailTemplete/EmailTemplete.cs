using HCMS.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace HCMS.Domain.EmailTemplet
{
    public class EmailTemplate  
    {
        [Key]
        public Guid Id { get; set; }
        public EmailTypeEnum EmailType { get; set; }
        public string EmailMessage { get; set; }

    }
}
