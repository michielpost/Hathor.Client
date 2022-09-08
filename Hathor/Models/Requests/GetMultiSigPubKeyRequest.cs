using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Requests
{
    public class GetMultiSigPubKeyRequest
    {

        /// <summary>
        /// Key of the corresponding seed in the config file to create the wallet.
        /// </summary>
        [JsonProperty(PropertyName = "seedKey")]
        public string SeedKey { get; set; }

        /// <summary>
        /// Passphrase of the wallet that will be created.
        /// </summary>
        [JsonProperty(PropertyName = "passphrase")]
        public string? Passphrase { get; set; }

        public GetMultiSigPubKeyRequest(string seedKey, string? passphrase = null)
        {
            SeedKey = seedKey;
            Passphrase = passphrase;
        }

    }
}
