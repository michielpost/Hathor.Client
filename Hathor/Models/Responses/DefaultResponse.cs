using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class DefaultResponse
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; } = true;

        [JsonProperty(PropertyName = "message")]
        public string? Message { get; set; }

        [JsonProperty(PropertyName = "statusMessage")]
        public string? StatusMessage { get; set; }
    }
}
