using System.Collections.Generic;

namespace AppStatus.Api.Controllers.Application.InputModels
{
    public class FullUpdateInputModel
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

        public FullUpdateCompanyInputModel Company
        {
            get;
            set;
        }

        public IEnumerable<FullUpdateEmployeeInputModel> Employees
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
