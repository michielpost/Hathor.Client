using dotnetstandard_bip39;
using Hathor.Models.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Hathor.Tests
{
    /// <summary>
    /// https://hathor.gitbook.io/hathor/guides/headless-wallet/atomic-swap
    /// </summary>
    [TestClass]
    public class HathorAtomicSwapTests
    {
        private static IHathorWalletApi clientAlice = HathorClient.GetWalletClient("http://localhost:8000", ALICE_ID);
        private const string ALICE_ID = "alice";

        private static IHathorWalletApi clientBob = HathorClient.GetWalletClient("http://localhost:8000", BOB_ID);
        private const string BOB_ID = "bob";

        [ClassInitialize]
        public async static Task Start(TestContext context)
        {
            var aliceSeed = "work above economy captain advance bread logic paddle copper change maze tongue salon sadness cannon fish debris need make purpose usage worth vault shrug";
            var bobSeed = "side satoshi artwork genre teach nephew bring crush rack define someone illegal trend sphere breeze able paper bracket unit wash about heart sight fringe";

            var aliceResponse = await clientAlice.Start(new StartRequest(ALICE_ID, seedKey: null, seed: aliceSeed));
            var bobResponse = await clientBob.Start(new StartRequest(BOB_ID, seedKey: null, seed: bobSeed));

            Assert.IsTrue(aliceResponse.Success);
            Assert.IsTrue(bobResponse.Success);

            //Wait untill wallet is ready
            await Task.Delay(TimeSpan.FromSeconds(2));
        }

        //[ClassCleanup]
        //public async static Task Stop()
        //{
        //    var response1 = await clientAlice.Stop();
        //    var response2 = await clientBob.Stop();

        //}


        [TestMethod]
        public async Task GetAddressInfo()
        {
            var response = await clientAlice.GetAddress(0);
            var currentAddress = response.Address;

            var response2 = await clientBob.GetAddress(0);
            var currentAddress2 = response2.Address;

        }

        [TestMethod]
        public async Task GetLockedUtxosTest()
        {
            var response = await clientAlice.AtomicSwapGetLockedUtxos();
            Assert.IsTrue(response.Success);
        }

        [TestMethod]
        public async Task UnlockedUtxosTest()
        {
            //Unlock
            string unlockId = "";
            var unlockResponse = await clientAlice.AtomicSwapUnlock(new AtomicSwapPartialTxRequest { PartialTx = unlockId });
            Assert.IsTrue(unlockResponse.Success);
        }


        [TestMethod]
        public async Task AtomicSwapTest()
        {
            //Check if there is HTR to create custom tokens
            var aliceHtr = await clientAlice.GetBalance();
            var bobHtr = await clientBob.GetBalance();

            Assert.IsTrue(aliceHtr.Available > 100);
            Assert.IsTrue(bobHtr.Available > 100);

            //Setup
            //Alice has 2 Alice tokens
            var createAliceTokenResponse = await clientAlice.CreateToken(new CreateTokenRequest("Alice Token", "Alice", 2));
            Assert.IsTrue(createAliceTokenResponse.Success);

            //Bob has 10 Bob tokens
            var createBobTokenResponse = await clientBob.CreateToken(new CreateTokenRequest("Bob Token", "Bob", 10));
            Assert.IsTrue(createBobTokenResponse.Success);

            var aliceTokenId = createAliceTokenResponse.Hash;
            var bobTokenId = createBobTokenResponse.Hash;

            //Alice should have 2 Alice token and 0 BOB tokens
            var aliceAliceToken = await clientAlice.GetBalance(aliceTokenId);
            var aliceBobToken = await clientAlice.GetBalance(bobTokenId);

            Assert.AreEqual(2, aliceAliceToken.Available);
            Assert.AreEqual(0, aliceBobToken.Available);

            //Bob should have 0 Alice token and 10 Bob tokens
            var bobAliceToken = await clientBob.GetBalance(aliceTokenId);
            var bobBobToken = await clientBob.GetBalance(bobTokenId);

            Assert.AreEqual(0, bobAliceToken.Available);
            Assert.AreEqual(10, bobBobToken.Available);

            ///////////////////////////////////////////////////
            //Step 1: Alice creates a first partial of the transaction proposal
            //https://hathor.gitbook.io/hathor/guides/headless-wallet/atomic-swap#step-1-alice-creates-a-first-partial-of-the-transaction-proposal

            //Send 1 Alice token and receive 10 Bob tokens
            var txProposalStep1Response = await clientAlice.AtomicSwapCreateTxProposal(new AtomicSwapPartialTransactionRequest()
            {
                Send = new Send
                {
                    Tokens = new() { new TokenForPartialSend() { Token = aliceTokenId, Value = 1 } }
                },
                Receive = new Receive
                {
                    Tokens = new() { new TokenForPartialReceive() { Token = bobTokenId, Value = 10 } }
                }
            });


            Assert.IsTrue(txProposalStep1Response.Success);
            Assert.IsNotNull(txProposalStep1Response.Data);
            Assert.IsFalse(txProposalStep1Response.IsComplete);

            var alicePartialTxHex = txProposalStep1Response.Data;

            ///////////////////////////////////////////////////////////////
            //Step 2: Bob reviews Alice's partial transaction

            var step2Response = await clientBob.Decode(new DecodeRequest() {  PartialTx = alicePartialTxHex });

            Assert.IsTrue(step2Response.Success);
            Assert.IsTrue(step2Response.Tx.Outputs.Any());

            ///////////////////////////////////////////////////////////////
            //Step 3: Bob updates Alice's partial transaction

            var txProposalStep3Response = await clientBob.AtomicSwapCreateTxProposal(new AtomicSwapPartialTransactionRequest()
            {
                PartialTx = alicePartialTxHex,
                Send = new Send
                {
                    Tokens = new() { new TokenForPartialSend() { Token = bobTokenId, Value = 10 } }
                },
                Receive = new Receive
                {
                    Tokens = new() { new TokenForPartialReceive() { Token = aliceTokenId, Value = 1 } }
                }
            });

            Assert.IsTrue(txProposalStep3Response.Success);
            Assert.IsNotNull(txProposalStep3Response.Data);
            Assert.IsTrue(txProposalStep3Response.IsComplete);

            var bobPartialTxHex = txProposalStep3Response.Data;

            ///////////////////////////////////////////////////////////////
            //Step 4: Alice reviews the updated partial transaction proposal

            var step4Response = await clientAlice.Decode(new DecodeRequest() {  PartialTx = bobPartialTxHex });

            Assert.IsTrue(step4Response.Success);
            Assert.IsTrue(step4Response.Tx.Outputs.Any());
            Assert.IsTrue(step4Response.Tx.Inputs.Any());


            ///////////////////////////////////////////////////////////////
            //Step 5: Alice generates her signature

            var step5Response = await clientAlice.AtomicSwapGetSignaturesForTxProposal(new AtomicSwapPartialTxRequest() { PartialTx = bobPartialTxHex });

            Assert.IsTrue(step5Response.Success);
            Assert.IsNotNull(step5Response.Signatures);

            var aliceSignature = step5Response.Signatures;

            ///////////////////////////////////////////////////////////////
            //Step 6: Bob generates his signature

            var step6Response = await clientBob.AtomicSwapGetSignaturesForTxProposal(new AtomicSwapPartialTxRequest() { PartialTx = bobPartialTxHex });

            Assert.IsTrue(step6Response.Success);
            Assert.IsNotNull(step6Response.Signatures);

            var bobSignature = step6Response.Signatures;

            ///////////////////////////////////////////////////////////////
            //Step 7: Bob signs and push the transaction

            var step7Response = await clientBob.AtomicSwapSignAndPush(new AtomicSwapSignRequest()
            { 
                PartialTx= bobPartialTxHex,
                Signatures = new List<string>()
                {
                    bobSignature,
                    aliceSignature
                }
            });

            Assert.IsTrue(step7Response.Success);
            Assert.IsTrue(step7Response.Inputs.Any());
            Assert.IsTrue(step7Response.Outputs.Any());


            ///////////////////////////////////////////////////////////////
            //Check if tokens are transferred

            //Alice should have 1 Alice token and 10 BOB tokens
            var aliceAliceTokenFinal = await clientAlice.GetBalance(aliceTokenId);
            var aliceBobTokenFinal = await clientAlice.GetBalance(bobTokenId);

            Assert.AreEqual(1, aliceAliceTokenFinal.Available);
            Assert.AreEqual(10, aliceBobTokenFinal.Available);

            //Bob should have 1 Alice token and 0 Bob tokens
            var bobAliceTokenFinal = await clientBob.GetBalance(aliceTokenId);
            var bobBobTokenFinal = await clientBob.GetBalance(bobTokenId);

            Assert.AreEqual(1, bobAliceTokenFinal.Available);
            Assert.AreEqual(0, bobBobTokenFinal.Available);

        }


    }
}
