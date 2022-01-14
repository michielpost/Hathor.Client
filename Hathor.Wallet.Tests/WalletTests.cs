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
        private static IHathorNodeApi nodeclient = HathorClient.GetNodeClient("http://localhost:8082");
        private const string WALLET_ID = "wallet1";


        [TestMethod]

        public void CheckValidAddressGeneratorTestnet()
        {
            string seed = "auto rack method remain level craft unable erode sense canal awful pass pause evidence accuse host crew main surprise top debris link muffin safe";

            var wallet = new HathorWallet(nodeclient, HathorNetwork.Testnet, seed);

            Assert.AreEqual("WjMHb1GujSYGsENjoMYWiL5nF77Whh2SAw", wallet.GetAddress(0));
            Assert.AreEqual("WZaj6S7CKFkhzB4ZbwVDurQAVkQP8dfoxD", wallet.GetAddress(1));
            Assert.AreEqual("WQwzKnNEtjjMFyRBDp9TD2CHPXNsY6FKG7", wallet.GetAddress(2));
            Assert.AreEqual("WZW3GKT3S7gGgDAXoyeVj5gwW21AVGhjbu", wallet.GetAddress(3));
            Assert.AreEqual("WjwbmVKTUXc3yZHv2toPqzBSFRtjZ8CpnF", wallet.GetAddress(4));
            Assert.AreEqual("WY2Gm1QxALQrDJqkenu1yEY4CAf6qKEeGJ", wallet.GetAddress(5));
            Assert.AreEqual("WZp2UcR5Q9e5f6WHWpymK4Lj1ga9NAhVr9", wallet.GetAddress(6));
            Assert.AreEqual("WXFQVBChVzU5d4qoymdKfbQpkqVR81sNtz", wallet.GetAddress(7));
            Assert.AreEqual("WZoakcYkmRkAvwCXufxxhcFTz6g4cfaA5b", wallet.GetAddress(8));
            Assert.AreEqual("WeC6nReEfoUrMmdXaMj5b1Y7YTEh3GPZCf", wallet.GetAddress(9));
            Assert.AreEqual("WPpEq4tQqg3ynr8d9EKNA6pwPrrQXE9aQL", wallet.GetAddress(10));
            Assert.AreEqual("WWRMdBbDVzXjyd1CLBgJmj78W8VMB9FXKE", wallet.GetAddress(11));
            Assert.AreEqual("WNgT4JCLdiW3SFPbkjuJtrQ2eUUibBRuHw", wallet.GetAddress(12));
            Assert.AreEqual("WYYg8frjj1fhc9W1JH2cXqDYWwRhvrpzVu", wallet.GetAddress(13));
            Assert.AreEqual("WgoXSweT8dZ3asi3Nda7TDCs8gTScKTpa4", wallet.GetAddress(14));
            Assert.AreEqual("WQP66WWcnvWAZwadnwbChNrpjiG2o4enDK", wallet.GetAddress(15));
            Assert.AreEqual("WSAECZJxCWR74eoYmVEeW8JLZb722EFtiK", wallet.GetAddress(16));
            Assert.AreEqual("WWKm12Psa5Ha6sFx6Bbqs3K2VRdV4mPmNT", wallet.GetAddress(17));
            Assert.AreEqual("WjR96sAm1uiCPTLmmQoZG2BdnVHRxMZoYv", wallet.GetAddress(18));
            Assert.AreEqual("WTCC4oRwNDcSxumyb55y6NLkc8BcQJosQU", wallet.GetAddress(19));
            Assert.AreEqual("WciUW4QBwDvJ1C7GVarJtDipZB3Cu1CLnX", wallet.GetAddress(20));
            Assert.AreEqual("Wj9SqzcT4FbCFJmvXnKJN4QbdbBfPSTrJn", wallet.GetAddress(100));
            Assert.AreEqual("WVsxVxqQ9Fr6oyJ6fsH1PwNJtm2WJh1pto", wallet.GetAddress(500));
            Assert.AreEqual("WmSmppsUY2MMop6B6trnYzzoyZrXiQztJh", wallet.GetAddress(4242));
        }

        [TestMethod]
        public void CheckValidAddressGeneratorMainnet()
        {
            string seed = "auto rack method remain level craft unable erode sense canal awful pass pause evidence accuse host crew main surprise top debris link muffin safe";

            var wallet = new HathorWallet(nodeclient, HathorNetwork.Mainnet, seed);

            Assert.AreEqual("HTCP6RSQJVFMsvmszWYziC6pUTcPDqU8cr", wallet.GetAddress(0));
            Assert.AreEqual("HHRpbrGgtJTnzsTho6VhuiRCj6uFem3jDr", wallet.GetAddress(1));
            Assert.AreEqual("H8o5qCXjTnSSGfpKQy9wCtDKcssk4Zmb3n", wallet.GetAddress(2));
            Assert.AreEqual("HHM8mjcY1APMguZg18eyiwhyjNW2zYjVBL", wallet.GetAddress(3));
            Assert.AreEqual("HTnhGuUx3aK8zFh4E3osqrCUUnPc72F74K", wallet.GetAddress(4));
            Assert.AreEqual("HFsNGRaSjP7wE1EtqwuVy6Z6RX9yMccGMz", wallet.GetAddress(5));
            Assert.AreEqual("HHf7z2aZyCMAfnuRhyzFJvMmF351tBHNX2", wallet.GetAddress(6));
            Assert.AreEqual("HF6VzbNC53BAdmExAvdofTRrzBzHgncRAZ", wallet.GetAddress(7));
            Assert.AreEqual("HHegG2iFLUTFwdbg6pyShUGWDTAw83wVWM", wallet.GetAddress(8));
            Assert.AreEqual("HN3CHqojErBwNU2fmWjZasZ9mojZWYgcBK", wallet.GetAddress(9));
            Assert.AreEqual("H7fLLV3uQim4oYXmLPKr9xqydDMGzf4vtp", wallet.GetAddress(10));
            Assert.AreEqual("HEGT8bki53EpzKQLXLgnmb8AjUzDixRHfZ", wallet.GetAddress(11));
            Assert.AreEqual("H6XYZiMqCmD8SwnjwtuntiR4spybBT6new", wallet.GetAddress(12));
            Assert.AreEqual("HGPme62EJ4Nncqu9VS36XhEakHvaUp8mzj", wallet.GetAddress(13));
            Assert.AreEqual("HQecxMowhgG8ba7BZnabT5DuN2xKDeqUgZ", wallet.GetAddress(14));
            Assert.AreEqual("H8EBbvg7MyDFadymz6bghEsry4kuGcNwGK", wallet.GetAddress(15));
            Assert.AreEqual("HA1KhyUSmZ8C5MCgxeF8VzKNnwbtXsNh1o", wallet.GetAddress(16));
            Assert.AreEqual("HEArWSZN97zf7Zf6HLcKruL4in8MbRQgRW", wallet.GetAddress(17));
            Assert.AreEqual("HTGEcHLFaxRHQ9juxZp3FtCg1qnJVqr3wf", wallet.GetAddress(18));
            Assert.AreEqual("HB3HaDbRwGKXycB7nE6T6EMnqUgV2EhrcV", wallet.GetAddress(19));
            Assert.AreEqual("HLZa1UZgWGdP1tWQgjrnt5jrnXY5UHGKc4", wallet.GetAddress(20));
            Assert.AreEqual("HSzYMQmwdJJHG1B4iwKnMvRdrwgXyEjL3Q", wallet.GetAddress(100));
            Assert.AreEqual("HDj41NztiJZBpfhEs2HVPoPM87XNsHynGY", wallet.GetAddress(500));
            Assert.AreEqual("HVHsLF2y754SpWVKJ3sGYs1rCvMQGaGcUU", wallet.GetAddress(4242));
        }


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

            var wallet = new HathorWallet(nodeclient, HathorNetwork.Mainnet, seed);


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
