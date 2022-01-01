using System.Collections.Generic;
using AppStatus.Api.Framework.Services.Application;

namespace AppStatus.Api.Service.Application.Models
{
    public class DashboardDataItemModel : IDashboardDataItem
    {
        public IEnumerable<IApplication> Applications
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
