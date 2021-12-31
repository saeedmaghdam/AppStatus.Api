using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Controllers.Object.InputModels;
using AppStatus.Api.Framework.Exceptions;
using AppStatus.Api.Framework.Services.Object;
using AppStatus.Api.Shared;
using AppStatus.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStatus.Api.Controllers.Object
{
    [Authorize]
    [ApiController]
    [Route("api/object")]
    public class ObjectController : ApiControllerBase
    {
        private readonly IObjectService _objectService;

        private static readonly string[] VALID_FILE_TYPES = { "application/pdf", "image/bmp", "image/png", "image/jpeg" };

        public ObjectController(IObjectService objectService)
        {
            _objectService = objectService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResultViewModel<string>>> UploadAsync([FromForm] UploadInputModel model, CancellationToken cancellationToken)
        {
            if (model.File.Length > 0)
            {
                if (!VALID_FILE_TYPES.Contains(model.File.ContentType.ToLower()))
                    throw new ValidationException("100", "Unsupported file type.");

                using var fileStream = model.File.OpenReadStream();
                byte[] bytes = new byte[model.File.Length];
                fileStream.Read(bytes, 0, (int)model.File.Length);
                fileStream.Seek(0, SeekOrigin.Begin);
                using (var md5 = MD5.Create())
                {
                    var hashBytes = md5.ComputeHash(fileStream);
                    var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                    var result = await _objectService.CreateAsync(UserSession.AccountId, bytes, model.File.ContentType, hash, cancellationToken);

                    return OkData(result);
                }
            }
            else
            {
                throw new ValidationException("100", "File is invalid.");
            }
        }

        [HttpGet("{id}")]
        public async Task<FileResult> DownloadAsync([FromRoute] string id, CancellationToken cancellationToken)
        {
            var fileToRetrieve = await _objectService.GetByIdAsync(UserSession.AccountId, id, cancellationToken);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}
