using System.Collections.Generic;
using AppStatus.Api.Framework.Services.Application;

namespace AppStatus.Api.Service.Application.Models
{
    public class FullUpdateModel : IFullUpdate
    {
        public string Id
        {
            get;
            set;
        }

        public string Salary
        {
            get;
            set;
        }

        public IFullUpdateCompany Company
        {
            get;
            set;
        }

        public IEnumerable<IFullUpdateEmployee> Employees
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
    }
}
