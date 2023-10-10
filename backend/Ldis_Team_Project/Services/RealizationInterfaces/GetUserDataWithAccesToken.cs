using Ldis_Team_Project.Services.Interfaces;
using Newtonsoft.Json;
using Serilog;
using System.Net.Http.Headers;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class GetUserDataWithAccesToken : IGetUserDataWithAccessTokenService
    {
        public async Task<Dictionary<string,string>> GetUserData(string AccesToken)
        {
            string GoogleUserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";
            using (var HttpClient = new HttpClient())
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",AccesToken);
                HttpResponseMessage response = await HttpClient.GetAsync(GoogleUserInfoUrl);
                if (response.IsSuccessStatusCode)
                {
                    var ResponseContent = await response.Content.ReadAsStringAsync();
                    var UserData = JsonConvert.DeserializeObject<Dictionary<string, string>>(ResponseContent);
                    return UserData;
                }
                else
                {
                    try
                    {
                        throw new Exception("Failed to get user information from Google API");
                    }
                    catch (Exception exeption)
                    {
                        
                        Log.Error($"Error {exeption.Message} DateTime Error - {DateTime.Now} ");
                    }
                }

                return new Dictionary<string, string> { };
            }
        }
    }
}
