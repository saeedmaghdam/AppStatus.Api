namespace AppStatus.Api.Framework.Services.Company
{
    public interface ICompany : IRecord
    {
        string CreatorAccountId
        {
            get;
            set;
        }

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
