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


        public async Task<string> FormRegistration(string UserName, string Password,string Email)
        {
           bool BolleanResult = await _Repository.FindUserRegistration(Email,Password);
            if (BolleanResult == false)
            {
                var AnswerJsonInstance = new AnswerOnRequest
                {
                    Status = "unsuccess",
                    Message = "Пользователь с таким именем и паролем уже существует"
                };
                var JsonAnswer = JsonSerializer.Serialize(AnswerJsonInstance);
                return JsonAnswer;
            }
            else
            {
                _Claims.ClaimsAuthentificationHandler(Email);
                var AnswerJsonInstance = new AnswerOnRequest
                {
                    Status = "success",
                    Message = "Вы успешно зарегистрировались"
                };
                var JsonAnswer = JsonSerializer.Serialize(AnswerJsonInstance);
                return JsonAnswer;
            }
        }

        public async Task<string> FormLogin(string UserName, string Password)
        {
            bool FindingResult = await _Repository.FindUserLogin(UserName, Password);
            string Email = _ContextAccessor.HttpContext.Session.GetString(ServiceRealization.EmailKeySession);
            if (FindingResult == true)
            {
                _Claims.ClaimsAuthentificationHandler(Email);
                var AnswerJsonInstance = new AnswerOnRequest
                {
                    Status = "success",
                    Message = "Аутентификация прошла успешно"
                };
                var JsonSuccesAnswer = JsonSerializer.Serialize(AnswerJsonInstance);
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
