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

        Task PatchToDoStatusAsync(string accountId, string id, string[] todoIds, CancellationToken cancellationToken);

        Task CreateToDoAsync(string accountId, string id, string title, CancellationToken cancellationToken);

        Task CreateAndPatchToDoAsync(string accountId, string id, string title, string[] toDoIds, CancellationToken cancellationToken);

        Task PatchStateAsync(string accountId, string id, short stateId, string logMessage, CancellationToken cancellationToken);
    }
}
