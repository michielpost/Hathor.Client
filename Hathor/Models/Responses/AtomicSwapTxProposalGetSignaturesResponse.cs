using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class AtomicSwapTxProposalGetSignaturesResponse : DefaultResponse
    {
        [JsonProperty(PropertyName = "signatures")]
        public string? Signatures { get; set; }
    }
}