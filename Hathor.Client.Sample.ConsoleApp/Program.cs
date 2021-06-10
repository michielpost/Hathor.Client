using Hathor.Models.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hathor.Client.Sample.ConsoleApp
{
    class Program
    {
        private const string WALLET_ID = "sample-wallet";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hathor Client Sample App!");
            Console.WriteLine("This app will show you the basic usage of the Hathor.Client package.");

            var url = Prompt("Enter the URL to the Hathor Wallet API (e.g. http://localhost:8000):");
            if(url == null)
            {
                Console.WriteLine("Enter a valid url like http://localhost:8000");
                return;
            }
            IHathorApi client = HathorClient.GetClient(url, WALLET_ID);

            Console.WriteLine("Starting Hathor Wallet...");
            var req = new StartRequest(WALLET_ID, "default");
            var response = await client.Start(req);

            if (response.Success)
                Console.WriteLine("Started succesfully.");
            else
            {
                Console.WriteLine($"Success: false, {response.StatusMessage}");

                var status = await client.GetStatus();
                if (status.Success)
                    Console.WriteLine("Wallet was already running");
                else
                {
                    Console.WriteLine($"Success: false, {response.StatusMessage}");
                    return;
                }

            }

            var address = await client.GetAddress();
            var balance = await client.GetBalance();
            var txHistory = await client.GetTxHistory();

            Console.WriteLine();
            Console.WriteLine("-------------------");
            Console.WriteLine($"Address: {address.Address}");
            Console.WriteLine($"Balance: available: {balance.Available} | locked: {balance.Locked}");

            Console.WriteLine($"Number of transactions: {txHistory.Count}");
            Console.WriteLine("-------------------");
            Console.WriteLine();

            if (balance.Available > 0)
            {
                var sendAddress = Prompt("Enter address to send HTR to:");
                var amount = Prompt("Enter amount (in cents, so enter 1 for 0.01 HTR) to send:");
                if (amount != null)
                {
                    int centAmount = int.Parse(amount);
                    if (centAmount > 0 && sendAddress != null)
                    {
                        Console.WriteLine("Sending transaction...");
                        SendTransactionSimpleRequest sendReq = new SendTransactionSimpleRequest(sendAddress, centAmount);
                        var txResult = await client.SendTransaction(sendReq);

                        Console.WriteLine($"Success: {txResult.Success}");
                        if (txResult.Success)
                            Console.WriteLine($"TxId: {txResult.TxId}");
                        else
                            Console.WriteLine($"Error: {txResult.Error}");
                    }
                    else
                        Console.WriteLine("Could not parse address or amount.");
                }

            }
            else
            {
                Console.WriteLine($"Send some HTR to {address.Address} to test creating a new transaction.");
            }


            Prompt("Press enter to quit.");


        }

        private static string? Prompt(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
    }
}
