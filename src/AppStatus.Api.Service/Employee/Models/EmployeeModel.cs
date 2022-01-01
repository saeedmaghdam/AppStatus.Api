using AppStatus.Api.Framework.Services.Employee;

namespace AppStatus.Api.Service.Employee.Models
{
    public class EmployeeModel : Record, IEmployee
    {
        public string CreatorAccountId
        {
            get;
            set;
        }

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

        public string Role
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
