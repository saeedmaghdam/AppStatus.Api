namespace AppStatus.Api.Controllers.Application.ViewModels
{
    public class DashboardDataViewModel
    {
        public DashboardDataItemViewModel Wishlist
        {
            get;
            set;
        }

        public DashboardDataItemViewModel Applied
        {
            get;
            set;
        }

        public DashboardDataItemViewModel Interview
        {
            get;
            set;
        }

        public DashboardDataItemViewModel Offer
        {
            get;
            set;
        }

        public DashboardDataItemViewModel Rejected
        {
            get;
            set;
        }
    }
}
