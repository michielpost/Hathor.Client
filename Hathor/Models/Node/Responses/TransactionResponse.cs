using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Node.Responses
{
    [DebuggerDisplay("{Symbol} | {Name}")]
    public class Token
    {
        [JsonProperty("uid")]
        public string Uid { get; set; } = default!;

        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [JsonProperty("symbol")]
        public string Symbol { get; set; } = default!;
    }

    [DebuggerDisplay("{Hash}")]
    public class Tx
    {
        [JsonProperty("hash")]
        public string Hash { get; set; } = default!;

        [JsonProperty("nonce")]
        public string Nonce { get; set; } = default!;

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("parents")]
        public List<string> Parents { get; set; } = new List<string>();

        [JsonProperty("inputs")]
        public List<Input> Inputs { get; set; } = new List<Input>();

        [JsonProperty("outputs")]
        public List<Output> Outputs { get; set; } = new List<Output>();

        [JsonProperty("tokens")]
        public List<Token> Tokens { get; set; } = new List<Token>();

        [JsonProperty("token_name")]
        public string? TokenName { get; set; }

        [JsonProperty("token_symbol")]
        public string? TokenSymbol { get; set; }

        [JsonProperty("raw")]
        public string Raw { get; set; } = default!;
    }

    [DebuggerDisplay("{Hash}")]
    public class Meta
    {
        [JsonProperty("hash")]
        public string Hash { get; set; } = default!;

        [JsonProperty("children")]
        public List<string> Children { get; set; } = new();

        [JsonProperty("accumulated_weight")]
        public double AccumulatedWeight { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("first_block")]
        public string? FirstBlock { get; set; }

        [JsonProperty("validation")]
        public string? Validation { get; set; }
    }

    public class TransactionResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("tx")]
        public Tx? Tx { get; set; }

        [JsonProperty("meta")]
        public Meta? Meta { get; set; }

        [JsonProperty("spent_outputs")]
        public Dictionary<string, string> SpentOutputs { get; set; } = new();
    }
}
