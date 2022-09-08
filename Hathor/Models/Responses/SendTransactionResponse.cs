using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class SendTransactionResponse : TransactionResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

    }

    public class TransactionResponse
    {
        [JsonProperty("hash")]
        public string? TxId { get; set; }

        [JsonProperty("nonce")]
        public int Nonce { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("parents")]
        public List<string> Parents { get; set; } = new();

        [JsonProperty("inputs")]
        public List<Input> Inputs { get; set; } = new();

        [JsonProperty("outputs")]
        public List<Output> Outputs { get; set; } = new();

        [JsonProperty("tokens")]
        public List<string> Tokens { get; set; } = new();

    }
   
}