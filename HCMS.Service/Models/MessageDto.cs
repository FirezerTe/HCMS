namespace HCMS.Service.Models
{
    public class MessageDto
    {
        public string Email { get; set; }
        public string EmailSubject { get; set; }
        public string To { get; set; }
        public string MessageContent { get; set; }
    }
}
