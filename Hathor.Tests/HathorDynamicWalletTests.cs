using dotnetstandard_bip39;
using Hathor.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hathor.Tests
{
    /// <summary>
    /// DOCKER COMMAND: docker run -e HEADLESS_ALLOW_PASSPHRASE=true -e HEADLESS_SEED_DEFAULT=0 -p 127.0.0.1:8081:8000 hathornetwork/hathor-wallet-headless
    /// </summary>
    [TestClass]
    public class HathorDynamicWalletTests
    {
        private static IHathorWalletApi client = HathorClient.GetWalletClient("http://localhost:8081", WALLET_ID);
        private const string WALLET_ID = "wallet1";


        [TestMethod]

        public async Task StartDynamicWallet()
        {
            var bip39 = new BIP39();
            string passphrase = bip39.GenerateMnemonic(256, BIP39Wordlist.English);

            var req = new StartRequest(WALLET_ID, seedKey: null, seed: passphrase);
            var response = await client.Start(req);

            await client.Start(new StartRequest("w2", seedKey: null, seed: passphrase));
            await client.Start(new StartRequest("w3", seedKey: null, seed: passphrase));
            await client.Start(new StartRequest("w4", seedKey: null, seed: passphrase));

            //Assert.IsTrue(response.Success);

            //Wait untill wallet is ready
            await Task.Delay(TimeSpan.FromSeconds(2));

            var addressResponse = await client.GetAddress();
            var currentAddress = addressResponse.Address;
            Assert.IsFalse(string.IsNullOrEmpty(currentAddress));


            var stopResponse = await client.Stop();

            Assert.IsTrue(stopResponse.Success);
        }
        
    }
}
