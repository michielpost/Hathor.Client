using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class AtomicSwapTxProposalResponse : DefaultResponse
    {
        [JsonProperty(PropertyName = "data")]
        public string? Data { get; set; }

        [JsonProperty(PropertyName = "isComplete")]
        public bool? IsComplete { get; set; }
    }
}
