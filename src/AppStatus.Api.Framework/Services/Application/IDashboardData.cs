using System.Collections.Generic;

namespace AppStatus.Api.Framework.Services.Application
{
    public interface IDashboardData
    {
        IDashboardDataItem Wishlist
        {
            get;
            set;
        }

        IDashboardDataItem Applied
        {
            get;
            set;
        }

        IDashboardDataItem Interview
        {
            get;
            set;
        }

        IDashboardDataItem Offer
        {
            get;
            set;
        }

        IDashboardDataItem Rejected
        {
            get;
            set;
        }
    }

    public interface IDashboardDataItem
    {
        IEnumerable<IApplication> Applications
        {
            get;
            set;
        }

        long TotalApplications
        {
            get;
            set;
        }
    }
}
