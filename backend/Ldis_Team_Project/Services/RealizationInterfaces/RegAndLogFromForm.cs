using Ldis_Team_Project.Models.BusinesModels;
using Ldis_Team_Project.Repository.RealizationRepository;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using System.Text.Json;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class RegAndLogFromForm : IRegLogFromFormService
    {
        private readonly IRepositoryService _Repository;
        private readonly IClaimsAuthentificationService _Claims;
        private readonly IHttpContextAccessor _ContextAccessor;
        public RegAndLogFromForm(IRepositoryService repository,IClaimsAuthentificationService claims,IHttpContextAccessor context)
        {
            _ContextAccessor = context;
            _Claims = claims;
            _Repository = repository;
        }
        public async Task<string> FormRegistrAndLogin(string UserName, string Password)
        {
            bool FindingResult = await _Repository.FindUser(UserName,Password);
            string Email = _ContextAccessor.HttpContext.Session.GetString(ServiceRealization.EmailKeySession);
            if (FindingResult == true)
            {
                _Claims.ClaimsAuthentificationHandler(Email);
                var AnswerJsonInstance = new AnswerOnRequest
                {
                    Status = "success",
                    Message = "Регистрация прошла успешно"
                };
                var JsonSuccesAnswer =  JsonSerializer.Serialize(AnswerJsonInstance);
                return JsonSuccesAnswer;
            }
            else
            {
                var AnswerJsonInstance = new AnswerOnRequest
                {
                    Status = "unsuccessful",
                    Message = "Данного пользователя не существует пожалуйста попробуйте еще раз",
                    Error = "Could not find user"
                };
                var JsonUnsuccesAnswer = JsonSerializer.Serialize(AnswerJsonInstance);
                return JsonUnsuccesAnswer;
            }
        }
    }
}
