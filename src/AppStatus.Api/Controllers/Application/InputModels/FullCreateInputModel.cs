using System.Collections.Generic;

namespace AppStatus.Api.Controllers.Application.InputModels
{
    public class FullCreateInputModel
    {
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

        public short AppliedFrom
        {
            get;
            set;
        }

        public string AppliedFromAddress
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
