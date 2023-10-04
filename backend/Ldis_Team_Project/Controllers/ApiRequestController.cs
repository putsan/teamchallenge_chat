using Ldis_Team_Project.DbContextApplicationFolder;
using Ldis_Team_Project.GoogleOauth;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Ldis_Team_Project.Services.RealizationInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Ldis_Team_Project.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiRequestController : ControllerBase
    {
        private readonly ISha256EncoderService _Sha256Encoder;
        private readonly IGeneratedOauthRequestUrlService _GeneratedUrl;
        private readonly IExchangeCodeOnTokenService _ExchangeToken;
        private readonly IGetUserDataWithAccessTokenService _GetDataUser;
        private readonly IRepositoryService _Repository;
        private readonly IHttpContextAccessor _ContextAccessor;
        private readonly IClaimsAuthentificationService _ClaimsAuthentification;
        private readonly ISendPasswordOnEmailService _SendPassword;
        private readonly DbContextApplication _Context;

        public ApiRequestController(
            DbContextApplication context,
            IHttpContextAccessor contextAccessor,
            ISha256EncoderService sha256Encoder,
            IGeneratedOauthRequestUrlService generatedUrl,
            IExchangeCodeOnTokenService exchangeToken,
            IGetUserDataWithAccessTokenService getDataUser,
            IRepositoryService repository,
            IClaimsAuthentificationService claimsAuthentification,
            ISendPasswordOnEmailService sendPassword)
        {
            _Context = context;
            _ContextAccessor = contextAccessor;
            _Sha256Encoder = sha256Encoder;
            _GeneratedUrl = generatedUrl;
            _ExchangeToken = exchangeToken;
            _GetDataUser = getDataUser;
            _Repository = repository;
            _SendPassword = sendPassword;
            _ClaimsAuthentification = claimsAuthentification;
        }
        [HttpGet]
        public IActionResult GetHandler()
        {
            /*            GoogleOauthController contr = new GoogleOauthController(_Context,_ContextAccessor,_Sha256Encoder,_GeneratedUrl,_ExchangeToken,_GetDataUser,_Repository,_ClaimsAuthentification,_SendPassword);
                        return new JsonResult(contr.RedirectToOauthServer());*/
            return Ok();
        }
    }
}
