using AppStatus.Api.Framework.Services.Account;

namespace AppStatus.Api.Service.Account.Models
{
    public class AccountModel : Record, IAccount
    {
        public string Username
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Family
        {
            get;
            set;
        }

        public bool IsAdmin
        {
            get;
            set;
        }
    }
}
