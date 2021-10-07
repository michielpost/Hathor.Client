using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class StatusResponse : DefaultResponse
    {
        [JsonProperty(PropertyName = "serverInfo")]
        public string? ServerInfo { get; set; }

        [JsonProperty(PropertyName = "statusCode")]
        public int? StatusCode { get; set; }

        [JsonProperty(PropertyName = "network")]
        public string? Network { get; set; }

        [JsonProperty(PropertyName = "serverUrl")]
        public string? ServerUrl { get; set; }

        [JsonProperty(PropertyName = "state")]
        public int? State { get; set; }
    }
}
