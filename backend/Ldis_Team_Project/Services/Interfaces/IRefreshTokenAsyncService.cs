using Ldis_Team_Project.Models.BusinesModels;

namespace Ldis_Team_Project.Services.Interfaces
{
    public interface IRefreshTokenAsyncService
    {
        Task<TokenResult> RefreshTokenAsync(string AccesToke);
    }
}
