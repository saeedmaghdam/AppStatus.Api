namespace AppStatus.Api.Framework.Services.Employee
{
    public interface IEmployee : IRecord
    {
        string CreatorAccountId
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        short RoleId
        {
            get;
            set;
        }

        string Role
        {
            get;
            set;
        }

        string PhoneNumber
        {
            get;
            set;
        }

        string Email
        {
            get;
            set;
        }

        string ProfileUrl
        {
            get;
            set;
        }

        string PictureId
        {
            get;
            set;
        }
    }
}
