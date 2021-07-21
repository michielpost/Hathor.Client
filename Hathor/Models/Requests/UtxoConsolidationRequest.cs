using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class UtxoConsolidationRequest
    {
        [JsonProperty("destination_address")]
        public string DestinationAddress { get; set; } = default!;

        [JsonProperty("max_utxos")]
        public int MaxUtxos { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("filter_address")]
        public string? FilterAddress { get; set; }

        [JsonProperty("amount_smaller_than")]
        public int? AmountSmallerThan { get; set; }

        [JsonProperty("amount_bigger_than")]
        public int? AmountBiggerThan { get; set; }

        [JsonProperty("maximum_amount")]
        public int? MaximumAmount { get; set; }
    }
}
