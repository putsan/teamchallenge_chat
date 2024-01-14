﻿using Microsoft.AspNetCore.Mvc;

namespace Ldis_Team_Project.Services.Interfaces
{
    public interface IREgOrLogHandlerService
    {
        Task<string> UserHandlerLogOrReg(Dictionary<string,string> UserValues);
        void CreateUser(string UserName);
    }
}