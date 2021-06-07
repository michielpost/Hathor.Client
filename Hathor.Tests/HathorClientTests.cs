using Hathor.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hathor.Tests
{
    [TestClass]
    public class HathorClientTests
    {
        private static IHathorApi client = HathorClient.GetClient("http://localhost:8000", WALLET_ID);
        private const string WALLET_ID = "wallet1";


        [ClassInitialize]
        public async static Task Start(TestContext context)
        {
            var req = new StartRequest(WALLET_ID, "default");
            var response = await client.Start(req);

            //Assert.IsTrue(response.Success);

            //Wait untill wallet is ready
            await Task.Delay(TimeSpan.FromSeconds(2));
        }

        [ClassCleanup]
        public async static Task Stop()
        {
            var response = await client.Stop();

            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public async Task GetStatus()
        {
            var response = await client.GetStatus();

            Assert.IsTrue(response.Success);
            Assert.AreEqual(3, response.StatusCode);
        }

        [TestMethod]
        public async Task GetBalance()
        {
            var response = await client.GetBalance();

            Assert.AreEqual(0, response.Available);
        }

        [TestMethod]
        public async Task GetBalanceForToken()
        {
            var response = await client.GetBalance("HTR");

            Assert.AreEqual(0, response.Available);
        }

        [TestMethod]
        public async Task GetBalanceForUnknownToken()
        {
            var response = await client.GetBalance(Guid.NewGuid().ToString());

            Assert.AreEqual(0, response.Available);
        }

        [TestMethod]
        public async Task GetCurrentAddress()
        {
            var response = await client.GetAddress();
            var currentAddress = response.Address;
            Assert.IsFalse(string.IsNullOrEmpty(currentAddress));
        }

        [TestMethod]
        public async Task GetAddress()
        {
            var response = await client.GetAddress();
            var currentAddress = response.Address;
            Assert.IsFalse(string.IsNullOrEmpty(currentAddress));

            //Mark as used
            response = await client.GetAddress(MarkAsUsed: true);
            Assert.AreEqual(currentAddress, response.Address);

            response = await client.GetAddress();
            Assert.AreNotEqual(currentAddress, response.Address);
        }

        [TestMethod]
        public async Task GetAddressIndex()
        {
            var response = await client.GetAddress();
            var currentAddress = response.Address;

            var indexResponse = await client.GetAddressIndex(currentAddress);
            Assert.IsTrue(indexResponse.Success);

            response = await client.GetAddress(index: indexResponse.Index);
            Assert.AreEqual(currentAddress, response.Address);
        }

        [TestMethod]
        public async Task GetAddressIndexInvalid()
        {
            var response = await client.GetAddressIndex("0x0");
            Assert.IsFalse(response.Success);
        }

        [TestMethod]
        public async Task GetAddressInfo()
        {
            var response = await client.GetAddress();
            var currentAddress = response.Address;

            var indexResponse = await client.GetAddressInfo(currentAddress);
            Assert.IsTrue(indexResponse.Success);

        }

        [TestMethod]
        public async Task GetAddressInfoInvalid()
        {
            var indexResponse = await client.GetAddressInfo("0x0");
            Assert.IsFalse(indexResponse.Success);

        }

        [TestMethod]
        public async Task GetAddresses()
        {
            var response = await client.GetAddresses();
            Assert.IsTrue(response.Addresses.Any());
        }

        [TestMethod]
        public async Task GetTxHistory()
        {
            var response = await client.GetTxHistory();
            Assert.IsTrue(response.Any());
        }

        [TestMethod]
        public async Task GetTransaction()
        {
            var txHistory = await client.GetTxHistory();

            var response = await client.GetTransaction(txHistory.First().TxId);
            Assert.IsTrue(response.Inputs.Any());
            Assert.IsTrue(response.Outputs.Any());
        }

        [TestMethod]
        public async Task SendZeroTransaction()
        {
            var transaction = new SendTransactionSimpleRequest("0x0", 0);
            var response = await client.SendTransaction(transaction);

            Assert.IsFalse(response.Success);
        }
    }
}
