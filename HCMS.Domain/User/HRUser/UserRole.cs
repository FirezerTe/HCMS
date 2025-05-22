using HCMS.Domain.User;
using Microsoft.AspNetCore.Identity;

namespace HCMS.Domain;

public class UserRole : IdentityUserRole<string>
{
    public virtual HRRole Role { get; set; }
    public virtual HRUser User { get; set; }
}