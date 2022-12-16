using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class AtomicSwapPartialTxRequest
    {
        [JsonProperty("partial_tx")]
        required public string PartialTx { get; set; }
    }
}
