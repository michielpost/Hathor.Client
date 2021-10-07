using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class DefaultTokenResponse : DefaultResponse
    {
        [JsonProperty("hash")]
        public string Hash { get; set; } = default!;

        [JsonProperty("nonce")]
        public int Nonce { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

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

    public class CreateTokenResponse : DefaultTokenResponse
    {

        [JsonProperty("token_name")]
        public string TokenName { get; set; } = default!;

        [JsonProperty("token_symbol")]
        public string TokenSymbol { get; set; } = default!;
    }
}
