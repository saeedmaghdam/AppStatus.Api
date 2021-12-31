using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Controllers.Application.InputModels;
using AppStatus.Api.Framework.Services.Application;
using AppStatus.Api.Service.Application.Models;
using AppStatus.Api.Shared;
using AppStatus.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStatus.Api.Controllers.Application
{
    [Authorize]
    [ApiController]
    [Route("api/application")]
    public class ApplicationController : ApiControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("fullCreate")]
        public async Task<ActionResult<ApiResultViewModel<string>>> FullCreateAsync(FullCreateInputModel model, CancellationToken cancellationToken)
        {
            var result = await _applicationService.FullCreateAsync(UserSession.AccountId, new FullCreateModel()
            {
                ApplySource = model.ApplySource,
                Company = new FullCreateCompanyModel()
                {
                    Address = model.Company.Address,
                    Emails = model.Company.Emails,
                    Name = model.Company.Name,
                    PhoneNumbers = model.Company.PhoneNumbers,
                    Url = model.Company.Url
                },
                CoverLetterId = model.CoverLetterId,
                ResumeId = model.ResumeId,
                Employees = model.Employees.Select(x => new FullCreateEmployeeModel()
                {
                    Email = x.Email,
                    Name = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    PictureId = x.PictureId,
                    ProfileUrl = x.ProfileUrl,
                    RoleId = x.RoleId
                })
            }, cancellationToken);

            return OkData(result);
        }
    }
}
