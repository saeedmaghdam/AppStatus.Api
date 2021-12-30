using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AppStatus.Api.Framework.Services.Company
{
    public interface ICompanyService
    {
        Task<IEnumerable<ICompany>> GetAsync(CancellationToken cancellationToken);

        Task<string> CreateAsync(string accountId, string name, string url, string[] emails, string[] phoneNumbers, string address, CancellationToken cancellationToken);
    }
}
