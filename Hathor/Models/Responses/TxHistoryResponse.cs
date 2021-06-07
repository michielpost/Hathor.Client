using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class TxHistoryResponse : Dictionary<string, Transaction>
    {
    }

    public class Transaction
    {
        [JsonProperty(PropertyName = "tx_id")]
        public string TxId { get; set; } = default!;

        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty(PropertyName = "is_voided")]
        public bool IsVoided { get; set; }

        [JsonProperty(PropertyName = "inputs")]
        public List<Input> Inputs { get; set; } = new List<Input>();

        [JsonProperty(PropertyName = "outputs")]
        public List<Output> Outputs { get; set; } = new List<Output>();

        [JsonProperty(PropertyName = "parents")]
        public List<string> Parents { get; set; } = new List<string>();
    }

    public class Decoded
    {
        [JsonProperty(PropertyName = "type")]
        public string? Type { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string? Address { get; set; }
    }

    public class Input
    {
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }

        [JsonProperty(PropertyName = "token_data")]
        public int TokenData { get; set; }

        [JsonProperty(PropertyName = "script")]
        public string? Script { get; set; }

        [JsonProperty(PropertyName = "decoded")]
        public Decoded? Decoded { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string? Token { get; set; }

        [JsonProperty(PropertyName = "tx_id")]
        public string? TxId { get; set; }

        [JsonProperty(PropertyName = "index")]
        public int Index { get; set; }
    }

    public class Output
    {
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }

        [JsonProperty(PropertyName = "token_data")]
        public int TokenData { get; set; }

        [JsonProperty(PropertyName = "script")]
        public string? Script { get; set; }

        [JsonProperty(PropertyName = "decoded")]
        public Decoded? Decoded { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string? Token { get; set; }

        [JsonProperty(PropertyName = "spent_by")]
        public string? SpentBy { get; set; }
    }
}
