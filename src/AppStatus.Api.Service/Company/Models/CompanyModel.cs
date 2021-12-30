using AppStatus.Api.Framework.Services.Company;

namespace AppStatus.Api.Service.Company.Models
{
    public class CompanyModel : Record, ICompany
    {
        public string CreatorAccountId
        {
            get;
            set;
        }

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
