using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Attributes;
using AppStatus.Api.Controllers.Account.InputModels;
using AppStatus.Api.Controllers.Account.ViewModels;
using AppStatus.Api.Framework.Exceptions;
using AppStatus.Api.Framework.Services.Account;
using AppStatus.Api.Shared;
using AppStatus.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStatus.Api.Controllers.Account
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ApiControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [ServiceFilter(typeof(RecaptchaV3ValidationAttribute))]
        [HttpPost("login")]
        public async Task<ActionResult<ApiResultViewModel<LoginViewModel>>> LoginAsync([FromBody] AccountLoginInputModel model, string recaptchaToken, CancellationToken cancellationToken)
        {
            var result = await _accountService.LoginAsync(model.Username, model.Password, cancellationToken);

            return OkData(new LoginViewModel()
            {
                Token = result.Token,
                IsSuccessful = result.IsSuccessful,
                ExpirationDate = result.ExpirationDate
            });
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task LogoutAsync(CancellationToken cancellationToken)
        {
            await _accountService.LogoutAsync(UserSession.Token, cancellationToken);
        }

        [HttpPost("isAuthenticated/{token}")]
        public async Task<ActionResult<ApiResultViewModel<bool>>> IsAuthenticatedAsync([FromRoute] string token, CancellationToken cancellationToken)
        {
            var isAuthenticated = await _accountService.IsAuthenticated(token, cancellationToken);

            return OkData(isAuthenticated);
        }

        [ServiceFilter(typeof(RecaptchaV3ValidationAttribute))]
        [HttpPost("registerVerificationCode")]
        public async Task RegisterVerificationCodeAsync([FromBody] RegisterVerificationCodeInputModel model, CancellationToken cancellationToken)
        {
            if (UserSession != null && !string.IsNullOrEmpty(UserSession.AccountId))
                throw new ValidationException("100", "You're logged-in already.");

            await _accountService.RegisterVerificationCodeAsync(model.MobileNumber, cancellationToken);
        }

        [ServiceFilter(typeof(RecaptchaV3ValidationAttribute))]
        [HttpPost("register")]
        public async Task RegisterAsync([FromBody] RegisterInputModel model, CancellationToken cancellationToken)
        {
            if (UserSession != null && !string.IsNullOrEmpty(UserSession.AccountId))
                throw new ValidationException("100", "You're logged-in already.");

            await _accountService.RegisterAsync(model.MobileNumber, model.Password, model.Name, model.Family, model.VerificationCode, cancellationToken);
        }

        [ServiceFilter(typeof(RecaptchaV3ValidationAttribute))]
        [HttpPost("resetPasswordVerificationCode")]
        public async Task ResetPasswordVerificationCodeAsync([FromBody] ResetPasswordVerificationCodeInputModel model, CancellationToken cancellationToken)
        {
            if (UserSession != null && !string.IsNullOrEmpty(UserSession.AccountId))
                throw new ValidationException("100", "You're logged-in already.");

            await _accountService.ResetPasswordVerificationCodeAsync(model.MobileNumber, cancellationToken);
        }

        [ServiceFilter(typeof(RecaptchaV3ValidationAttribute))]
        [HttpPost("resetPassword")]
        public async Task ResetPasswordAsync([FromBody] ResetPasswordInputModel model, CancellationToken cancellationToken)
        {
            if (UserSession != null && !string.IsNullOrEmpty(UserSession.AccountId))
                throw new ValidationException("100", "You're logged-in already.");

            await _accountService.ResetPasswordAsync(model.MobileNumber, model.Password, model.VerificationCode, cancellationToken);
        }
    }
}
