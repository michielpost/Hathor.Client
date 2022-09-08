using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class SignaturesResponse : DefaultResponse
    {
        [JsonProperty(PropertyName = "signatures")]
        public string? Signatures { get; set; }
    }
}
