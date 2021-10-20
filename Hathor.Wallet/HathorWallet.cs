using NBitcoin;
using System;

namespace Hathor.Wallet
{
    public class HathorWallet
    {
        private readonly ExtKey masterKey;
        private readonly Network network;

        public HathorWallet(HathorNetwork hathorNetwork, string seed, Wordlist? wordList = null)
        {
            if (wordList == null)
                wordList = Wordlist.English;

            var mnemo = new Mnemonic(seed, wordList);
            masterKey = mnemo.DeriveExtKey();

            network = HathorAddressHelper.GetNetwork(hathorNetwork);
        }

        public string GetAddress(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), "Should be 0 or higher");

            ExtKey key = masterKey.Derive(new KeyPath($"m/44'/280'/0'/0/{index}"));
            var address = key.GetPublicKey().GetAddress(ScriptPubKeyType.Legacy, network);

            return address.ToString();
        }
    }
}
