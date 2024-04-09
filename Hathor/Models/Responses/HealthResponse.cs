using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class HealthResponse
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("checks")]
        public Checks? Checks { get; set; }
    }

    public class Checks
    {
        [JsonPropertyName("fullnode")]
        public List<FullnodeStatus> Fullnode { get; set; } = new();

        [JsonPropertyName("txMining")]
        public List<FullnodeStatus> TxMining { get; set; } = new();
    }

    public class FullnodeStatus
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("componentType")]
        public string? ComponentType { get; set; }

        [JsonPropertyName("componentName")]
        public string? ComponentName { get; set; }

        [JsonPropertyName("output")]
        public string? Output { get; set; }
    }

    
}
