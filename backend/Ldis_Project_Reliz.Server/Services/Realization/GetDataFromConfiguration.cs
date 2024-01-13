using Ldis_Project_Reliz.Server.Services.Interfaces;

namespace Ldis_Project_Reliz.Server.Services.Realization
{
    public class GetDataFromConfiguration : IGetDataFromConfigurationService
    {
        public IConfigurationRoot? ConfigurationFile = new ConfigurationBuilder().AddUserSecrets<GetDataFromConfiguration>().Build();
        public string GetAppPassword()
        {
            return ConfigurationFile.GetValue<string>("SmtpSecret:AppPassword");
        }
        public string GetSenderEmail()
        {
            return ConfigurationFile.GetValue<string>("SmtpSecret:SenderEmail");
        }
        public string GetClientId()
        {
            return ConfigurationFile.GetValue<string>("GoogleOauthSecret:ClientId");
        }

        public string GetClientSecret()
        {
            return ConfigurationFile.GetValue<string>("GoogleOauthSecret:ClientSecret");
        }

        public string GetDataBaseConnectionString()
        {
            return ConfigurationFile.GetValue<string>("ConnectionStrings:DataBaseConnect");
        }
    }
}
