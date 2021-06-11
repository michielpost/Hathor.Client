using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestEase;
using System;

namespace Hathor
{
    public class HathorClient
    {
        public static IHathorWalletApi GetWalletClient(string baseUrl, string walletId, string? apiKey = null)
        {
            var hathorApi = new RestClient(baseUrl)
            {

                JsonSerializerSettings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    Error = (serializer, err) => err.ErrorContext.Handled = true
        }
            }.For<IHathorWalletApi>();

            hathorApi.WalletId = walletId;
            hathorApi.ApiKey = apiKey;

            return hathorApi;
        }

        public static IHathorNodeApi GetNodeClient(string baseUrl)
        {
            var hathorApi = new RestClient(baseUrl)
            {

                JsonSerializerSettings = new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    Error = (serializer, err) => err.ErrorContext.Handled = true
                }
            }.For<IHathorNodeApi>();

            return hathorApi;
        }

    }
}
