using AppStatus.Api.Framework.Services.Application;

namespace AppStatus.Api.Service.Application.Models
{
    public class FullUpdateEmployeeModel : IFullUpdateEmployee
    {
        public string Name
        {
            get;
            set;
        }

        public short RoleId
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string ProfileUrl
        {
            get;
            set;
        }

        public string PictureId
        {
            get;
            set;
        }
    }
}
