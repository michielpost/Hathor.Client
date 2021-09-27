using Hathor.Models.Node.Responses;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor
{
    public interface IHathorNodeApi
    {
        [Get("version")]
        Task<VersionResponse> GetVersion();

        [Get("validate_address/{address}")]
        Task<ValidateAddressResponse> ValidateAddress([Path] string address);

        [Get("transaction")]
        Task<TransactionResponse> Transaction([Query] string id);

        [Get("decode_tx")]
        Task<TransactionResponse> DecodeTransaction([Query] string hex_tx);

        [Get("thin_wallet/address_balance")]
        Task<BalanceForAddressResponse> GetBalanceForAddress([Query] string address);

        [Get("thin_wallet/address_history")]
        Task<AddressHistoryResponse> AddressHistory([Query] string[] addresses);

        [Get("thin_wallet/address_search")]
        Task<AddressSearchResponse> AddressSearch([Query] string address, [Query] int count, [Query] string page, [Query] string hash);


        [Get("thin_wallet/token")]
        Task<TokenDataResponse> TokenData([Query] string id);

        [Get("thin_wallet/token_history")]
        Task<TokenHistoryResponse> TokenHistory([Query] string id, [Query] int? count = null, [Query] string? page = null, [Query] string? hash = null, [Query] int? timestamp = null);

        
    }
}
