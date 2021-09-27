using Hathor.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Node.Responses
{

    public class AddressSearchResponse : DefaultResponse
    {
        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; } = new();

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

}
