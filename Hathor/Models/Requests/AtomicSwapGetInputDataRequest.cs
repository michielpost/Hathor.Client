using Hathor.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class AtomicSwapGetInputDataRequest
    {
        [JsonProperty(PropertyName = "txHex")]
        public string? TxHex { get; set; }

    }
}
