using System.Threading;
using System.Threading.Tasks;

namespace AppStatus.Api.Framework.Services.Application
{
    public interface IApplicationService
    {
        Task<string> FullCreateAsync(string accountId, IFullCreate model, CancellationToken cancellationToken);
    }
}
