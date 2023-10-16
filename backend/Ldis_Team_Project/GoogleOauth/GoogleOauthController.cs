using Azure.Core;
using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Repository.RealizationRepository;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Ldis_Team_Project.Services.RealizationInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace Ldis_Team_Project.GoogleOauth
{

    public class GoogleOAuthController : Controller
    {
        private const string RedirectUrl = "https://localhost:7237/GoogleOAuth/ExchangeCodeOnToken";
        private string AccessToken;
        private string Email;
        private readonly ISha256EncoderService _Sha256Encoder;
        private readonly IGeneratedOauthRequestUrlService _GeneratedUrl;
        private readonly IExchangeCodeOnTokenService _ExchangeToken;
        private readonly IGetUserDataWithAccessTokenService _GetDataUser;
        private readonly IRepositoryService _Repository;
        private readonly IHttpContextAccessor _ContextAccessor;
        private readonly IClaimsAuthentificationService _ClaimsAuthentification;
        private readonly IMemoryCache _Cache;
        private readonly IREgOrLogHandlerService _RegLog;
        private readonly DbContextApplication _Context;

        public GoogleOAuthController(
            DbContextApplication context,
            IHttpContextAccessor contextAccessor,
            IMemoryCache cache,
            ISha256EncoderService sha256Encoder,
            IGeneratedOauthRequestUrlService generatedUrl,
            IExchangeCodeOnTokenService exchangeToken,
            IGetUserDataWithAccessTokenService getDataUser,
            IREgOrLogHandlerService regLog,
            IRepositoryService repository,
            IClaimsAuthentificationService claimsAuthentification
            )
        {
            _Context = context;
            _Cache = cache;
            _RegLog = regLog;
            _ContextAccessor = contextAccessor;
            _Sha256Encoder = sha256Encoder;
            _GeneratedUrl = generatedUrl;
            _ExchangeToken = exchangeToken;
            _GetDataUser = getDataUser;
            _Repository = repository;
            _ClaimsAuthentification = claimsAuthentification;
        }
       
        /*Обмен кода авторизации на токен доступа, регнистрация и авторизация пользователя на основе полученных данных*/
        public async Task<IActionResult> ExchangeCodeOnToken(string code)
        {
            string GetCacheCodeVerifier = (string)_Cache.Get("KeyMain");
            var TokenResult = await _ExchangeToken.ReturnExchangeAccessToken(code,GetCacheCodeVerifier,RedirectUrl);
            AccessToken = TokenResult.AccessToken;
            var UserData = await _GetDataUser.GetUserData(AccessToken);
            var UserDataDictionary = JsonSerializer.Serialize(UserData);
            _Cache.Set("DictionaryUserKey",UserDataDictionary, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(4)));
            RegistrationOrLoginHandler();
            return Ok();
        }

        public async Task<IActionResult> RegistrationOrLoginHandler()
        {
            var User = JsonSerializer.Deserialize<Dictionary<string, string>>((string)_Cache.Get("DictionaryUserKey"));
            _RegLog.UserHandlerLogOrReg(User);
            return Ok();
        }
    }
}
