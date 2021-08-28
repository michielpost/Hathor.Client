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

        [Get("thin_wallet/address_balance")]
        Task<BalanceForAddressResponse> GetBalanceForAddress([Query]string address);

        [Get("thin_wallet/token")]
        Task<TokenDataResponse> TokenData([Query] string id);

        [Get("validate_address/{address}")]
        Task<ValidateAddressResponse> ValidateAddress([Path] string address);

    }
}
