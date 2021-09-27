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
        private static IHathorNodeApi nodeClient = HathorClient.GetNodeClient("https://node2.mainnet.hathor.network/v1a/");

        [TestMethod]
        public async Task GetVersion()
        {
            var response = await nodeClient.GetVersion();

            Assert.AreEqual("mainnet", response.Network);
        }

        [TestMethod]
        public async Task GetBalance()
        {
            var response = await nodeClient.GetBalanceForAddress("H7j5toHdk2zi7z8PXpeAcrB62CSpruNo8k");

            Assert.IsTrue(response.Success);
            Assert.IsTrue(response.TokensData.Any());
            Assert.IsTrue(response.TokensData.Where(x => x.Key == "00").Any());
            Assert.IsTrue(response.TokensData.Where(x => x.Key == "00").First().Value.Symbol == "HTR");
            Assert.IsTrue(response.TokensData.Where(x => x.Key == "00").First().Value.Received > 0);
            Assert.IsTrue(response.TokensData.Where(x => x.Key == "00").First().Value.Spent > 0);
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
            var response = await nodeClient.TokenData("00000000f18cc6241c7076aa26cfc78771a191e5d615f5c06451fe06c563bbc3");

            Assert.IsTrue(response.Success);
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
            }
        }

        [TestMethod]
        public async Task GetAddressHistory()
        {
            var response = await nodeClient.GetAddressHistory("HRaA13M5hYcnimgB8phwpcJ9eTbTsgdPGL");

            Assert.IsTrue(response.History.Any());
           
        }

    }
}

