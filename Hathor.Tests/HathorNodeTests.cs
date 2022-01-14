using Hathor.Extensions;
using Hathor.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Tests
{
    [TestClass]
    public class HathorNodeTests
    {
        private static IHathorNodeApi nodeClient = HathorClient.GetNodeClient("https://node.explorer.hathor.network/v1a/");

        [TestMethod]
        public async Task GetStatus()
        {
            var response = await nodeClient.GetStatus();

            Assert.AreEqual("mainnet", response.Server.Network);
        }

        [TestMethod]
        public async Task GetVersion()
        {
            var response = await nodeClient.GetVersion();

            Assert.AreEqual("mainnet", response.Network);
        }

        [TestMethod]
        public async Task GetBalance()
        {
            var response = await nodeClient.GetBalanceForAddress("HHNuQhBn5jGHaZ4ze2hJHdyp854js5qZoi");

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.TokensData.Any());
            Assert.IsTrue(response.TokensData.Where(x => x.Key == "00").Any());
            Assert.IsTrue(response.TokensData.Where(x => x.Key == "00").First().Value.Symbol == "HTR");
            Assert.IsTrue(response.TokensData.Where(x => x.Key == "00").First().Value.Received > 0);
            Assert.IsTrue(response.TokensData.Where(x => x.Key == "00").First().Value.Spent > 0);
        }

        [TestMethod]
        //[DataRow("HKpnvfpzPKgy4akYRtDrwdwTfx4Ky6EUda")]
        //[DataRow("HBPGgtpEWg9669JwUPXSGsdceMjKyoxM8H")]
        //[DataRow("HHNuQhBn5jGHaZ4ze2hJHdyp854js5qZoi")]
        //[DataRow("HPUCw6kFDNSVrk21n5MFrMP7w9a6WzkK8s")]
        [DataRow("HBBHnNYNS8mYJ3aFZ9kYGZmAzDh7FoZfnv")]

        public async Task CalculateBalance(string address)
        {
            var response = await nodeClient.CalculateBalanceForAddress(address);
            var responseActual = await nodeClient.GetBalanceForAddress(address);

            Assert.AreEqual(responseActual.TotalTransactions, response.TotalTransactions);

            foreach(var v in responseActual.TokensData)
            {
                var key = v.Key;
                
                var actualValue = v.Value;
                var calculatedValue = response.TokensData[key];

                Assert.AreEqual(actualValue.Balance, calculatedValue.Balance);
            }

            foreach (var v in response.TokensData)
            {
                var key = v.Key;

                var calculatedValue = v.Value;
                var actualValue = responseActual.TokensData[key];

                Assert.AreEqual(actualValue.Balance, calculatedValue.Balance);
            }

        }


        [TestMethod]
        public async Task GetBalanceForInvalidAddress()
        {
            var response = await nodeClient.GetBalanceForAddress("0x0");

            Assert.IsFalse(response.Success);
        }

        [TestMethod]
        public async Task ValidateValidAddress()
        {
            var response = await nodeClient.ValidateAddress("H7j5toHdk2zi7z8PXpeAcrB62CSpruNo8k");

            Assert.IsTrue(response.Valid);
        }

        [TestMethod]
        public async Task ValidateInvalidAddress()
        {
            var response = await nodeClient.ValidateAddress("0x");

            Assert.IsFalse(response.Valid);
        }

        [TestMethod]
        public async Task GetTokenData()
        {
            var response = await nodeClient.TokenData("00000000d4a32bdfee6a3b0b46cd488379c9cf059f4d636ec1550f57d9351f01");

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.CanMint);
            Assert.IsTrue(response.CanMelt);
        }

        [TestMethod]
        public async Task GetNFT()
        {
            var response = await nodeClient.GetBalanceForAddress("HRaA13M5hYcnimgB8phwpcJ9eTbTsgdPGL");

            foreach (var token in response.TokensData)
            {
                //Get tokens
                //var tokenData = await nodeClient.TokenData(token.Key);

                //Get first transaction of token
                //var txHistory = await nodeClient.TokenHistory(token.Key);

                //Token ID is also the ID of the first transaction
                var txData = await nodeClient.Transaction(token.Key);

                byte[] data = Convert.FromBase64String(txData.Tx.Outputs.First().Script);
                string decodedString = Encoding.ASCII.GetString(data);

                var url = ScriptDataHelper.GetDataUrl(decodedString);
            }
        }

        [TestMethod]
        [DataRow("00000000a0ae3dc5ec12be3cb8192f9b5e55552ea8d244c98358edac313b09e1")]
        [DataRow("0000000066ddf8af375cd00e9d121ebcfd939b5f822c94b0e245df16b0de2a1f")]
        [DataRow("000005bd6142ffa45bce048cc9a22f2500cc5b76482c24a0a3d359e34505d0c9")]
        [DataRow("000009914c546a3b44c9978ae7c9c9dfaa44a3f229774423a10807c7d51e1dea")]
        [DataRow("00000000f4ad005dbaa8a6fe6e4a99e45ad636314b4ef13abce2dece61603c6b")]
        public async Task GetNFTUrl(string tokenId)
        {
            var txData = await nodeClient.Transaction(tokenId);

            byte[] data = Convert.FromBase64String(txData.Tx.Outputs.First().Script);
            string decodedString = Encoding.ASCII.GetString(data);

            var url = ScriptDataHelper.GetDataUrl(decodedString);

            Assert.IsNotNull(url);

            var mintAddress = txData.Tx.Outputs.Where(x => x.TokenData == 1).First().Decoded.Address;
            Assert.IsNotNull(mintAddress);

        }

        [TestMethod]
        public async Task GetAddressHistory()
        {
            var response = await nodeClient.GetAddressHistory("HRaA13M5hYcnimgB8phwpcJ9eTbTsgdPGL");

            Assert.IsTrue(response.History.Any());
            Assert.IsNull(response.HasMore);
           
        }

        [TestMethod]
        public async Task GetAddressHistoryPaginate()
        {
            var response = await nodeClient.GetAddressHistoryPaginate("HRaA13M5hYcnimgB8phwpcJ9eTbTsgdPGL");

            Assert.IsTrue(response.History.Any());
            Assert.IsNotNull(response.HasMore);

        }

        [TestMethod]
        public async Task GetAddressHistoryMultiple()
        {
            var response1 = await nodeClient.GetAddressHistory("HRaA13M5hYcnimgB8phwpcJ9eTbTsgdPGL");
            var response2 = await nodeClient.GetAddressHistory("HS3LsvXzBU5yWPPUY6pjgMKXDZWGa3MeFp");

            int total = response1.History.Count + response2.History.Count;

            var responseMerged = await nodeClient.GetAddressHistory("HRaA13M5hYcnimgB8phwpcJ9eTbTsgdPGL", "HS3LsvXzBU5yWPPUY6pjgMKXDZWGa3MeFp");

            Assert.IsTrue(response1.History.Any());
            Assert.IsTrue(response2.History.Any());
            Assert.AreEqual(total, responseMerged.History.Count());

        }

    }
}

