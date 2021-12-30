using System;

namespace AppStatus.Api.Framework.Shared
{
    public interface IJwtManager
    {
        string GenerateToken(string sessionId, string accountId, string name, string family, DateTime expirationDate);
    }
}
