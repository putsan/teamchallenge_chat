namespace Ldis_Team_Project.Repository.Services
{
    public interface IRepositoryService
    {
        bool FindUserByEmail(string Email);
        void CreateUser(string Email, string Code, string UserName);
    }
}
