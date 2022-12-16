using Hathor.Models.Node.Responses;
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
        private static IHathorWalletApi client = HathorClient.GetWalletClient("http://localhost:8000", WALLET_ID);
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

        //[ClassCleanup]
        //public async static Task Stop()
        //{
        //    var response = await client.Stop();

        //    Assert.IsTrue(response.Success);
        //}

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
            var response = await client.GetAddress(0);
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
        public async Task GetTxConfirmationBlocks()
        {
            var txHistory = await client.GetTxHistory();

            var confirmationsResponse = await client.GetTxConfirmationBlocks(txHistory.First().TxId);
            Assert.IsTrue(confirmationsResponse.Success);

        }

        [TestMethod]
        public async Task SendZeroTransaction()
        {
            var transaction = new SendTransactionSimpleRequest("0x0", 0);
            var response = await client.SendTransaction(transaction);

            Assert.IsFalse(response.Success);
        }

        [TestMethod]
        public async Task UtxoFilter()
        {
            var response = await client.GetAddress(50);
            string address = response.Address;

            var filter = await client.UtxoFilter(filterAddress: address, onlyAvailableUtxos: true);

            Assert.IsNotNull(filter);
        }

        [TestMethod]
        public async Task UtxoConsolidation()
        {
            var mainResponse = await client.GetAddress(0);
            string mainAaddress = mainResponse.Address;


            var response = await client.GetAddress(50);
            string filterAaddress = response.Address;

            var req = new UtxoConsolidationRequest()
            {
                FilterAddress = filterAaddress,
                DestinationAddress = mainAaddress
            };

            var consolidation = await client.UtxoConsolidation(req);

            Assert.IsNotNull(consolidation);
        }

        [TestMethod]
        public async Task CreateToken()
        {
            var transaction = new CreateTokenRequest("Testnet Token", "T01", 10);
            var response = await client.CreateToken(transaction);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.ConfigurationString);

        }

        [TestMethod]
        public async Task GetConfigurationString()
        {
            var response = await client.GetConfigurationString("007ca0773f7a9998bbca4c089ba836b6f75edac95cf0ad957a3d01f970ce31cc");

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.ConfigurationString);
        }


        [TestMethod]
        public async Task CreateTokenMintAndMeltTest()
        {
            var addressResponse = await client.GetAddress(0);
            var currentAddress = addressResponse.Address;

            var transaction = new CreateTokenRequest("Testnet MM Token", "TMM", 10);
            transaction.Address = currentAddress;
            var response = await client.CreateToken(transaction);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.ConfigurationString);

            var tokenId = response.Hash;

            //Check the balance:
            var balance = await client.GetBalance(tokenId);
            Assert.AreEqual(10, balance.Available);

            //Mint some more tokens
            var mintResponse = await client.MintTokens(new MintTokensRequest(tokenId, currentAddress, 10));
            Assert.IsTrue(mintResponse.Success);

            balance = await client.GetBalance(tokenId);
            Assert.AreEqual(20, balance.Available);

            //Melt some tokens
            var meltResponse = await client.MeltTokens(new MeltTokensRequest(tokenId, 20));
            Assert.IsTrue(meltResponse.Success);

            balance = await client.GetBalance(tokenId);
            Assert.AreEqual(0, balance.Available);
        }
    }
}
