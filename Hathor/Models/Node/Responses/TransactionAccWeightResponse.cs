using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Node.Responses
{
    public class TransactionAccWeightResponse
    {
        [JsonProperty("accumulated_weight")]
        public double AccumulatedWeight { get; set; }

        [JsonProperty("confirmation_level")]
        public double ConfirmationLevel { get; set; }

        [JsonProperty("stop_value")]
        public double StopValue { get; set; }

        [JsonProperty("accumulated_bigger")]
        public bool AccumulatedBigger { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
