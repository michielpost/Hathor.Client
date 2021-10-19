using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Wallet
{
    public class HathorAddressHelper
    {
		public static Network GetNetwork(HathorNetwork hathorNetwork)
        {
			if (hathorNetwork == HathorNetwork.Mainnet)
				return HathorNetworkSet.Instance.Mainnet;
			else
				return HathorNetworkSet.Instance.Testnet;

		}

		public static bool TryParseBitcoinAddress(string text, out BitcoinAddress? address, HathorNetwork hathorNetwork)
		{
			address = null;
			var network = GetNetwork(hathorNetwork);

			if (string.IsNullOrEmpty(text) || text.Length > 100)
			{
				return false;
			}

			text = text.Trim();
			try
			{
				address = BitcoinAddress.Create(text, network);
				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}
	}
}
