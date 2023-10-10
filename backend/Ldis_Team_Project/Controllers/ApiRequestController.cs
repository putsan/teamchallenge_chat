using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.GoogleOauth;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Ldis_Team_Project.Services.RealizationInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;

namespace Ldis_Team_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiRequestController : ControllerBase
    {
        public const string SessionKeyApi = "KeyApi";
        private readonly HttpClient _httpClient;
        private readonly IRegLogFromFormService _RegAndLog;
        private readonly IREgOrLogHandlerService _HandlerService;
        private readonly IMemoryCache _Cache;
        public ApiRequestController(IHttpClientFactory httpClientFactory,IRegLogFromFormService fromFormService, HttpClient client, IREgOrLogHandlerService handler,IMemoryCache cache )
        {
            _Cache = cache;
            _HandlerService = handler;
            _httpClient = client;
            _RegAndLog = fromFormService;
        }
        [HttpGet]
        public IActionResult GetUrlPauthServer()
        {
            string url =(string)_Cache.Get("ApiKey");
            return new JsonResult(url);
        }

        [HttpPost]
        public IActionResult GetUserName(string UserName)
        {
            _HandlerService.CreateUser(UserName);
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
