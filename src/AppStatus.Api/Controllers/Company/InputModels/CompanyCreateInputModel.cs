namespace AppStatus.Api.Controllers.Company.InputModels
{
    public class CompanyCreateInputModel
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
