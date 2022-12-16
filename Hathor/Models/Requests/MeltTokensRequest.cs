using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class MeltTokensRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Destination address of the minted tokens.
        /// </summary>
        [JsonProperty("deposit_address")]
        public string? DepositAddress { get; set; }

        /// <summary>
        /// Optional address to send the change amount.
        /// </summary>
        [JsonProperty("change_address")]
        public string? ChangeAddress { get; set; }

        public MeltTokensRequest(string token, int amount)
        {
            Token = token;
            Amount = amount;
        }
    }
}
