using System;

namespace AppStatus.Api.Framework.Services
{
    public interface IRecord
    {
        string Id
        {
            get;
            set;
        }

        short RecordStatus
        {
            get;
            set;
        }


        DateTime RecordInsertDate
        {
            get;
            set;
        }


        DateTime RecordLastEditDate
        {
            get;
            set;
        }
    }
}
