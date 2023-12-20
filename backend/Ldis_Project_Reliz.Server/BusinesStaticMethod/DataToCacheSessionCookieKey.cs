﻿using Microsoft.Extensions.Caching.Memory;

namespace Ldis_Project_Reliz.Server.BusinesStaticMethod
{
    public static class DataToCacheSessionCookieKey
    {
        public const string CodeChallengeGoogleOauthSession = "SessionCodeChallengeKey";
        public const string AccessTokenGoogleOauthSession = "SessionTokenKey";
        public const string EmailForAllOperationWithEmail = "CookieEmailKey";
        public const string UserName = "CookieUserNameKey";
        public const string AvatarLinkSession = "SessionAvatarLinkkey";
        public const string AvatarChatLinkSession = "SessionAvatarChatKey";
    }
}
