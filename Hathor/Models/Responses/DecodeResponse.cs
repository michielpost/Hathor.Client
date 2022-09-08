using Hathor.Models.Node.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class DecodeResponse : DefaultResponse
    {
        [JsonProperty("tx")]
        public Tx? Tx { get; set; }
    }
}
