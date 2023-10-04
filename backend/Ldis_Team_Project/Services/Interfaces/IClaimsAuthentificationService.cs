namespace Ldis_Team_Project.Services.Interfaces
{
    public interface IClaimsAuthentificationService
    {
        Task ClaimsAuthentificationHandler(string Email);
    }
}
