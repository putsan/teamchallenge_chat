namespace Ldis_Team_Project.Repository.Services
{
    public interface IRepositoryService
    {
        Task<bool> FindUserByEmail(string Email);
        Task CreateUser(string Email, string Code, string UserName, string ImageLInk);
        Task<bool> FindUserLogin(string UserName, string Password);
        Task<bool> FindUserRegistration(string Email, string Password);
        Task AddPrivateMessage(int IdPrivateUser,int IdUser);
        void CreateAnonymousUser(string UserName);
        Task ChangeStatus(string Email,string Action);
        Task DeleteUserFromGroup(string Email, string GroupName);
        Task AddUserToGroup(string Email,string GroupName);
        void AddMessage(string message, string groupName, string userName);
    }
}
