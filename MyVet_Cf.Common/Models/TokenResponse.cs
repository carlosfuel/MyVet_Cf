using System;
//using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace MyVet_Cf.Common.Models
{
    public class TokenResponse
    {
        //[JsonProperty("token")]
        public string Token { get; set; }

        //[JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        public DateTime ExpirationLocal => Expiration.ToLocalTime();
    }
}
