using System;

namespace AppStatus.Api.Framework.Services.Account
{
    public interface ILogin
    {
        string Token
        {
            get;
            set;
        }

        bool IsSuccessful
        {
            get;
            set;
        }

        DateTime ExpirationDate
        {
            get;
            set;
        }
    }
}
