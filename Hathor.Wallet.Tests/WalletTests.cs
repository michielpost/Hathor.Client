using dotnetstandard_bip39;
using Hathor.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Wallet.Tests
{
    [TestClass]
    public class WalletTests
    {
        private static IHathorWalletApi client = HathorClient.GetWalletClient("http://localhost:8082", WALLET_ID, apiKey: "YOUR_KEY");
        private const string WALLET_ID = "wallet1";


        [TestMethod]

        public async Task StartDynamicWallet()
        {
            var bip39 = new BIP39();
            string seed = bip39.GenerateMnemonic(256, BIP39Wordlist.English);

            var req = new StartRequest(WALLET_ID, seedKey: null, seed: seed);
            var response = await client.Start(req);

            //Assert.IsTrue(response.Success);

            //Wait untill wallet is ready
            await Task.Delay(TimeSpan.FromSeconds(2));

            var addressResponse = await client.GetAddress();
            var currentAddress = addressResponse.Address;
            Assert.IsFalse(string.IsNullOrEmpty(currentAddress));

            var wallet = new HathorWallet(HathorNetwork.Mainnet, seed);


            for (int i = 0; i < 20; i++)
            {
                var address = wallet.GetAddress(i);

                var dynamicAddress = await client.GetAddress(i);

                Assert.AreEqual(address, dynamicAddress.Address);

            }

            var stopResponse = await client.Stop();
            Assert.IsTrue(stopResponse.Success);
        }

    }
}
