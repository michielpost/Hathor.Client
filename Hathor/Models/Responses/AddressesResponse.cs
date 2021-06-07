using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class AddressesResponse
    {
        [JsonProperty(PropertyName = "addresses")]
        public List<string> Addresses { get; set; } = new List<string>();
    }
}
