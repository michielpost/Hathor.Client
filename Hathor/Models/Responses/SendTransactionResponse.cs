using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class SendTransactionResponse : TransactionResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error")]
        public string? Error { get; set; }

        //[JsonProperty("tx")]
        //public TransactionResponse Tx { get; set; } = default!;

    }

    public class TransactionResponse
    {
        [JsonProperty("hash")]
        public new string? TxId { get; set; }

        [JsonProperty("nonce")]
        public int Nonce { get; set; }
        
    }
   
}