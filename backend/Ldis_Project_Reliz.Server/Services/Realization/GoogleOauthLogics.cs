using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.Models.BusinesModel;
using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Caching.Memory;
using Serilog;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Net.Http.Headers;
using System.Text;


namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class GoogleOauthLogics : IGoogleOauthService
    {
        IGetDataFromConfigurationService GetDataFromConfig;
        ISendEmailOrRequestService Send;
        IRepository Repository;
        IClaimsAuthentificationService ClaimsAuthentification;
        public GoogleOauthLogics(IGetDataFromConfigurationService getDataConfig,
            ISendEmailOrRequestService Send, IRepository Repository, IClaimsAuthentificationService ClaimsAuthentification
           )
        {
            this.ClaimsAuthentification = ClaimsAuthentification;
            this.Repository = Repository;
            this.Send = Send;
            GetDataFromConfig = getDataConfig;
        }
        private string UrlOauthServer = "https://accounts.google.com/o/oauth2/v2/auth";
        public async Task<TokenResult> ExchangeCodeOnToken(string Code, string CodeVerification, string RedirectUrl)
        {
            Console.WriteLine($"Code verifier - {CodeVerification}");
            var AccessTokenServerEndpointUrl = "https://oauth2.googleapis.com/token";
              string ClientId = GetDataFromConfig.GetClientId();
            string ClientSecret = GetDataFromConfig.GetClientSecret();
            var QueryParam = new Dictionary<string, string>
            {
                {"client_id",ClientId},
                {"client_secret",ClientSecret},
                {"code",Code },
                {"code_verifier",CodeVerification },
                {"grant_type", "authorization_code" },
                {"redirect_uri",RedirectUrl }
            };
            return await Send.SendPostRequest<TokenResult>(AccessTokenServerEndpointUrl,QueryParam);
        }

        public async Task<TokenResult> GetRefreshToken(string RefreshToken)
        {
            var AccessTokenServerEndpointUrl = "https://oauth2.googleapis.com/token";
            string ClientId = GetDataFromConfig.GetClientId();
            string ClientSecret = GetDataFromConfig.GetClientSecret();
            var QueryParam = new Dictionary<string, string>
            {
                { "client_id", ClientId },
                { "client_secret", ClientSecret },
                { "grant_type", "refresh_token" },
                { "refresh_token", RefreshToken }
            };

            var tokenResult = await Send.SendPostRequest<TokenResult>(AccessTokenServerEndpointUrl,QueryParam);

            return tokenResult;
        }

        public async Task<Dictionary<string, string>> GetUserDataWithAccessToken(string AccessToken)
        {
            string GoogleUserInfo = "https://www.googleapis.com/oauth2/v2/userinfo";
            using (var HttpClient = new HttpClient())
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                HttpResponseMessage response = await HttpClient.GetAsync(GoogleUserInfo);
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var ResponseContent = await response.Content.ReadAsStringAsync();
                        var UserInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(ResponseContent);
                        return UserInfo;
                    }
                }
                catch (Exception exeption)
                {
                    Log.Error($"Error - {exeption} Date {DateTime.Now}");
                }
            }
            return new Dictionary<string, string>();
        }

        public string GeneratedUrlOauthServer(string scope, string redirectUrl, string CodeChallenge)
        {
            Console.WriteLine($"Code verifier - {CodeChallenge}");
            var QueryParams = new Dictionary<string, string>
            {
                {"client_id", GetDataFromConfig.GetClientId()},
                {"redirect_uri",redirectUrl },
                { "response_type", "code" },
                {"scope",scope },
                {"code_challenge",CodeChallenge },
                {"code_challenge_method", "S256"  },
                {"access_type","offline" }
            };
            var url =  QueryHelpers.AddQueryString(UrlOauthServer, QueryParams);
            return url;
        }

        public async Task<string> AuthentificationOrRegisterUser(Dictionary<string, string> DataUserFromAccesToken)
        {
            string Email = null;
            string ImageLink = null;
            foreach (var Subject in DataUserFromAccesToken)
            {
                if (Subject.Key == "email")
                {
                    Email = Subject.Value;
                }
                if (Subject.Key == "picture")
                {
                    ImageLink = Subject.Value;
                }
            }
            bool result =  Repository.FindUserForСheckExistence(Email);
            if (result == true)
            {
                ClaimsAuthentification.Authentification(Email);
            }
            else if (result == false)
            {
                string CodeAuthentification = Send.SendCodeAuthentification(Email);
                int index = 0;
                StringBuilder stringBuilder = new StringBuilder(Email);
                foreach (var item in Email)
                {
                    index++;
                    if (item == '@')
                    {
                        stringBuilder.Remove(index-1,10);
                    }
                }
                string UserName = Convert.ToString(stringBuilder);
                Repository.CreateNewUser(Email,UserName,CodeAuthentification,ImageLink);
                return "d";
            }
            return "";
        }
    }
}
