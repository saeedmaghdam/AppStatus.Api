using System;
using MongoDB.Bson;

namespace AppStatus.Api.Domain
{
    public class BaseEntity : Identify
    {
        public short RecordStatus
        {
            get;
            set;
        }

        public DateTime RecordInsertDate
        {
            get;
            set;
        }

        public DateTime RecordLastEditDate
        {
            get;
            set;
        }
    }
}
