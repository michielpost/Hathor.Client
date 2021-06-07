using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class MeltTokensRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; } = default!;

        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
