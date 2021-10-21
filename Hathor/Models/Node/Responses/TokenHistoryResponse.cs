using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Node.Responses
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Decoded
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; } = default!;

        [JsonProperty("timelock")]
        public long? Timelock { get; set; }
    }

    public class Input
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("token_data")]
        public int TokenData { get; set; }

        [JsonProperty("script")]
        public string? Script { get; set; }

        [JsonProperty("decoded")]
        public Decoded? Decoded { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("tx_id")]
        public string? TxId { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }
    }

    public class Output
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("token_data")]
        public int TokenData { get; set; }

        [JsonProperty("script")]
        public string? Script { get; set; }

        [JsonProperty("decoded")]
        public Decoded? Decoded { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; } = default!;

        [JsonProperty("spent_by")]
        public string? SpentBy { get; set; }
    }

    public class Transaction
    {
        [JsonProperty("tx_id")]
        public string TxId { get; set; } = default!;

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("is_voided")]
        public bool IsVoided { get; set; }

        [JsonProperty("inputs")]
        public List<Input> Inputs { get; set; } = new();

        [JsonProperty("outputs")]
        public List<Output> Outputs { get; set; } = new();

        [JsonProperty("parents")]
        public List<string> Parents { get; set; } = new();

        [JsonProperty("height")]
        public int? Height { get; set; }
    }

    public class TokenHistoryResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }
    }


}
