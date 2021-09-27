using Hathor.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Node.Responses
{

    public class AddressHistoryResponse : DefaultResponse
    {
        [JsonProperty("history")]
        public List<History> History { get; set; } = new List<History>();
    }

    public class History
    {
        [JsonProperty("tx_id")]
        public string TxId { get; set; } = default!;

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("is_voided")]
        public bool IsVoided { get; set; }

        [JsonProperty("inputs")]
        public List<Input> Inputs { get; set; } = new();

        [JsonProperty("outputs")]
        public List<Output> Outputs { get; set; } = new();

        [JsonProperty("parents")]
        public List<string> Parents { get; set; } = new();

        [JsonProperty("token_name")]
        public string TokenName { get; set; } = default!;

        [JsonProperty("token_symbol")]
        public string TokenSymbol { get; set; } = default!;

    }


}
