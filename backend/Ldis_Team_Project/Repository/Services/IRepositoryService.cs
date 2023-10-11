namespace Ldis_Team_Project.Repository.Services
{
    public interface IRepositoryService
    {
        Task<bool> FindUserByEmail(string Email);
        void CreateUser(string Email, string Code, string UserName, string ImageLInk);
        Task<bool> FindUserLogin(string UserName, string Password);
        Task<bool> FindUserRegistration(string Email, string Password);
    }
}
