using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Ldis_Project_Reliz.Server.Controllers
{
    public class GoogleOauthController : Controller
    {
        IGoogleOauthService GoogleOauth;
        IHttpContextAccessor ContextAccessor;
        public GoogleOauthController(IGoogleOauthService GoogleOauth, IHttpContextAccessor ContextAccessor)
        {
            this.ContextAccessor = ContextAccessor;
            this.GoogleOauth = GoogleOauth;
        }
        /*Получение токена доступа*/
        public async Task<IActionResult> Code(string code, [FromQuery] string state )
        {
            string RedirectUrl = "https://localhost:7209/GoogleOauth/Code";
            string CodeVerifier = state;
            if (CodeVerifier == null)
            {
                return StatusCode(505);
            }
            var Result = await GoogleOauth.ExchangeCodeOnToken(code, CodeVerifier, RedirectUrl);
            string AccessToken = Result.AccessToken;
            ContextAccessor.HttpContext.Session.SetString(DataToCacheSessionCookieKey.AccessTokenGoogleOauthSession,AccessToken);
            GetUserDataFromAccessToken();
            return Ok();
        }
        /*Получение данных пользователя из токена доступа и передача их в сервис для регистрации или авторизации*/
        public async Task<IActionResult> GetUserDataFromAccessToken()
        {
            string AccessToken = ContextAccessor.HttpContext.Session.GetString(DataToCacheSessionCookieKey.AccessTokenGoogleOauthSession);
            var InfoUser = await GoogleOauth.GetUserDataWithAccessToken(AccessToken);
            string result = await GoogleOauth.AuthentificationOrRegisterUser(InfoUser);
            return Ok();
        }
    }
}
                                         