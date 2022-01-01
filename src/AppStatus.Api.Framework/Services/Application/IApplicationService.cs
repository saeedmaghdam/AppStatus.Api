using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AppStatus.Api.Framework.Services.Application
{
    public interface IApplicationService
    {
        Task<IDashboardData> GetDashboardDataAsync(string accountId, CancellationToken cancellationToken);

        Task<string> FullCreateAsync(string accountId, IFullCreate model, CancellationToken cancellationToken);
    }
}
