using Ldis_Team_Project.Services.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Serilog;
using System.Net.Http.Headers;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class SendHttpRequest : ISendHttpRequestService
    {
        async Task<T> ISendHttpRequestService.SendHttpRequest<T>(HttpMethod httpMethod, string endpoint, string accessToken = null, Dictionary<string, string> queryParams = null, HttpContent httpContent = null)
        {
            var url = queryParams != null
                ? QueryHelpers.AddQueryString(endpoint, queryParams)
                : endpoint;

            var request = new HttpRequestMessage(httpMethod, url);

            if (accessToken != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            if (httpContent != null)
            {
                request.Content = httpContent;
            }

            using var httpClient = new HttpClient();
            using var response = await httpClient.SendAsync(request);

            var resultJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    throw new HttpRequestException(resultJson);
                }
                catch (Exception Exception)
                {
                    var ErrorDate = DateTime.Now;
                    Log.Error($"Error {response.StatusCode} DateTime Error - {ErrorDate} - more information about error {Exception.Message}");
                    throw;
                }
                

            }

            var result = JsonConvert.DeserializeObject<T>(resultJson);
            return result;
        }
    }
}
