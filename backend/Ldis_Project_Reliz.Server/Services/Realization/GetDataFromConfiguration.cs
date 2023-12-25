using Ldis_Project_Reliz.Server.Services.Interfaces;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class GetDataFromConfiguration : IGetDataFromConfigurationService
    {
        /*Получение данных из user secret*/
        public IConfigurationRoot? ConfigurationFile = new ConfigurationBuilder().AddUserSecrets<GetDataFromConfiguration>().Build();
        /*Получение пароля приложния (нужен для отправки кода аутентификации на почту пользователя)*/
        public string GetAppPassword()
        {
            return ConfigurationFile.GetValue<string>("SmtpSecret:AppPassword");
        }
        /*Почта отправщика кода аутентификации*/
        public string GetSenderEmail()
        {
            return ConfigurationFile.GetValue<string>("SmtpSecret:SenderEmail");
        }
        /*Получение ClientId для гугл аутентификации*/
        public string GetClientId()
        {
            return ConfigurationFile.GetValue<string>("GoogleOauthSecret:ClientId");
        }
        /*Получение ClientSecret для гугл аутентификации*/
        public string GetClientSecret()
        {
            return ConfigurationFile.GetValue<string>("GoogleOauthSecret:ClientSecret");
        }
        /*Получение строки подключения к БД*/
        public string GetDataBaseConnectionString()
        {
            return ConfigurationFile.GetValue<string>("ConnectionStrings:DataBaseConnect");
        }
    }
}
