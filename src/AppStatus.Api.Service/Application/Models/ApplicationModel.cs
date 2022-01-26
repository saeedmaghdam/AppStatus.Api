using System;
using System.Collections.Generic;
using AppStatus.Api.Framework.Services.Application;
using AppStatus.Api.Framework.Services.Company;
using AppStatus.Api.Framework.Services.Employee;

namespace AppStatus.Api.Service.Application.Models
{
    public class ApplicationModel : Record, IApplication
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

        public ICompany Company
        {
            get;
            set;
        }

        public IEnumerable<IEmployee> Employees
        {
            get;
            set;
        }

        public short StateId
        {
            get;
            set;
        }

        public string State
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

        public IEnumerable<IApplicationHistoryItem> History
        {
            get;
            set;
        }

        public IEnumerable<IApplicationToDoItem> ToDo
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

    public class ApplicationHistoryItemModel : Idendity, IApplicationHistoryItem
    {
        public DateTime RecordInsertDate
        {
            get;
            set;
        }

        public DateTime LogDateTime
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

    public class ApplicationToDoItemModel : Idendity, IApplicationToDoItem
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
