
using Microsoft.IdentityModel.Tokens;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace Ldis_Team_Project.Services.Interfaces
{
    public interface ISha256EncoderService
    {
        string ComputeHash(string CodeVerifier);
    }
}
