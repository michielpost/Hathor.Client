using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class UtxoConsolidationResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("total_utxos_consolidated")]
        public int TotalUtxosConsolidated { get; set; }

        [JsonProperty("total_amount")]
        public int TotalAmount { get; set; }

        [JsonProperty("utxos")]
        public List<Utxo> Utxos { get; set; } = new();
    }
}
