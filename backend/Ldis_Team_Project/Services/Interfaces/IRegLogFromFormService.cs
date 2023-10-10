using Microsoft.AspNetCore.Mvc;

namespace Ldis_Team_Project.Services.Interfaces
{
    public interface IRegLogFromFormService
    {
        Task<string> FormRegistrAndLogin(string UserName, string Password);
    }
}
