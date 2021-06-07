using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class AddressResponse
    {
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; } = default!;
    }
}
