using System.Collections.Generic;
using AppStatus.Api.Framework.Services.Application;

namespace AppStatus.Api.Service.Application.Models
{
    public class FullCreateModel : IFullCreate
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

        public string[] ToDo
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
}
