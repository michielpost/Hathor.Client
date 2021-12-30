using Hathor.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Node.Responses
{
    public class TokenDataResponse : DefaultResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string? Symbol { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        [JsonProperty(PropertyName = "transactions_count")]
        public int? TransactionsCount { get; set; }

        [JsonProperty(PropertyName = "mint")]
        public List<TokenAuthority> Mint { get; set; } = new();

        [JsonProperty(PropertyName = "melt")]
        public List<TokenAuthority> Melt { get; set; } = new();

        public bool CanMint => Mint.Any();
        public bool CanMelt => Melt.Any();
    }

    public class TokenAuthority
    {
        [JsonProperty(PropertyName = "tx_id")]
        public string TxId { get; set; } = default!;

        [JsonProperty(PropertyName = "index")]
        public int Index { get; set; }
    }
}
