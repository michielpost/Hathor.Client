using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Wallet.Tests
{
    [TestClass]
    public class SignTest
    {
        [TestMethod]
        public void CheckValidAddressGeneratorMainnet()
        {
            string address = "HP8wshQbJzeBBb9JWeFTfZavp9XPehxNac";
            string message = "test";
            string signature = "H6y36bSjEbtLFPD4nzAEbb8hmaKb5I9Fe60Rrs0TZEotGt5vBqDNNK8WutqHoNYjbtESSnDURI06jQYHGaXB5eA=";

            var network = HathorAddressHelper.GetNetwork(HathorNetwork.Mainnet);
            
            var bitcoinAddress = new NBitcoin.BitcoinPubKeyAddress(address, network);
            
            bool result = bitcoinAddress.VerifyMessage(message, signature);

            Assert.IsTrue(result);



        }
    }
}
