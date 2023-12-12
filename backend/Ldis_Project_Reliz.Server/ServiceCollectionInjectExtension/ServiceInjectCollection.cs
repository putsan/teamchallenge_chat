using Ldis_Project_Reliz.Server.Repository;
using Ldis_Project_Reliz.Server.Services.Interfaces;
using Ldis_Project_Reliz.Server.Services.Realization;
using System.Runtime.CompilerServices;

namespace Ldis_Project_Reliz.Server.ServiceCollectionInjectExtension
{
    public static class ServiceInjectCollection
    {
        public static IServiceCollection ServiceCollection(this IServiceCollection service)
        {
            service.AddTransient<IGoogleOauthService,GoogleOauthLogics>();
            service.AddTransient<ISendEmailOrRequestService,SendEmailOrRequest>();
            service.AddTransient<IGetDataFromConfigurationService, GetDataFromConfiguration>();
            service.AddTransient<IReturnUrlOauthServerService,ReturnUrlOauthServer>();
            service.AddTransient<IRepository,RepositoryRealization>();
            service.AddTransient<IClaimsAuthentificationService, ClaimsAuthentification>();
            service.AddTransient<IFormRegistrationAndAuthorizationService,FormRegistrationAndLogin>();
            service.AddTransient<ILoadImageOnServerService,LoadImageOnServer>();
            service.AddHostedService<DeleteNoActivityUserTimer>();
            return service;
        }
    }
}
