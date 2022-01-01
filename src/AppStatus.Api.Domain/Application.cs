using System;
using System.Collections.Generic;

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

        public List<ApplicationHistoryItem> History
        {
            get;
            set;
        }

        public List<ApplicationToDoItem> ToDo
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }
    }

    public class ApplicationHistoryItem : Identify
    {
        public DateTime RecordInsertDate
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }

    public class ApplicationToDoItem : Identify
    {
        public DateTime RecordInsertDate
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public bool IsDone
        {
            get;
            set;
        }
    }
}
