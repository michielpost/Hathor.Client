using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class CreateTokenRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// The amount of tokens to mint. It must be an integer with the value in cents, i.e., 123 means 1.23.
        /// </summary>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// Destination address of the minted tokens.
        /// </summary>
        [JsonProperty("address")]
        public string? Address { get; set; }

        /// <summary>
        /// Optional address to send the change amount.
        /// </summary>
        [JsonProperty("change_address")]
        public string? ChangeAddress { get; set; }

        public CreateTokenRequest(string name, string symbol, int amount)
        {
            Name = name;
            Symbol = symbol;
            Amount = amount;
        }
    }
}
