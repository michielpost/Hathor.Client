using Hathor.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class DecodeRequest
    {
        [JsonProperty(PropertyName = "txHex")]
        public string? TxHex { get; set; }

        [JsonProperty(PropertyName = "partial_tx")]
        public string? PartialTx { get; set; }

    }
}
