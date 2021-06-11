using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using System;

namespace Hathor
{
    public class HathorClient
    {
        public static IHathorApi GetClient(string baseUrl, string walletId, string? apiKey = null)
        {
            var hathorApi = new RestClient(baseUrl)
            {

                JsonSerializerSettings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    Error = (serializer, err) => err.ErrorContext.Handled = true
        }
            }.For<IHathorApi>();

            hathorApi.WalletId = walletId;
            hathorApi.ApiKey = apiKey;

            return hathorApi;
        }

    }
}
