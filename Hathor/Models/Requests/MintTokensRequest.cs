using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class MintTokensRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Destination address of the minted tokens.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Optional address to send the change amount.
        /// </summary>
        [JsonProperty("change_address")]
        public string? ChangeAddress { get; set; }

        public MintTokensRequest(string token, string address, int amount)
        {
            Token = token;
            Address = address;
            Amount = amount;
        }
    }
}
