using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class UtxoFilterResponse
    {
        [JsonProperty("total_amount_available")]
        public int? TotalAmountAvailable { get; set; }

        [JsonProperty("total_utxos_available")]
        public int? TotalUtxosAvailable { get; set; }

        [JsonProperty("total_amount_locked")]
        public int? TotalAmountLocked { get; set; }

        [JsonProperty("total_utxos_locked")]
        public int? TotalUtxosLocked { get; set; }

        [JsonProperty("utxos")]
        public List<Utxo> Utxos { get; set; } = new();
    }

    public class Utxo
    {
        [JsonProperty("address")]
        public string Address { get; set; } = default!;

        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("tx_id")]
        public string? TxId { get; set; }

        [JsonProperty("locked")]
        public bool? Locked { get; set; }

        [JsonProperty("index")]
        public int? Index { get; set; }
    }
}
