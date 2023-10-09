using Microsoft.AspNetCore.Mvc;

namespace Ldis_Team_Project.Services.Interfaces
{
    public interface IREgOrLogHandlerService
    {
         void UserHandlerLogOrReg(Dictionary<string,string> UserValues);
    }
}
