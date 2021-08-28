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

        [JsonProperty(PropertyName = "data")]
        public string? Data { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        [JsonProperty(PropertyName = "transactions_count")]
        public int? TransactionsCount { get; set; }
    }
}
