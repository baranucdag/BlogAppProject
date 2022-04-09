using System.Text;

namespace Core.Security.Hashing
{
    public class HashingHelper
    {
        // creating hash and salt of a given password
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)  //out returns values
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        // Verify password by given hash and salt
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                      
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
