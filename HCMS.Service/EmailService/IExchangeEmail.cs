using HCMS.Service.Models;

namespace HCMS.Services.EmailService
{
    public interface IExchangeEmail
    {
        Task<bool> SendEmails(MessageDto email);
    }
}
