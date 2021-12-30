using System.Threading;
using System.Threading.Tasks;

namespace AppStatus.Api.Framework.Services.Object
{
    public interface IObjectService
    {
        Task<string> CreateAsync(string accountId, byte[] content, string hash, CancellationToken cancellationToken);
    }
}
