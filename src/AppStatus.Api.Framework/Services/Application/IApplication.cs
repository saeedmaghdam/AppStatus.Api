using System;
using System.Collections.Generic;
using AppStatus.Api.Framework.Services.Company;
using AppStatus.Api.Framework.Services.Employee;

namespace AppStatus.Api.Framework.Services.Application
{
    public interface IApplication : IRecord
    {
        string JobTitle
        {
            get;
            set;
        }

        string Salary
        {
            get;
            set;
        }

        ICompany Company
        {
            get;
            set;
        }

        IEnumerable<IEmployee> Employees
        {
            get;
            set;
        }

        public short StateId
        {
            get;
            set;
        }

        string State
        {
            get;
            set;
        }

        string ApplySource
        {
            get;
            set;
        }

        string ResumeId
        {
            get;
            set;
        }

        string CoverLetterId
        {
            get;
            set;
        }

        IEnumerable<IApplicationHistoryItem> History
        {
            get;
            set;
        }

        IEnumerable<IApplicationToDoItem> ToDo
        {
            get;
            set;
        }

        string Notes
        {
            get;
            set;
        }
    }

    public interface IApplicationHistoryItem : IIdentify
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

    public interface IApplicationToDoItem : IIdentify
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
