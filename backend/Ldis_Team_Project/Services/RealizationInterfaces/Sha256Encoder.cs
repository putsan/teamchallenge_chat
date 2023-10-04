using Ldis_Team_Project.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace Ldis_Team_Project.Services.RealizationInterfaces
{
    public class Sha256Encoder : ISha256EncoderService
    {
        public string ComputeHash(string CodeVerifier)
        {
            using var sha256 = SHA256.Create();
            var ChallengeBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(CodeVerifier));
            var CodeChallenge = Base64UrlEncoder.Encode(ChallengeBytes);
            return CodeChallenge;
        }
    }
}
