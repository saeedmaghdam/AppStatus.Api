using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AppStatus.Api.Framework.Services.Employee
{
    public interface IEmployeeService
    {
        Task<IEnumerable<IEmployee>> GetByCompanyIdAsync(string accountId, string companyId, CancellationToken cancellationToken);
    }
}
