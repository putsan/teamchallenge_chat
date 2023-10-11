using Microsoft.AspNetCore.Mvc;

namespace Ldis_Team_Project.Services.Interfaces
{
    public interface IRegLogFromFormService
    {
        Task<string> FormRegistration(string UserName, string Password,string Email);
        Task<string> FormLogin(string UserName, string Password);
    }
}
