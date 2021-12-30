namespace AppStatus.Api.Domain
{
    public class Object : BaseEntity
    {
        public string CreatorAccountId
        {
            get;
            set;
        }

        public byte[] Content
        {
            get;
            set;
        }
        
        public string Hash
        {
            get;
            set;
        }
    }
}
