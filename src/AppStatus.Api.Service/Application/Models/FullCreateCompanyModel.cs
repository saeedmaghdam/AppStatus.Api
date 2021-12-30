using AppStatus.Api.Framework.Services.Application;

namespace AppStatus.Api.Service.Application.Models
{
    public class FullCreateCompanyModel : IFullCreateCompany
    {
        public string Name
        {
            get;
            set;
        }

        public string Url
        {
            get;
            set;
        }

        public string[] Emails
        {
            get;
            set;
        }

        public string[] PhoneNumbers
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }
    }
}
