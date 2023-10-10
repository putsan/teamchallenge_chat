namespace Ldis_Team_Project.Repository.Services
{
    public interface IRepositoryService
    {
        Task<bool> FindUserByEmail(string Email);
        void CreateUser(string Email, string Code, string UserName);
        Task<bool> FindUser(string UserName, string Password);
    }
}
