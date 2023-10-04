using Ldis_Team_Project.Models.BusinesModels;
using Ldis_Team_Project.Services.Interfaces;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class RefreshTokenAsync : IRefreshTokenAsyncService
    {
        private readonly IGetUserSecretDataService _GetUserSecret;
        private readonly ISendPostRequestService _SendPostRequest;
        private const string TokenServerEndpoint = "https://oauth2.googleapis.com/token";
        public RefreshTokenAsync()
        {
            _GetUserSecret = new GetUserSecret();
            _SendPostRequest = new SendPostRequest();
        }
        async Task<TokenResult> IRefreshTokenAsyncService.RefreshTokenAsync(string RefreshToken)
        {

            string UserId = _GetUserSecret.GetClientId();
            string UserSecret = _GetUserSecret.GetClientSecret();
            var QueryParams = new Dictionary<string, string>
            {
               {"client_id",UserId },
               {"client_secret", UserSecret},
               {"grant_type","refresf_token" },
               {"refresh_token", RefreshToken}
            };
            var TokenResult = await _SendPostRequest.SendPostRequest<TokenResult>(TokenServerEndpoint, QueryParams);
            return TokenResult;
        }
    }
}
