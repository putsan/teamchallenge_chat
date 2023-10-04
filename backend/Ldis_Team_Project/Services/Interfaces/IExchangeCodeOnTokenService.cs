﻿using Ldis_Team_Project.Models.BusinesModels;

namespace Ldis_Team_Project.Services.Interfaces
{
    public interface IExchangeCodeOnTokenService
    {
       Task<TokenResult> ReturnExchangeAccessToken(string Code,string CodeVerification, string RedirectUrl );
    }
}