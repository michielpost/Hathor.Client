using Hathor.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class EncodedTxWithSignaturesRequest : EncodedTxRequest
    {
        [JsonProperty(PropertyName = "signatures")]
        public List<string>? Signatures { get; }

        public EncodedTxWithSignaturesRequest(string txHex, List<string>? signatures = null)
            : base(txHex)
        {
            Signatures = signatures;
        }

    }
}
