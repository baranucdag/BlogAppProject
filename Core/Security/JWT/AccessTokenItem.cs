using System;

namespace Core.Security.JWT
{
    public class AccessTokenItem
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
