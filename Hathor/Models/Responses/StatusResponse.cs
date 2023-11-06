using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class StatusResponse : DefaultResponse
    {
        [JsonProperty(PropertyName = "serverInfo")]
        public ServerInfo? ServerInfo { get; set; }

        [JsonProperty(PropertyName = "statusCode")]
        public int? StatusCode { get; set; }

        [JsonProperty(PropertyName = "network")]
        public string? Network { get; set; }

        [JsonProperty(PropertyName = "serverUrl")]
        public string? ServerUrl { get; set; }

        [JsonProperty(PropertyName = "state")]
        public int? State { get; set; }
    }

    public class ServerInfo
    {
        [JsonProperty("version")]
        public string? Version { get; set; }

        [JsonProperty("network")]
        public string? Network { get; set; }

        [JsonProperty("min_weight")]
        public int MinWeight { get; set; }

        [JsonProperty("min_tx_weight")]
        public int MinTxWeight { get; set; }

        [JsonProperty("min_tx_weight_coefficient")]
        public double MinTxWeightCoefficient { get; set; }

        [JsonProperty("min_tx_weight_k")]
        public int MinTxWeightK { get; set; }

        [JsonProperty("token_deposit_percentage")]
        public double TokenDepositPercentage { get; set; }

        [JsonProperty("reward_spend_min_blocks")]
        public int RewardSpendMinBlocks { get; set; }

        [JsonProperty("max_number_inputs")]
        public int MaxNumberInputs { get; set; }

        [JsonProperty("max_number_outputs")]
        public int MaxNumberOutputs { get; set; }
    }
}
