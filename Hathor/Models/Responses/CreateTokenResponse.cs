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

    public class CreateTokenResponse : DefaultTokenResponse
    {

        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [JsonProperty("symbol")]
        public string Symbol { get; set; } = default!;

        [JsonProperty("configurationString")]
        public string ConfigurationString { get; set; } = default!;
    }
}
