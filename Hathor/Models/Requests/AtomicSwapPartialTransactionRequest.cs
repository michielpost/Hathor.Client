using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class AtomicSwapPartialTransactionRequest
    {
        [JsonProperty("partial_tx")]
        public string? PartialTx { get; set; }

        [JsonProperty("send")]
        public Send? Send { get; set; }

        [JsonProperty("receive")]
        public Receive? Receive { get; set; }

        /// <summary>
        /// If the utxos chosen for this proposal should be locked so they are not spent on another call. Use with caution
        /// </summary>
        [JsonProperty("lock")]
        public bool? Lock { get; set; }

        /// <summary>
        /// Optional address to send the change amount.
        /// </summary>
        [JsonProperty("change_address")]
        public string? ChangeAddress { get; set; }
    }

    public class Send
    {
        [JsonProperty("tokens")]
        public List<TokenForPartialSend> Tokens { get; set; } = new();

        [JsonProperty("utxos")]
        public List<UtxosForPartialSend>? Utxos { get; set; }
    }

    public class Receive
    {
        [JsonProperty("tokens")]
        public List<TokenForPartialReceive> Tokens { get; set; } = new();
    }

    public class TokenForPartialReceive
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }
    }

    public class TokenForPartialSend
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }
        
    }

    public class UtxosForPartialSend
    {
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("txId")]
        required public string TxId { get; set; }
    }
}
