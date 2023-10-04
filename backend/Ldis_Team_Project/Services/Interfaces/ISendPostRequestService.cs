namespace Ldis_Team_Project.Services.Interfaces
{
    public interface ISendPostRequestService
    {
        Task<T> SendPostRequest<T>(string endpoint,Dictionary<string,string> QueryParams);
    }
}
