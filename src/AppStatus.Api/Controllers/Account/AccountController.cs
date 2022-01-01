using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Attributes;
using AppStatus.Api.Controllers.Account.InputModels;
using AppStatus.Api.Controllers.Account.ViewModels;
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApiResultViewModel<string>>> CreateAsync([FromBody] AccountCreateInputModel model, CancellationToken cancellationToken)
        {
            var token = await _accountService.CreateAsync("1", model.Username, model.Password, model.Name, model.Family, cancellationToken);

            return OkData(token);
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
    }
}
