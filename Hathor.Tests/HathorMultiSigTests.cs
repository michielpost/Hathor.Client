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
    /// Make sure to configure your headless wallet for MultiSig as described here:
    /// https://github.com/HathorNetwork/hathor-wallet-headless/blob/master/MULTISIG.md
    /// https://hathor.gitbook.io/hathor/guides/multisig-wallet/sending-transactions
    /// </summary>
    [TestClass]
    public class HathorMultiSigTests
    {
        private static IHathorWalletApi clientMultiSig1 = HathorClient.GetWalletClient("http://localhost:8000", MULTI1_ID);
        private const string MULTI1_ID = "multisig1";

        private static IHathorWalletApi clientMultiSig2 = HathorClient.GetWalletClient("http://localhost:8000", MULTI2_ID);
        private const string MULTI2_ID = "multisig2";

        private SendTransactionRequest transaction = new SendTransactionRequest()
        {
            Outputs = new System.Collections.Generic.List<Output>()
                {
                    new Output("WQu8rgRDvXPBWFHAguuvH186G6NhgAQvxs", 1, "00")
                }
        };


        [ClassInitialize]
        public async static Task Start(TestContext context)
        {
            var multi1Response = await clientMultiSig1.Start(new StartRequest(MULTI1_ID, MULTI1_ID, multiSig: true));
            var multi2Response = await clientMultiSig2.Start(new StartRequest(MULTI2_ID, MULTI2_ID, multiSig: true));

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
        public async Task GetMultiSigPubKeys()
        {
            var xpubkey1 = await clientMultiSig1.MultiSigGetPubKey(new GetMultiSigPubKeyRequest("multisig1"));
            var xpubkey2 = await clientMultiSig1.MultiSigGetPubKey(new GetMultiSigPubKeyRequest("multisig2"));
            var xpubkey3 = await clientMultiSig1.MultiSigGetPubKey(new GetMultiSigPubKeyRequest("multisig3"));
            var xpubkey4 = await clientMultiSig1.MultiSigGetPubKey(new GetMultiSigPubKeyRequest("multisig4"));

            Assert.IsTrue(xpubkey1.Success);
            Assert.IsTrue(xpubkey2.Success);
            Assert.IsTrue(xpubkey3.Success);
            Assert.IsTrue(xpubkey4.Success);
        }

        [TestMethod]
        public async Task StartMultiSigWallet()
        {
            var req = new StartRequest(MULTI1_ID, MULTI1_ID, multiSig: true);
            var response = await clientMultiSig1.Start(req);

            //Wait untill wallet is ready
            await Task.Delay(TimeSpan.FromSeconds(2));

            //Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public async Task GetAddressInfo()
        {
            var response = await clientMultiSig1.GetAddress(0);
            var currentAddress = response.Address;

            var response2 = await clientMultiSig2.GetAddress(0);
            var currentAddress2 = response2.Address;

            var indexResponse = await clientMultiSig1.GetAddressInfo(currentAddress);
            Assert.IsTrue(indexResponse.Success);

        }


        [TestMethod]
        public async Task SendTransaction_WithoutSignatures_Fails()
        {
            var response = await clientMultiSig1.SendTransaction(transaction);

            Assert.IsFalse(response.Success);
        }

        [TestMethod]
        public async Task GetProposal_For_Transaction_And_Decode_Signature()
        {
            var response = await clientMultiSig1.MultiSigSendTransactionProposal(transaction);

            Assert.IsTrue(response.Success);
            Assert.IsNotNull(response.TxHex);

            var decoded = await clientMultiSig1.Decode(new DecodeRequest() { TxHex = response.TxHex });

            Assert.IsNotNull(decoded);
            Assert.IsTrue(decoded.Success);
            Assert.IsNotNull(decoded.Tx);
            Assert.AreEqual(transaction.Outputs.First().Address, decoded.Tx.Outputs.Last().Decoded.Address);
            Assert.AreEqual(transaction.Outputs.First().Value, decoded.Tx.Outputs.Last().Value);

        }

        [TestMethod]
        public async Task GetSignatures_And_SendTransaction()
        {
            var proposal = await clientMultiSig1.MultiSigSendTransactionProposal(transaction);

            var signature1 = await clientMultiSig1.MultiSigGetMySignaturesForTxProposal(new EncodedTxRequest(proposal.TxHex));
            var signature2 = await clientMultiSig2.MultiSigGetMySignaturesForTxProposal(new EncodedTxRequest(proposal.TxHex));

            Assert.IsNotNull(signature1);
            Assert.IsTrue(signature1.Success);

            Assert.IsNotNull(signature2);
            Assert.IsTrue(signature2.Success);

            var sign = await clientMultiSig1.MultiSigSignTxProposal(new EncodedTxWithSignaturesRequest(proposal.TxHex, new List<string> { signature1.Signatures, signature2.Signatures }));
            var multisigResponse = await clientMultiSig1.MultiSigSignAndPush(new EncodedTxWithSignaturesRequest(proposal.TxHex, new System.Collections.Generic.List<string>() { signature1.Signatures, signature2.Signatures }));

            Assert.IsNotNull(multisigResponse);
            Assert.IsTrue(multisigResponse.Success);

        }


    }
}
