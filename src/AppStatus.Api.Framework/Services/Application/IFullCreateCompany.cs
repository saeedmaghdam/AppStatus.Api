namespace AppStatus.Api.Framework.Services.Application
{
    public interface IFullCreateCompany
    {
        string Name
        {
            get;
            set;
        }

        string Url
        {
            get;
            set;
        }

        string[] Emails
        {
            get;
            set;
        }

        string[] PhoneNumbers
        {
            get;
            set;
        }

        string Address
        {
            get;
            set;
        }
    }
}
