using System.Collections.Generic;

namespace AppStatus.Api.Framework.Services.Application
{
    public interface IFullCreate
    {
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

        short AppliedFrom
        {
            get;
            set;
        }

        string AppliedFromAddress
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
