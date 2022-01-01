using AppStatus.Api.Framework.Services.Application;

namespace AppStatus.Api.Service.Application.Models
{
    public class DashboardDataModel : IDashboardData
    {
        public IDashboardDataItem Wishlist
        {
            get;
            set;
        }

        public IDashboardDataItem Applied
        {
            get;
            set;
        }

        public IDashboardDataItem Interview
        {
            get;
            set;
        }

        public IDashboardDataItem Offer
        {
            get;
            set;
        }

        public IDashboardDataItem Rejected
        {
            get;
            set;
        }
    }
}
