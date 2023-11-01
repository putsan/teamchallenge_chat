using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.GoogleOauth;
using Ldis_Team_Project.Models.BusinesModels;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Ldis_Team_Project.Services.RealizationInterfaces;
using Ldis_Team_Project.SignalR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using System.IO;

namespace Ldis_Team_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiRequestController : ControllerBase
    {
         IReturnUrlOauthServerService _ReturnUrl;
        public const string SessionKeyApi = "KeyApi";
         HttpClient _httpClient;
         IRegLogFromFormService _RegAndLog;
         IREgOrLogHandlerService _HandlerService;
        IMemoryCache _Cache;
        ILoadImageService _Load;
        IHubContext<GroupChatHub> _HubContext;
        public ApiRequestController(IHttpClientFactory httpClientFactory,
            IRegLogFromFormService fromFormService,
            HttpClient client,
            IREgOrLogHandlerService handler,
            IMemoryCache cache,
            IReturnUrlOauthServerService returnUrl,ILoadImageService load,IHubContext<GroupChatHub> contextHub)
        {
            _HubContext = contextHub;
            _Load = load;
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
        public IActionResult RegistrationHandler(string UserName, string Password, string Email)
        {
            _RegAndLog.FormRegistration(UserName, Password, Email);
            return Ok();
        }
        /*Получение даных пользователя из формы авторизации*/
        [HttpPost("{UserName},{Password}")]
        public IActionResult LoginHandler(string UserName, string Password)
        {
            _RegAndLog.FormLogin(UserName, Password);
            return Ok();
        }
        [HttpPost("{image},{UserName},{GroupName}")]
        public async Task<IActionResult> LoadImageOnServer (string UserName,string GroupChat)
        {
            var file = HttpContext.Request.Form.Files["image"];
            _Load.LoadImage(file);
            using var MemoryStream = new MemoryStream();
            await file.CopyToAsync(MemoryStream);
            var imageMessage = new ImageMessage
            {
                ImageHeaders = "data:" + file.ContentType + ";base64,",
                ImageBinary = MemoryStream.ToArray()
            };
            await _HubContext.Clients.Group(GroupChat).SendAsync("SendImage",imageMessage,UserName);
            return Ok();
        }
    }
}
