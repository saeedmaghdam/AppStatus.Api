using System;
using AppStatus.Api.Framework.Services.Account;

namespace AppStatus.Api.Service.Account.Models
{
    public class LoginModel : ILogin
    {
        public string Token
        {
            get;
            set;
        }

        public bool IsSuccessful
        {
            get;
            set;
        }

        public DateTime ExpirationDate
        {
            get;
            set;
        }
    }
}
