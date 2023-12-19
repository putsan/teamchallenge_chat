using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Ldis_Project_Reliz.Server.Controllers
{
    public class GoogleOauthController : Controller
    {
        IGoogleOauthService GoogleOauth;
        IMemoryCache MemoryCache;
        public GoogleOauthController(IGoogleOauthService GoogleOauth, IMemoryCache MemoryCache)
        {
            this.MemoryCache = MemoryCache;
            this.GoogleOauth = GoogleOauth;
        }
        public async Task<IActionResult> Code(string code)
        {
            string RedirectUrl = "https://localhost:7209/GoogleOauth/Code";
            string CodeVerifier = (string)MemoryCache.Get(DataToCacheSessionCookieKey.CodeChallengeGoogleOauthCache);
            var Result = await GoogleOauth.ExchangeCodeOnToken(code, CodeVerifier, RedirectUrl);
            string AccessToken = Result.AccessToken;
            MemoryCache.Set(DataToCacheSessionCookieKey.AccessTokenGoogleOauthCache,AccessToken, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
            GetUserDataFromAccessToken();
            return Ok();
        }
        public async Task<IActionResult> GetUserDataFromAccessToken()
        {
            string AccessToken = (string)MemoryCache.Get(DataToCacheSessionCookieKey.AccessTokenGoogleOauthCache);
            var InfoUser = await GoogleOauth.GetUserDataWithAccessToken(AccessToken);
           string a = await GoogleOauth.AuthentificationOrRegisterUser(InfoUser);
            return Ok("Реестрація успішна !");
        }
    }
}
                                         