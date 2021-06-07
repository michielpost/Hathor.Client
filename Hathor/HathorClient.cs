using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using System;

namespace Hathor
{
    public class HathorClient
    {
        public static IHathorApi GetClient(string baseUrl, string walletId = "default")
        {
            var hathorApi = new RestClient(baseUrl)
            {

                JsonSerializerSettings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                }
            }.For<IHathorApi>();

            hathorApi.WalletId = walletId;

            return hathorApi;
        }

    }
}
