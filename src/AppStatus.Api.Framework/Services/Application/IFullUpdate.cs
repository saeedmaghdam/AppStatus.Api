using System.Collections.Generic;

namespace AppStatus.Api.Framework.Services.Application
{
    public interface IFullUpdate
    {
        string Id
        {
            get;
            set;
        }

        string Salary
        {
            get;
            set;
        }

        IFullUpdateCompany Company
        {
            get;
            set;
        }

        IEnumerable<IFullUpdateEmployee> Employees
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
    }
}
