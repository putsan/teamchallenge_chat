using Ldis_Team_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class ClaimsAuthentification : IClaimsAuthentificationService
    {
        private IHttpContextAccessor _ContextAccessor;
        public ClaimsAuthentification(IHttpContextAccessor context)
        {
            _ContextAccessor = context;
        }
        public async Task ClaimsAuthentificationHandler(string Email)
        {
            var ClaimsList = new List<Claim>
            {
                new Claim (ClaimTypes.Email,Email)
            };
            var IdentityUser = new ClaimsIdentity(ClaimsList,CookieAuthenticationDefaults.AuthenticationScheme);
            var ClaimsPrincipal = new ClaimsPrincipal(IdentityUser);
            await _ContextAccessor.HttpContext.SignInAsync(ClaimsPrincipal);
        }
    }
}