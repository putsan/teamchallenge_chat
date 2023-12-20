using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.Intrinsics.Arm;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class ReturnUrlOauthServer : IReturnUrlOauthServerService
    {
        IGoogleOauthService GoogleOauth;
        IHttpContextAccessor ContextAccessor;
        public ReturnUrlOauthServer(IGoogleOauthService GoogleOauth, IHttpContextAccessor ContextAccessor)
        {
            this.ContextAccessor = ContextAccessor;
            this.GoogleOauth = GoogleOauth;
        }
        string IReturnUrlOauthServerService.ReturnUrlOauthServer()
        {
            string RedirectUrl = "https://localhost:7209/GoogleOauth/Code";
            string Scope = "https://www.googleapis.com/auth/userinfo.email";
            string CodeVerifier = Guid.NewGuid().ToString();
            string CodeChallenge = Sha256Encoder.Sha256Compute(CodeVerifier);
            Console.WriteLine($"Code verifier - {CodeChallenge}");
            ContextAccessor.HttpContext.Session.SetString(DataToCacheSessionCookieKey.CodeChallengeGoogleOauthSession,CodeVerifier);
            return GoogleOauth.GeneratedUrlOauthServer(Scope,RedirectUrl,CodeChallenge);          
        }
    }
}
