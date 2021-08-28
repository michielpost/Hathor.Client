using Hathor.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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
            var response = await nodeClient.TokenData("0000000022280ea3571c3ae04155718c6d4540846b846d5a1fceb903956cc4ea");

            Assert.IsTrue(response.Success);
        }
    }
}
