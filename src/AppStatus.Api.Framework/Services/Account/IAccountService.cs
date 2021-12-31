using System.Threading;
using System.Threading.Tasks;

namespace AppStatus.Api.Framework.Services.Account
{
    public interface IAccountService
    {
        Task<IAccount> GetAccountByToken(string token, CancellationToken cancellationToken);
        Task<string> CreateAsync(string accountId, string username, string password, string name, string family, CancellationToken cancellationToken);
        Task<ILogin> LoginAsync(string username, string password, CancellationToken cancellationToken);
        Task LogoutAsync(string token, CancellationToken cancellationToken);
        Task<bool> IsAuthenticated(string token, CancellationToken cancellationToken);
    }
}
