namespace AppStatus.Api.Framework.Services.Application
{
    public interface IFullUpdateEmployee
    {
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
