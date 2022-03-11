using Microsoft.IdentityModel.Tokens;

namespace Core.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        // signing(verify) our security key (comes from appsetting.json)
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
