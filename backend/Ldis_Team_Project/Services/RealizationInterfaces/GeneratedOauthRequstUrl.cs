using Ldis_Team_Project.Services.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class GeneratedOauthRequstUrl : IGeneratedOauthRequestUrlService
    {
        private readonly IGetUserSecretDataService _GetUserSecret;
        public GeneratedOauthRequstUrl()
        {
            _GetUserSecret = new GetUserSecret();
        }
        /*Генерация Url Oauth сервера для перехода по нему для получения токена доступа*/
        public string GeneratedUrl(string scope, string redirectUrl, string CodeChallenge)
        {
            var OauthServerUrlEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
            string UserId = _GetUserSecret.GetClientId();
            var QueryParametrs = new Dictionary<string, string>
            {
                {"client_id", UserId},
                {"redirect_uri",redirectUrl },
                { "response_type", "code" },
                {"scope",scope },
                {"code_challenge",CodeChallenge },
                {"code_challenge_method","S256" },
                {"access_type","offline" }
            };
            var url =  QueryHelpers.AddQueryString(OauthServerUrlEndpoint,QueryParametrs);
            return url;
        }
    }
}
