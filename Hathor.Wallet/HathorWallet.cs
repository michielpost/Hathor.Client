using Hathor.Extensions;
using Hathor.Models.Node.Responses;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hathor.Wallet
{
    public class HathorWallet
    {
        private readonly ExtKey masterKey;
        private readonly Network network;
        private readonly IHathorNodeApi hathorNodeApi;

        public HathorWallet(IHathorNodeApi hathorNodeApi, HathorNetwork hathorNetwork, string seed, Wordlist? wordList = null)
        {
            if (wordList == null)
                wordList = Wordlist.English;

            var mnemo = new Mnemonic(seed, wordList);
            masterKey = mnemo.DeriveExtKey();

            network = HathorAddressHelper.GetNetwork(hathorNetwork);
            this.hathorNodeApi = hathorNodeApi;
        }

        public string GetAddress(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Should be 0 or higher");

            ExtKey key = masterKey.Derive(new KeyPath($"m/44'/280'/0'/0/{index}"));
            var address = key.GetPublicKey().GetAddress(ScriptPubKeyType.Legacy, network);

            return address.ToString();
        }

        public Task<AddressHistoryResponse> GetTxHistory(params int[] indexes)
        {
            var addresses = indexes.Select(x => GetAddress(x)).ToArray();
            return hathorNodeApi.GetAddressHistory(addresses);
        }

        public Task<BalanceForAddressResponse> CalculateBalanceForAddress(int index)
        {
            var address = GetAddress(index);
            return hathorNodeApi.CalculateBalanceForAddress(address);
        }

    }
}
