using Ldis_Team_Project.Controllers;
using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.Models.BusinesModels;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Ldis_Team_Project.SignalR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class RegOrLogHandler : IREgOrLogHandlerService
    {
        private readonly IRepositoryService _Repository;
        private readonly ISendCodeAuthService _SendCode;
        private readonly IClaimsAuthentificationService _ClaimsAuth;
        private readonly IHttpContextAccessor _ContextAccess;
        private readonly IMemoryCache _Cache;
        public const string SessionKeyEmail = "KeyEmail";
        public const string SessionKeyImage = "KeyImage";
            public RegOrLogHandler(IRepositoryService repository,
            ISendCodeAuthService sendCode,IClaimsAuthentificationService claims,
            IHttpContextAccessor contextAccessor,IMemoryCache cache)
        {
            _ClaimsAuth = claims;
            _Cache = cache;
            _ContextAccess = contextAccessor;
            _SendCode = sendCode;
            _Repository = repository;
        }

        public async Task<string> UserHandlerLogOrReg(Dictionary<string,string> UserInfo )
        {
            string Email = null;
            string ImageLink = null;
            foreach (var item in UserInfo)
            {
                if (item.Key == "email")
                {
                    Email = item.Value;
                    _Cache.Set(SessionKeyEmail,Email,new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(4)));
                }
                else if (item.Key == "picture") 
                {
                    ImageLink = item.Value;
                    _Cache.Set(SessionKeyImage, ImageLink, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(4)));
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
                string JsonAnswer = JsonSerializer.Serialize(AnsverInstance);
                return JsonAnswer;
            }
            else
            {
                _Cache.Set(GroupChatHub.EmailUserCookie,Email,new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(2)));
                _ClaimsAuth.ClaimsAuthentificationHandler(Email);
                var AnsverInstance = new AnswerOnRequest
                {
                    Status = "succesful",
                    Message = "User was Authentificated with claims"
                };
                string JsonAnswer = JsonSerializer.Serialize(AnsverInstance);
                return JsonAnswer;
            }
            
        }
        public void CreateUser(string UserName)
        {
            string Code = (string)_Cache.Get("CodeKey");
            string Email = (string)_Cache.Get(SessionKeyEmail);
            string Image = (string)_Cache.Get(SessionKeyImage);
            _Repository.CreateUser(Email, Code, UserName,Image);
            _ContextAccess.HttpContext.Response.Cookies.Append(GroupChatHub.EmailUserCookie, Email);
        }
    }
}
