using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AppStatus.Api.Controllers.Company.InputModels;
using AppStatus.Api.Controllers.Company.ViewModels;
using AppStatus.Api.Framework.Services.Company;
using AppStatus.Api.Shared;
using AppStatus.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStatus.Api.Controllers.Company
{
    [Authorize]
    [ApiController]
    [Route("api/company")]
    public class CompanyController : ApiControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResultViewModel<IEnumerable<CompanyViewModel>>>> GetAsync(CancellationToken cancellationToken)
        {
            var result = await _companyService.GetAsync(cancellationToken);

            return OkData(result.Select(x => new CompanyViewModel()
            {
                Url = x.Url,
                RecordStatus = x.RecordStatus,
                RecordLastEditDate = x.RecordLastEditDate,
                Address = x.Address,
                CreatorAccountId = x.CreatorAccountId,
                Emails = x.Emails,
                Id = x.Id,
                Name = x.Name,
                PhoneNumbers = x.PhoneNumbers,
                RecordInsertDate = x.RecordInsertDate
            }));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResultViewModel<string>>> CreateAsync([FromBody] CompanyCreateInputModel model, CancellationToken cancellationToken)
        {
            var result = await _companyService.CreateAsync(UserSession.AccountId, model.Name, model.Url, model.Emails, model.PhoneNumbers, model.Address, cancellationToken);

            return OkData(result);
        }
    }
}
