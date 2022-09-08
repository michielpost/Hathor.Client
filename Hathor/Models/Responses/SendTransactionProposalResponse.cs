using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class SendTransactionProposalResponse : DefaultResponse
    {
        [JsonProperty(PropertyName = "txHex")]
        public string? TxHex { get; set; }

    }
}
