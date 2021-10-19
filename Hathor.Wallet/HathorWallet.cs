using NBitcoin;
using System;

namespace Hathor.Wallet
{
    public class HathorWallet
    {
        private readonly int index;
        private readonly ExtKey masterKey;
        private readonly Network network;

        public HathorWallet(HathorNetwork hathorNetwork, string seed, int index, Wordlist? wordList = null)
        {
            if (wordList == null)
                wordList = Wordlist.English;

            var mnemo = new Mnemonic(seed, wordList);
            masterKey = mnemo.DeriveExtKey();

            network = HathorAddressHelper.GetNetwork(hathorNetwork);

            this.index = index;
        }

        public string GetAddress()
        {
            ExtKey key = masterKey.Derive(new KeyPath($"m/44'/280'/0'/0/{index}"));
            var address = key.GetPublicKey().GetAddress(ScriptPubKeyType.Legacy, network);

            return address.ToString();
        }
    }
}
