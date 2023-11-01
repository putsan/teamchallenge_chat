using Ldis_Team_Project.Repository.RealizationRepository;
using Ldis_Team_Project.Repository.Services;
using Ldis_Team_Project.Services.Interfaces;
using Ldis_Team_Project.Services.RealizationInterfaces;
using System.Runtime.CompilerServices;

namespace Ldis_Team_Project.ServiceExtensionCollection
{
    public static class ServiceDependencyCollection
    {
        public static IServiceCollection AddDIContainerServices(this IServiceCollection services)
        {
            services.AddTransient<IGeneratedOauthRequestUrlService, GeneratedOauthRequstUrl>(); 
            services.AddTransient<IExchangeCodeOnTokenService,ExchangeCodeOnToken>();
            services.AddTransient<ISendHttpRequestService,SendHttpRequest>();
            services.AddTransient<ISendPostRequestService,SendPostRequest>();
            services.AddTransient<IRefreshTokenAsyncService,RefreshTokenAsync>();
            services.AddTransient<IGetUserSecretDataService,GetUserSecret>();
            services.AddTransient<IClaimsAuthentificationService, ClaimsAuthentification>();
            services.AddTransient<IGetUserDataWithAccessTokenService, GetUserDataWithAccesToken>();
            services.AddTransient<ISendCodeAuthService,SendCodeAuth>();
            services.AddTransient<ISha256EncoderService, Sha256Encoder>();
            services.AddTransient<IRepositoryService, ServiceRealization>();
            services.AddTransient<IRegLogFromFormService,RegAndLogFromForm>();
            services.AddTransient<IREgOrLogHandlerService,RegOrLogHandler>();
            services.AddTransient<IReturnUrlOauthServerService,ReturnUrlOauthServer>();
            services.AddTransient<ILoadImageService,LoadImageOnServer>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequiredAuthentification", policy =>
                {
                    policy.RequireAuthenticatedUser();
                });
            });
            return services;
        }
    }
}
