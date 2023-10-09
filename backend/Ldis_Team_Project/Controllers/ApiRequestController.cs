using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.GoogleOauth;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Ldis_Team_Project.Services.RealizationInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Ldis_Team_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiRequestController : ControllerBase
    {
        public const string SessionKeyApi = "NameKey";
        private readonly IHttpClientFactory _HttpClient;
        private readonly string _str;
        public ApiRequestController(IHttpClientFactory httpClientFactory)
        {
            _str = "https://localhost:7237/GoogleOauthController/RedirectToOauthServer";
            _HttpClient = httpClientFactory;
        }
    /*    [HttpGet]
        public async Task<IActionResult>  GetHandler()
        {

        }*/
        [HttpPost]
        public IActionResult GetUserName(string Name)
        {
            HttpContext.Session.SetString(SessionKeyApi,Name);
            return Ok();
        }
    }
}
