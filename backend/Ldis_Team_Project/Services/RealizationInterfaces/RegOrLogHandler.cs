using Ldis_Team_Project.Controllers;
using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Models.BusinesModels;
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
        public const string SessionKeyApi = "KeyApi";
        public RegOrLogHandler(IRepositoryService repository,
            ISendCodeAuthService sendCode,IClaimsAuthentificationService claims,
            IHttpContextAccessor contextAccessor)
        {
            _ClaimsAuth = claims;
            _ContextAccess = contextAccessor;
            _SendCode = sendCode;
            _Repository = repository;
        }

        public async Task UserHandlerLogOrReg(Dictionary<string,string> UserInfo )
        {
            string Email = null;
            string ImageLink = null;
            foreach (var item in UserInfo)
            {
                if (item.Key == "email")
                {
                    Email = item.Value;
                    _ContextAccess.HttpContext.Session.SetString(SessionKeyApi,Email);
                }
                else if (item.Key == "picture") 
                {
                    ImageLink = item.Value;
                }
            }
            var BolleanResult = await _Repository.FindUserByEmail(Email);
            if (BolleanResult == false)
            {
                _SendCode.SendCode(Email);
                var AnsverInstance = new AnswerOnRequest
                {
                    Status = "succesful",
                    Message = "Code verification was sended"
                };
            }
            else
            {
                _ClaimsAuth.ClaimsAuthentificationHandler(Email);
            }
            
        }
        public void CreateUser(string UserName)
        {
            string Code = _ContextAccess.HttpContext.Session.GetString("CodeKey");
            string Email = _ContextAccess.HttpContext.Session.GetString(SessionKeyApi);
            _Repository.CreateUser(Email, Code, UserName);
        }
    }
}
