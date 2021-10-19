using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Hathor.Wallet.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        [DataRow("HD6YsWEAMJ65baX693xL1YPg84b5Q8uKQ6")]
        [DataRow("HLP9C4ifh9tivTsJC9WjtMkddgH52DCi6K")]
        [DataRow("HD6YsWEAMJ65baX693xL1YPg84b5Q8uKQ6")]
        public void IsValidMainnetAddress(string input)
        {
            bool result = HathorAddressHelper.TryParseBitcoinAddress(input, out var address, HathorNetwork.Mainnet);
            Assert.IsTrue(result);
        }


        [TestMethod]
        [DataRow("134agLSd3KGB5fDA3WrFnTn5J6xcCHozHp")]
        [DataRow("HD6YsWEAMJ65baX693xL1YPg84b5Q8uKQ1")]
        [DataRow("HLP9C4ifh9tivTsJC9WjtMkddgH52DCi6A")]
        [DataRow("HU6YsWEAMJ65baX693xL1YPg84b5Q8uKQ6")]
        [DataRow("0000000000000000000000000000000000")]
        [DataRow("WUzq6ZR44pT7zZgUsLcfVY6ZAULwhK6kE5")]
        [DataRow("WRRqccAZD4AM3CYqLk4sR9N6hvv255naRn")]
        [DataRow("WkXzuntEx7qNnYezqujS5f4gCmqbfVRxMd")]
        public void IsInValidMainnetAddress(string input)
        {
            bool result = HathorAddressHelper.TryParseBitcoinAddress(input, out var address, HathorNetwork.Mainnet);
            Assert.IsFalse(result);
        }




        [TestMethod]
        [DataRow("WUzq6ZR44pT7zZgUsLcfVY6ZAULwhK6kE5")]
        [DataRow("WRRqccAZD4AM3CYqLk4sR9N6hvv255naRn")]
        [DataRow("WkXzuntEx7qNnYezqujS5f4gCmqbfVRxMd")]
        public void IsValidTestnetAddress(string input)
        {
            bool result = HathorAddressHelper.TryParseBitcoinAddress(input, out var address, HathorNetwork.Testnet);
            Assert.IsTrue(result);
        }



        [TestMethod]
        [DataRow("134agLSd3KGB5fDA3WrFnTn5J6xcCHozHp")]
        [DataRow("HD6YsWEAMJ65baX693xL1YPg84b5Q8uKQ6")]
        [DataRow("HLP9C4ifh9tivTsJC9WjtMkddgH52DCi6K")]
        [DataRow("HD6YsWEAMJ65baX693xL1YPg84b5Q8uKQ6")]
        [DataRow("0000000000000000000000000000000000")]
        public void IsInValidTestnetAddress(string input)
        {
            bool result = HathorAddressHelper.TryParseBitcoinAddress(input, out var address, HathorNetwork.Testnet);
            Assert.IsFalse(result);
        }

    }
}
