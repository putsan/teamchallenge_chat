﻿using Ldis_Team_Project.Services.Interfaces;
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
            services.AddTransient<ISendPasswordOnEmailService,SendPasswordEmail>();
            return services;
        }
    }
}