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
        public async Task<IActionResult> Code(string code)
        {
            string RedirectUrl = "https://localhost:7209/GoogleOauth/Code";
            string CodeVerifier = ContextAccessor.HttpContext.Session.GetString(DataToCacheSessionCookieKey.CodeChallengeGoogleOauthSession);
            var Result = await GoogleOauth.ExchangeCodeOnToken(code, CodeVerifier, RedirectUrl);
            string AccessToken = Result.AccessToken;
            ContextAccessor.HttpContext.Session.SetString(DataToCacheSessionCookieKey.AccessTokenGoogleOauthSession,AccessToken);
            GetUserDataFromAccessToken();
            return Ok();
        }
        public async Task<IActionResult> GetUserDataFromAccessToken()
        {
            string AccessToken = ContextAccessor.HttpContext.Session.GetString(DataToCacheSessionCookieKey.AccessTokenGoogleOauthSession);
            var InfoUser = await GoogleOauth.GetUserDataWithAccessToken(AccessToken);
           string a = await GoogleOauth.AuthentificationOrRegisterUser(InfoUser);
            return Ok("Реестрація успішна !");
        }
    }
}
                                         