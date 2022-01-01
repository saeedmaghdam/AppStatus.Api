using System.Collections.Generic;

namespace AppStatus.Api.Controllers.Application.InputModels
{
    public class FullCreateInputModel
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

        public FullCreateCompanyInputModel Company
        {
            get;
            set;
        }

        public IEnumerable<FullCreateEmployeeInputModel> Employees
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

        public IEnumerable<string> ToDo
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
