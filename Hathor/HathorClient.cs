using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using System;

namespace Hathor
{
    public class HathorClient
    {
        public static IHathorApi GetClient(string baseUrl, string walletId)
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

            return hathorApi;
        }

    }
}
