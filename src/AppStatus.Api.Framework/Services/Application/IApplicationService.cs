using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppStatus.Api.Framework.Services.Application
{
    public interface IApplicationService
    {
        Task<IApplication> GetByIdAsync(string accountId, string id, CancellationToken cancellationToken);

        Task<IDashboardData> GetDashboardDataAsync(string accountId, CancellationToken cancellationToken);

        Task<string> FullCreateAsync(string accountId, IFullCreate model, CancellationToken cancellationToken);

        Task FullUpdateAsync(string accountId, IFullUpdate model, CancellationToken cancellationToken);

        Task PatchNotesAsync(string accountId, string id, string notes, CancellationToken cancellationToken);

        Task PatchToDoStatusAsync(string accountId, string id, string[] todoIds, CancellationToken cancellationToken);

        Task CreateToDoAsync(string accountId, string id, string title, CancellationToken cancellationToken);

        Task CreateAndPatchToDoAsync(string accountId, string id, string title, string[] toDoIds, CancellationToken cancellationToken);

        Task PatchStateAsync(string accountId, string id, short stateId, string logMessage, DateTime dateTime, CancellationToken cancellationToken);

        Task DeleteAsync(string accountId, string id, CancellationToken cancellationToken);
    }
}
