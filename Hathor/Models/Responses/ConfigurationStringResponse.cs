using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class ConfigurationStringResponse : DefaultResponse
    {
        [JsonProperty("configurationString")]
        public string ConfigurationString { get; set; } = default!;
    }
}
