using System.Collections.Generic;
using AppStatus.Api.Framework.Services.Application;

namespace AppStatus.Api.Service.Application.Models
{
    public class FullCreateModel : IFullCreate
    {
        public IFullCreateCompany Company
        {
            get;
            set;
        }

        public IEnumerable<IFullCreateEmployee> Employees
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
