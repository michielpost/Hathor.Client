using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class SendTransactionResponse : Transaction
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        [JsonProperty("hash")]
        public new string? TxId { get; set; } 

        [JsonProperty("nonce")]
        public int Nonce { get; set; }
    }
}
