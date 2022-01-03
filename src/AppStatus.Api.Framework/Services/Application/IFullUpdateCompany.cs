namespace AppStatus.Api.Framework.Services.Application
{
    public interface IFullUpdateCompany
    {
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
    }
}
