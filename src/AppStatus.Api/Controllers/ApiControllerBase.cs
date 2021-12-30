using AppStatus.Api.Shared;
using AppStatus.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppStatus.Api.Controllers
{
    public class ApiControllerBase : Controller
    {
        public UserSessionModel UserSession => (UserSessionModel)HttpContext.Items["UserSession"];

        public OkObjectResult OkData<TData>(TData data, object meta = null)
        {
            return Ok(ApiResultViewModel<TData>.FromData(data, meta));
        }
    }
}
