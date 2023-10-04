namespace Ldis_Team_Project.Services.Interfaces
{
    public interface IGetUserDataWithAccessTokenService
    {
        Task<Dictionary<string,string>> GetUserData(string AccesToken);
    }
}
