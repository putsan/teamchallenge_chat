using Ldis_Team_Project.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using static System.Formats.Asn1.AsnWriter;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class ReturnUrlOauthServer : IReturnUrlOauthServerService
    {
        private const string RedirectUrl = "https://localhost:7237/GoogleOAuth/ExchangeCodeOnToken";
        private const string Scope = "https://www.googleapis.com/auth/userinfo.email";
        private readonly IMemoryCache _Cache;
        private readonly ISha256EncoderService _EncoderSha256;
        private readonly IGeneratedOauthRequestUrlService _GeneratedUrl;
        public ReturnUrlOauthServer(IMemoryCache cache,ISha256EncoderService encoderSha256,IGeneratedOauthRequestUrlService generatedUrl)
        {
            _GeneratedUrl = generatedUrl;
            _EncoderSha256 = encoderSha256;
            _Cache = cache;
        }
        /*Возврат Url сервера аутентификации на фронт*/
        public string ReturnUrl()
        {
            var CodeVerification = Guid.NewGuid().ToString();
            _Cache.Set("KeyMain", CodeVerification, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(4)));
            var CodeChallenge = _EncoderSha256.ComputeHash(CodeVerification);
            var url = _GeneratedUrl.GeneratedUrl(Scope, RedirectUrl, CodeChallenge);
            return url;
        }
    }
}
