using Microsoft.AspNetCore.Http;

namespace AppStatus.Api.Controllers.Object.InputModels
{
    public class UploadInputModel
    {
        public IFormFile File
        {
            get;
            set;
        }

        public string MetaData
        {
            get;
            set;
        }
    }
}
