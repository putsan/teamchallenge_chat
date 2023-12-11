using Microsoft.Extensions.Caching.Memory;

namespace Ldis_Project_Reliz.Server.BusinesStaticMethod
{
    public static class DataToCacheSessionCookieKey
    {
        public const string CodeChallengeGoogleOauthCache = "CacheCodeChallengeKey";
        public const string AccessTokenGoogleOauthCache = "CacheTokenKey";
        public const string EmailForAllOperationWithEmail = "EmailKey";
    }
}
