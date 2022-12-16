using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class AtomicSwapGetLockedUtxosResponse : DefaultResponse
    {
        [JsonProperty("locked_utxos")]
        public List<LockedUtxo> LockedUtxos { get; set; } = new();
    }

    public class LockedUtxo
    {
        [JsonProperty("tx_id")]
        public string TxId { get; set; } = default!;

        [JsonProperty("outputs")]
        public List<int> Outputs { get; set; } = new();
    }
}
