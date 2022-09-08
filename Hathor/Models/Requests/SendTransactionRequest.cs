using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class SendTransactionRequest
    {
        [JsonProperty("outputs")]
        public List<Output> Outputs { get; set; } = new List<Output>();

        [JsonProperty("inputs")]
        public List<Input>? Inputs { get; set; }

        /// <summary>
        /// Optional address to send the change amount.
        /// </summary>
        [JsonProperty("change_address")]
        public string? ChangeAddress { get; set; }
    }

    public class Output
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        public Output(string address, int value, string token)
        {
            Address = address;
            Value = value;
            Token = token;
        }
    }

    public class Input
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        public Input(string hash, int index)
        {
            Hash = hash;
            Index = index;
        }
    }


}
