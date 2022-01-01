using System.Collections.Generic;

namespace AppStatus.Api.Controllers.Application.ViewModels
{
    public class DashboardDataItemViewModel
    {
        public IEnumerable<ApplicationViewModel> Applications
        {
            get;
            set;
        }

        public long TotalApplications
        {
            get;
            set;
        }
    }
}
