using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class AddressInfoResponse : DefaultResponse
    {
        [JsonProperty("total_amount_received")]
        public int TotalAmountReceived { get; set; }

        [JsonProperty("total_amount_sent")]
        public int TotalAmountSent { get; set; }

        [JsonProperty("total_amount_available")]
        public int TotalAmountAvailable { get; set; }

        [JsonProperty("total_amount_locked")]
        public int TotalAmountLocked { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; } = default!;

        [JsonProperty("index")]
        public int Index { get; set; }
    }
}
