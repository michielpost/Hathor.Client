using Hathor.Models.Requests;
using Hathor.Models.Responses;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor
{
    public interface IHathorApi
    {
        [Header("x-wallet-id")]
        string WalletId { get; set; }

        [Post("start")]
        Task<DefaultResponse> Start([Body]StartRequest startRequest);

        [Get("wallet/status")]
        Task<StatusResponse> GetStatus();

        [Get("wallet/balance")]
        Task<BalanceResponse> GetBalance([Query]string? token = null);

        /// <summary>
        /// Return the current address
        /// </summary>
        /// <param name="MarkAsUsed">Mark the current address as used. So, it will return a new address in the next call.</param>
        /// <returns></returns>
        [Get("wallet/address")]
        Task<AddressResponse> GetAddress([Query("mark_as_used", QuerySerializationMethod.Serialized)] bool? MarkAsUsed = null);

        /// <summary>
        /// Return the current address
        /// </summary>
        /// <param name="index">Get the address in this specific derivation path index.</param>
        /// <returns></returns>
        [Get("wallet/address")]
        Task<AddressResponse> GetAddress([Query] int index);

        [Get("wallet/address-index")]
        Task<AddressIndexResponse> GetAddressIndex([Query] string address);

        [Get("wallet/addresses")]
        Task<AddressesResponse> GetAddresses();

    }
}
