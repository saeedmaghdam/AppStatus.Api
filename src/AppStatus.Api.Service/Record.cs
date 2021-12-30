using System;
using AppStatus.Api.Framework.Services;

namespace AppStatus.Api.Service
{
    public class Record : IRecord
    {
        public string Id
        {
            get;
            set;
        }

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
