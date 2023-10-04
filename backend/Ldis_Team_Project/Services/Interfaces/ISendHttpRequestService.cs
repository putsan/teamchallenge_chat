namespace Ldis_Team_Project.Services.Interfaces
{
    public interface ISendHttpRequestService
    {
        Task<T> SendHttpRequest<T>(HttpMethod httpMethod, string endpoint, string accessToken = null, Dictionary<string, string> queryParams = null, HttpContent httpContent = null);
    }
}
