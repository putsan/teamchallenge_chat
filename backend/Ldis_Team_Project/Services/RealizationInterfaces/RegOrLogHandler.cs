using Ldis_Team_Project.Controllers;
using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class RegOrLogHandler : IREgOrLogHandlerService
    {
        private readonly IRepositoryService _Repository;
        private readonly ISendCodeAuthService _SendCode;
        private readonly IClaimsAuthentificationService _ClaimsAuth;
        private readonly IHttpContextAccessor _ContextAccess;
        public RegOrLogHandler(IRepositoryService repository,
            ISendCodeAuthService sendCode,IClaimsAuthentificationService claims,
            IHttpContextAccessor contextAccessor)
        {
            _ClaimsAuth = claims;
            _ContextAccess = contextAccessor;
            _SendCode = sendCode;
            _Repository = repository;
        }

        public void UserHandlerLogOrReg(Dictionary<string,string> UserInfo )
        {
            string Email = null;
            string ImageLink = null;
            foreach (var item in UserInfo)
            {
                if (item.Key == "email")
                {
                    Email = item.Value;
                }
                else if (item.Key == "picture") 
                {
                    ImageLink = item.Value;
                }
            }
            var BolleanResult = _Repository.FindUserByEmail(Email);
            if (BolleanResult == false)
            {
                _SendCode.SendCode(Email);
                string Code = _ContextAccess.HttpContext.Session.GetString(SendPasswordEmail.SessionKeySendPassword);
                string UserName = _ContextAccess.HttpContext.Session.GetString(ApiRequestController.SessionKeyApi);
                _Repository.CreateUser(Email,Code,UserName);
            }
            else
            {
                _ClaimsAuth.ClaimsAuthentificationHandler(Email);
            }
            
        }

       
    }
}
