namespace AppStatus.Api.Domain
{
    public class Company : BaseEntity
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
