using Ldis_Team_Project.Models.BusinesModels;
using Ldis_Team_Project.Services.Interfaces;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class ExchangeCodeOnToken : IExchangeCodeOnTokenService
    {
        private readonly IGetUserSecretDataService _GetUserSecret;
        private readonly ISendPostRequestService _SendPostRequest;
        public ExchangeCodeOnToken()
        {
            _GetUserSecret = new GetUserSecret();
            _SendPostRequest = new SendPostRequest();
        }
        public async Task<TokenResult> ReturnExchangeAccessToken(string Code, string CodeVerification, string RedirectUrl)
        {
            var ConfigurationFile = new ConfigurationBuilder().AddUserSecrets<ExchangeCodeOnToken>().Build();
            string UserId = _GetUserSecret.GetClientId();
            string UserSecret = _GetUserSecret.GetClientSecret();
            var AccessTokenServerEndpointUrl = "https://oauth2.googleapis.com/token";
            var QueryParametrs = new Dictionary<string, string>
            {
                {"client_id",UserId },
                {"client_secret",UserSecret },
                {"code",Code },
                {"code_verifier",CodeVerification },
                { "grant_type", "authorization_code" },
                { "redirect_uri", RedirectUrl }
            };
            var AccessTokenResult = await _SendPostRequest.SendPostRequest<TokenResult>(AccessTokenServerEndpointUrl,QueryParametrs);
            return AccessTokenResult;

        }
    }
}
