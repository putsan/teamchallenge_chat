using Ldis_Team_Project.Services.Interfaces;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class GetUserSecret : IGetUserSecretDataService
    {
        /*Получение данных из user secret для генерации ссылки Url Oauts сервера*/
        public string GetClientId()
        {
            var ConfigurationFile = new ConfigurationBuilder().AddUserSecrets<GetUserSecret>().Build();
            return ConfigurationFile.GetValue<string>("GoogleOathDataSection:UserId");
        }

        public string GetClientSecret()
        {
            var ConfigurationFile = new ConfigurationBuilder().AddUserSecrets<GetUserSecret>().Build();
            return ConfigurationFile.GetValue<string>("GoogleOathDataSection:UserSecret");
        }
    }
}
