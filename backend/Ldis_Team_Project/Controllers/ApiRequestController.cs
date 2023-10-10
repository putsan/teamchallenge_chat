using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.GoogleOauth;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Ldis_Team_Project.Services.RealizationInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Ldis_Team_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiRequestController : ControllerBase
    {
        public const string SessionKeyApi = "KeyApi";
        private readonly IRegLogFromFormService _RegAndLog;
        public ApiRequestController(IHttpClientFactory httpClientFactory,IRegLogFromFormService fromFormService )
        {
            _RegAndLog = fromFormService;
        }

        [HttpPost]
        public IActionResult GetUserName(string UserName)
        {
            HttpContext.Session.SetString(SessionKeyApi,UserName);
            return Ok();
        }

        [HttpPost]
        public IActionResult RegLogHandler (string UserName,string Password)
        {
            _RegAndLog.FormRegistrAndLogin(UserName,Password);
            return Ok();
        }
    }
}
