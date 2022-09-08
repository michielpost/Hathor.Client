using Hathor.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class EncodedTxRequest
    {
        [JsonProperty(PropertyName = "txHex")]
        public string TxHex { get; set; }

        public EncodedTxRequest(string txHex)
        {
            TxHex = txHex;
        }

    }
}
