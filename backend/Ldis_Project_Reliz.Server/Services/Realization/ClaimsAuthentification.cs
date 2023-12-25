using Ldis_Project_Reliz.Server.BusinesStaticMethod;
using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class ClaimsAuthentification : IClaimsAuthentificationService
    {
        IDataProtectionProvider ProtectionProvider;
        IHttpContextAccessor HttpAccessor;
        IRepository Repository;
        public ClaimsAuthentification(IHttpContextAccessor HttpAccessor, IRepository Repository, IDataProtectionProvider ProtectionProvider)
        {
            this.ProtectionProvider = ProtectionProvider;
            this.Repository = Repository;
            this.HttpAccessor = HttpAccessor;
        }
       /* Аутентификация юзера на основе Claims */
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
        /*Выход из учетной записи*/
        public async Task LogOut()
        {
            HttpAccessor.HttpContext.SignOutAsync();
            HttpAccessor.HttpContext.Response.Cookies.Delete(DataToCacheSessionCookieKey.EmailForAllOperationWithEmail);
            HttpAccessor.HttpContext.Response.Cookies.Delete(DataToCacheSessionCookieKey.UserName);
            Repository.LogOut();
        }
    }
}
