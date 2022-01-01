using System.Collections.Generic;

namespace AppStatus.Api.Framework.Services.Application
{
    public interface IFullCreate
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

        IFullCreateCompany Company
        {
            get;
            set;
        }

        IEnumerable<IFullCreateEmployee> Employees
        {
            get;
            set;
        }

        short StateId
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

        string[] ToDo
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
}
