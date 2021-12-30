using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Controllers.Account.InputModels;
using AppStatus.Api.Framework.Services.Account;
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

        [HttpPost]
        public async Task<ActionResult<ApiResultViewModel<string>>> CreateAsync([FromBody] AccountCreateInputModel model, CancellationToken cancellationToken)
        {
            var token = await _accountService.CreateAsync("1", model.Username, model.Password, model.Name, model.Family, cancellationToken);

            return OkData(token);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResultViewModel<string>>> LoginAsync([FromBody] AccountLoginInputModel model, CancellationToken cancellationToken)
        {
            var token = await _accountService.LoginAsync(model.Username, model.Password, cancellationToken);

            return OkData(token);
        }

        [HttpPost("logout/{token}")]
        public async Task LogoutAsync([FromRoute] string token, CancellationToken cancellationToken)
        {
            await _accountService.LogoutAsync(token, cancellationToken);
        }

        [HttpPost("isAuthenticated/{token}")]
        public async Task<ActionResult<ApiResultViewModel<bool>>> IsAuthenticatedAsync([FromRoute] string token, CancellationToken cancellationToken)
        {
            var isAuthenticated = await _accountService.IsAuthenticated(token, cancellationToken);

            return OkData(isAuthenticated);
        }
    }
}
