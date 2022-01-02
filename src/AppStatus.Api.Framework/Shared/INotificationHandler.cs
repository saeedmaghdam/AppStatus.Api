using System.Threading;
using System.Threading.Tasks;

namespace AppStatus.Api.Framework.Shared
{
    public interface INotificationHandler
    {
        Task SendVerificationCodeAsync(string mobileNumber, string code, CancellationToken cancellationToken);
    }
}
