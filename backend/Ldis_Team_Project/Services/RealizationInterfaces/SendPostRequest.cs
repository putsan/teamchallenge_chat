using Ldis_Team_Project.Services.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class SendPostRequest : ISendPostRequestService
    {
        private readonly ISendHttpRequestService _SendHttp;
        public SendPostRequest()
        {
            _SendHttp = new SendHttpRequest();
        }
        async Task<T> ISendPostRequestService.SendPostRequest<T>(string endpoint, Dictionary<string, string> bodyParams)
        {
            var httpContent = new FormUrlEncodedContent(bodyParams);
            return await _SendHttp.SendHttpRequest<T>(HttpMethod.Post, endpoint, httpContent: httpContent);
        }

    }
}
