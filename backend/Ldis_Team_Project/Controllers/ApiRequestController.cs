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
        private readonly IReturnUrlOauthServerService _ReturnUrl;
        public const string SessionKeyApi = "KeyApi";
        private readonly HttpClient _httpClient;
        private readonly IRegLogFromFormService _RegAndLog;
        private readonly IREgOrLogHandlerService _HandlerService;
        private readonly IMemoryCache _Cache;
        public ApiRequestController(IHttpClientFactory httpClientFactory,
            IRegLogFromFormService fromFormService,
            HttpClient client,
            IREgOrLogHandlerService handler,
            IMemoryCache cache,
            IReturnUrlOauthServerService returnUrl )
        {
            _Cache = cache;
            _ReturnUrl = returnUrl;
            _HandlerService = handler;
            _httpClient = client;
            _RegAndLog = fromFormService;
        }
        /*Возвращение Url сервера аутентификации*/
        [HttpGet]
        public IActionResult GetUrlPauthServer()
        {
            string url = _ReturnUrl.ReturnUrl();
            return new JsonResult(url);     
        }
        /*Получение имени пользователя при переадресации на страницу ввода имени при аутентификации с помощью Google*/
        [HttpPost("{UserName}")]
        public IActionResult GetUserName(string UserName)
        {
            _HandlerService.CreateUser(UserName);
            return Ok();
        }
       /*Получение данных пользователя из формы регистрации*/
        [HttpPost("{UserName},{Password},{Email}")]
        public IActionResult RegistrationHandler (string UserName,string Password,string Email)
        {
            _RegAndLog.FormRegistration(UserName,Password,Email);
            return Ok();
        }
       /*Получение даных пользователя из формы авторизации*/
        [HttpPost("{UserName},{Password}")]
        public IActionResult LoginHandler (string UserName, string Password )
        {
            _RegAndLog.FormLogin(UserName,Password);
             return Ok();
        }
    }
}
