using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class AddressIndexResponse : DefaultResponse
    {
        [JsonProperty(PropertyName = "index")]
        public int Index { get; set; } = default!;
    }
}
