using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class BalanceResponse : DefaultResponse
    {
        [JsonProperty(PropertyName = "available")]
        public int? Available { get; set; }

        [JsonProperty(PropertyName = "locked")]
        public int? Locked { get; set; }


    }
}
