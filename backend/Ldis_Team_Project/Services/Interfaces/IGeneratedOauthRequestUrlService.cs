namespace Ldis_Team_Project.Services.Interfaces
{
    public interface IGeneratedOauthRequestUrlService
    {
      string GeneratedUrl(string scope, string redirectUrl, string CodeChallenge);
    }
}
