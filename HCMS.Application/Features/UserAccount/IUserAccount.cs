
using HCMS.Application.Features.UserAccount;
using HCMS.Domain.User.Signup;
using HCMS.Domain.User.UserNotification;

namespace HCMS.ApplicationLayer.UserAccount
{
    public interface IUserAccount
    {
        Task<NotifyResponse> CreateUser(UserRegisterDto registerDto);
    }
}
