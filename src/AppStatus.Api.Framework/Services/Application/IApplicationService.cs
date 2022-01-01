using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AppStatus.Api.Framework.Services.Application
{
    public interface IApplicationService
    {
        Task<IDashboardData> GetDashboardDataAsync(string accountId, CancellationToken cancellationToken);

        Task<string> FullCreateAsync(string accountId, IFullCreate model, CancellationToken cancellationToken);

        Task PatchNotesAsync(string accountId, string id, string notes, CancellationToken cancellationToken);

        Task PatchTodoStatusAsync(string accountId, string id, string[] todoIds, CancellationToken cancellationToken);
    }
}
