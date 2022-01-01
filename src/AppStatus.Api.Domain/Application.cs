namespace AppStatus.Api.Domain
{
    public class Application : BaseEntity
    {
        public string JobTitle
        {
            get;
            set;
        }

        public string Salary
        {
            get;
            set;
        }

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

        public short StateId
        {
            get;
            set;
        }

        public string ApplySource
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
