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

        public string[] History
        {
            get;
            set;
        }
    }
}
