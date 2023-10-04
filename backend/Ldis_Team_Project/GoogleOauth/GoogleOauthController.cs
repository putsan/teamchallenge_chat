using Azure.Core;
using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Repository.RealizationRepository;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Ldis_Team_Project.Services.RealizationInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ldis_Team_Project.GoogleOauth
{
    [Route("[controller]")]
    [ApiController]
    public class GoogleOauthController : ControllerBase
    {
        private const string RedirectUrl = "https://localhost:7237/GoogleOAuth/Code";
        private const string Scope = "https://www.googleapis.com/auth/admin.directory.user.redonly";
        private const string SessionKey = "OauthSessionKey";
        private const string SessionKeyRegLogHandler = "RegLogSessionKey";
        private string AccessToken;
        private string Email;
        private readonly ISha256EncoderService _Sha256Encoder;
        private readonly IGeneratedOauthRequestUrlService _GeneratedUrl;
        private readonly IExchangeCodeOnTokenService _ExchangeToken;
        private readonly IGetUserDataWithAccessTokenService _GetDataUser;
        private readonly IRepositoryService _Repository;
        private readonly IHttpContextAccessor _ContextAccessor;
        private readonly IClaimsAuthentificationService _ClaimsAuthentification;
        private readonly ISendPasswordOnEmailService _SendPassword;
        private readonly DbContextApplication _Context;

        public GoogleOauthController(
            DbContextApplication context,
            IHttpContextAccessor contextAccessor,
            ISha256EncoderService sha256Encoder,
            IGeneratedOauthRequestUrlService generatedUrl,
            IExchangeCodeOnTokenService exchangeToken,
            IGetUserDataWithAccessTokenService getDataUser,
            IRepositoryService repository,
            IClaimsAuthentificationService claimsAuthentification,
            ISendPasswordOnEmailService sendPassword)
        {
            _Context = context;
            _ContextAccessor = contextAccessor;
            _Sha256Encoder = sha256Encoder;
            _GeneratedUrl = generatedUrl;
            _ExchangeToken = exchangeToken;
            _GetDataUser = getDataUser;
            _Repository = repository;
            _SendPassword = sendPassword;
            _ClaimsAuthentification = claimsAuthentification;
        }
        [HttpGet]
        public string RedirectToOauthServer()
        {
            var CodeVerification = Guid.NewGuid().ToString();
            HttpContext.Session.SetString(SessionKey,CodeVerification);
            var CodeChallenge = _Sha256Encoder.ComputeHash(CodeVerification);
            var url = _GeneratedUrl.GeneratedUrl(Scope, RedirectUrl, CodeChallenge);
            return url;
        }
       
        public async Task<IActionResult> ExchangeCodeOnToken(string code)
        {          
            var CodeVerification = HttpContext.Session.GetString(SessionKey);
            var TokenResult = await _ExchangeToken.ReturnExchangeAccessToken(code,CodeVerification,RedirectUrl);
            AccessToken = TokenResult.AccessToken;
            var UserData = _GetDataUser.GetUserData(AccessToken);
            var UserDataSession = JsonSerializer.Serialize(UserData);
            HttpContext.Session.SetString(SessionKeyRegLogHandler, UserDataSession);
            return Ok();
        }

        public IActionResult RegistrationOrLoginHandler ()
        {
            var User = JsonSerializer.Deserialize<Dictionary<string,string>>(SessionKeyRegLogHandler);
            foreach (var item in User)
            {
                if (item.Key == "email")
                {
                  Email = item.Value;
                }           
            }
            bool SearchResult = _Repository.FindUserByEmail(Email);
            if (SearchResult == true)
            {
                _ClaimsAuthentification.ClaimsAuthentificationHandler(Email);
                return Ok();
            }
            else
            {
                _SendPassword.SendPassword(Email);
            }
            return Ok();
        }
    }
}
