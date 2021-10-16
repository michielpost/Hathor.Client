using dotnetstandard_bip39;
using Hathor.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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
        private static IHathorNodeApi nodeClient = HathorClient.GetNodeClient("https://node1.testnet.hathor.network/v1a/");

        private static IHathorWalletApi client = HathorClient.GetWalletClient("http://localhost:8080", WALLET_ID, apiKey: "YOUR_KEY");
        private const string WALLET_ID = "wallet1";


        [TestMethod]

        public async Task StartDynamicWallet()
        {
            var bip39 = new BIP39();
            string passphrase = bip39.GenerateMnemonic(256, BIP39Wordlist.English);

            var req = new StartRequest(WALLET_ID, seedKey: null, seed: passphrase);
            var response = await client.Start(req);

            //Assert.IsTrue(response.Success);

            //Wait untill wallet is ready
            await Task.Delay(TimeSpan.FromSeconds(2));

            var addressResponse = await client.GetAddress();
            var currentAddress = addressResponse.Address;
            Assert.IsFalse(string.IsNullOrEmpty(currentAddress));


            var stopResponse = await client.Stop();

            Assert.IsTrue(stopResponse.Success);
        }

        [TestMethod]

        public async Task MassMoveNfts()
        {
            string seed = "";
            string toAddress = "";

            var req = new StartRequest(WALLET_ID, seedKey: null, seed: seed);
            var response = await client.Start(req);

            //Assert.IsTrue(response.Success);

            //Wait untill wallet is ready
            await Task.Delay(TimeSpan.FromSeconds(2));

            var addressResponse = await client.GetAddress(0);
            var currentAddress = addressResponse.Address;
            Assert.IsFalse(string.IsNullOrEmpty(currentAddress));

            var balance = await nodeClient.GetBalanceForAddress(currentAddress);
            var allTokens = balance.TokensData.Where(x => x.Value.Balance > 0);

            var chunks = allTokens.Chunk(16);

            foreach (var chunk in chunks)
            {
                if (!chunk.Any())
                    continue;

                List<Output> outputs = new List<Output>();
                foreach (var nft in chunk)
                {
                    outputs.Add(new Output(toAddress, nft.Value.Balance, nft.Key));
                }

                try
                {
                    var result = await client.SendTransaction(new SendTransactionRequest()
                    {
                        Outputs = outputs
                    });

                    await Task.Delay(TimeSpan.FromSeconds(8));

                }
                catch (Exception ex)
                {

                }

            }
        }
    }


    public static class IEnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> list, int chunkSize)
        {
            if (chunkSize <= 0)
            {
                throw new ArgumentException("chunkSize must be greater than 0.");
            }

            while (list.Any())
            {
                yield return list.Take(chunkSize);
                list = list.Skip(chunkSize);
            }
        }

    }
}
