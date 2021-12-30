namespace AppStatus.Api.Domain
{
    public class Application : BaseEntity
    {
        public string CreatorAccountId
        {
            get;
            set;
        }

        public string CompanyId
        {
            get;
            set;
        }

        public short State
        {
            get;
            set;
        }

        public short AppliedFrom
        {
            get;
            set;
        }

        public string AppliedFromAddress
        {
            get;
            set;
        }

        public string ResumeId
        {
            get;
            set;
        }

        public string CoverLetterId
        {
            get;
            set;
        }

        public string[] History
        {
            get;
            set;
        }
    }
}
