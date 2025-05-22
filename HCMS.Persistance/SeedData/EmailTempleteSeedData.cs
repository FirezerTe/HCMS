using HCMS.Domain.EmailTemplet;
using HCMS.Domain.Enum;
using HCMS.Persistance.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Persistance.SeedData
{
    public class EmailTempleteSeedData
    {
        public static async Task SeedAsync(HCMSDBContext dbContext)
        {
            foreach (var template in EmailTemplates)
            {
                var _template = await dbContext.EmailTemplates.FirstOrDefaultAsync(t => t.EmailType == template.EmailType);
                if (_template == null)
                {
                    dbContext.EmailTemplates.Add(template);
                }
                else if (template.EmailMessage != _template.EmailMessage)
                {
                    _template.EmailMessage = template.EmailMessage;
                }
            }
        }

        private static List<EmailTemplate> EmailTemplates => new List<EmailTemplate>()
        {
            new EmailTemplate()
            {
                Id = Guid.NewGuid(),
                EmailType = EmailTypeEnum.UserAccountRegisterNotificationEnum,
                EmailMessage = $"<br>Dear <strong>{{userRegister.UserName}}</strong>,<br><br>\r\nHuman Capital Management System User has been created!<br>\r\nUserName: <strong>{{userRegister.UserEmail}} </strong><br>\r\nPassword: <strong>{{userRegister.Password}} </strong><br><br>\r\nNote: This is a trial email testing for the Human Capital Management System!\r\n"
            },
              new EmailTemplate()
              {
                  Id = Guid.NewGuid(),
                  EmailType = EmailTypeEnum.UserLoginNotificationEnum,
                  EmailMessage = $"<br>Dear <strong>{{userRegister.UserName}}</strong>, <br><br>\r\nPlease use the below verification code to complete your sign-in process!<br>\r\nVerification Code: <strong>{{userRegister.UserEmail}} </strong><br><br>\r\nNote: This is a trial email testing for the Human Capital Management System!<br>"
              }
        };
        

    }
}
