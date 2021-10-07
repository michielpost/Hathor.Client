using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class SendTransactionSimpleRequest
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        /// <summary>
        /// Optional address to send the change amount.
        /// </summary>
        [JsonProperty("change_address")]
        public string? ChangeAddress { get; set; }

        /// <summary>
        /// SendTransactionRequest
        /// </summary>
        /// <param name="address">Address to send the tokens.</param>
        /// <param name="value">The value parameter must be an integer with the value in cents, i.e., 123 means 1.23 HTR.</param>
        public SendTransactionSimpleRequest(string address, int value, string? token = null)
        {
            Address = address;
            Value = value;
            Token = token;
        }
    }
}
