using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Node.Responses
{
    public class ValidateAddressResponse
    {
        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("script")]
        public string? Script { get; set; }

        [JsonProperty("address")]
        public string? Address { get; set; }
    }
}
