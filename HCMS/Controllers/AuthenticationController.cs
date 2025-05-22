using HCMS.ApplicationLayer.UserAccount;
using HCMS.Domain.Enum;
using HCMS.Domain.User.Signin;
using HCMS.Domain.User.Signup;
using HCMS.Domain.User.UserNotification;
using HCMS.Service.Models;
using HCMS.Services.DataService;
using HCMS.Services.EmailService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using HCMS.Domain.User;
using Microsoft.AspNetCore.Authorization;
using HCMS.Application.Features.UserAccount;

namespace HCMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IExchangeEmail _emailService;
        private readonly IUserAccount _userAccount;
        private readonly UserManager<HRUser> userManager;
        private readonly SignInManager<HRUser> _signInManager;
        private readonly RoleManager<HRRole> roleManager;
        private readonly IDataService _dataservice;
        private readonly ILogger<AuthenticationController> logger;
        public AuthenticationController(IExchangeEmail emailService, IDataService dataService,
            SignInManager<HRUser> signInManager, UserManager<HRUser> userManager, IUserAccount userAccount, ILogger<AuthenticationController> logger)
        {
            this._emailService = emailService;
            this._userAccount = userAccount;
            this.userManager = userManager;
            this._signInManager = signInManager;
            this._dataservice = dataService;
            this.logger = logger;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterUser(UserRegisterDto registerDto)
        {

            var userResult = await _userAccount.CreateUser(registerDto);
            if (userResult.Status != "Success")
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new NotifyResponse { Status = "Error", Message = userResult.Message });
            }
            return Ok(userResult);

        }

        private bool IsLockedOut(HRUser user) => user.IsDeactivated || (user.LockoutEnd != null && user.LockoutEnd >= DateTime.UtcNow);

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<LoginRes>> Login(UserLogin loginDto, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var user = await userManager.FindByEmailAsync(loginDto.UserEmail);

            if (user == null)
            {
                return BadRequest();
            }

            if (user.IsDeactivated || IsLockedOut(user))
            {
                return BadRequest(new LoginRes(false, false, true));
            }

            var result = await _signInManager.PasswordSignInAsync(loginDto.UserEmail, loginDto.Password, false, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    return BadRequest(new LoginRes(false, false, true));

                if (result.RequiresTwoFactor)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    var token = await this.userManager.GenerateTwoFactorTokenAsync(user, "Email");

                    var emailTemplet = await _dataservice.EmailTemplates
                        .FirstOrDefaultAsync(a => a.EmailType == EmailTypeEnum.UserLoginNotificationEnum);
                    var populatedTemplate = emailTemplet.EmailMessage
                                .Replace("{userRegister.UserName}", user.UserName)
                                .Replace("{userRegister.UserEmail} ", token);

                    var msg = new MessageDto
                    {
                        Email = loginDto.UserEmail,
                        EmailSubject = "Sign in Verification Code",
                        MessageContent = populatedTemplate
                    };

                    return BadRequest(new LoginRes(false, true, false));
                }

                return BadRequest(new LoginRes(false));

            }

            await SignInAsync(user);

            return Ok(new LoginRes(true));
        }

        
        [HttpPost("verification-code")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<ActionResult> VerificationCode([FromBody] VerificationCode VerificationCode)
        {
            if (string.IsNullOrWhiteSpace(VerificationCode?.Code)) return BadRequest();

            var result = await _signInManager.TwoFactorSignInAsync("Email", VerificationCode.Code, false, false);
                logger.LogInformation("Sign-in attempt result: Succeeded={Succeeded}, IsLockedOut={IsLockedOut}",
         result.Succeeded, result.IsLockedOut);

                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        logger.LogWarning("User is locked out.");
                        return BadRequest(new LoginRes(false, false, true));
                    }

                    logger.LogWarning("Invalid verification code.");
                    return BadRequest(new LoginRes(false, true, false));
                }

                var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
            await SignInAsync(user);
            return Ok(new LoginRes(true));
           
        }
            private ClaimsIdentity GetClaimIdentity(HRUser user, List<Claim> userClaims)
            {
                var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user?.FirstName  ??""),
                    new Claim("middle_name", user?.MiddleName ??""),
                    new Claim(ClaimTypes.Surname, user?.LastName ??""),
                    new Claim(ClaimTypes.Email, user?.Email ??"")
                };
                claimsIdentity.AddClaims(claims);

                if (userClaims?.Count() > 0)
                {
                    claimsIdentity.AddClaims(userClaims);
                }

                return claimsIdentity;
            }


            private async Task SignInAsync(HRUser user)
            {
                var claims = (await userManager.GetClaimsAsync(user))?.ToList();
                var roles = await userManager.GetRolesAsync(user);

                foreach (var roleName in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, roleName));
                    //var role = await roleManager.FindByNameAsync(roleName);
                    //if (role != null)
                      //  claims.AddRange(await roleManager.GetClaimsAsync(role));

                }
                 await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(GetClaimIdentity(user, claims ?? new List<Claim>())));

                //logger.LogInformation("User {Email} ({FirstName} {MiddleName} {LastName}) logged in at {Time}.",
                  // user.Email, user.FirstName ?? "", user.MiddleName ?? "", user.LastName ?? "", DateTime.Now);
            }

    }
}
