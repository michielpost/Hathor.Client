using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Node.Responses
{
    public class BalanceForAddressResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("total_transactions")]
        public int TotalTransactions { get; set; }

        [JsonProperty("tokens_data")]
        public Dictionary<string, TokenData> TokensData { get; set; } = new Dictionary<string, TokenData>();
    }

    [DebuggerDisplay("{Symbol} | {Balance} | {Name}")]
    public record TokenData
    {
        [JsonProperty("received")]
        public int Received { get; set; }

        [JsonProperty("spent")]
        public int Spent { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("symbol")]
        public string? Symbol { get; set; }

        public int Balance => Received - Spent;
    }

}
