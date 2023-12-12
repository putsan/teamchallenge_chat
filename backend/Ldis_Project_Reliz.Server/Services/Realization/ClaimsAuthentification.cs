using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class ClaimsAuthentification : IClaimsAuthentificationService
    {
        IHttpContextAccessor HttpAccessor;
        public ClaimsAuthentification(IHttpContextAccessor HttpAccessor)
        {
            this.HttpAccessor = HttpAccessor;
        }
        public async Task Authentification(string Email)
        {
            var ClaimsUser = new List<Claim>
            {
                new Claim(ClaimTypes.Email,Email)
            };
            HttpAccessor.HttpContext.Response.Cookies.Append(DataToCacheSessionCookieKey.EmailForAllOperationWithEmail, Email);
            var IdentityUser = new ClaimsIdentity(ClaimsUser, CookieAuthenticationDefaults.AuthenticationScheme);
            var ClaimsPrincipal = new ClaimsPrincipal(IdentityUser);
            await HttpAccessor.HttpContext.SignInAsync(ClaimsPrincipal);
        }
    }
}
