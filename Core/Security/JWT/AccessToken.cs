using System;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
