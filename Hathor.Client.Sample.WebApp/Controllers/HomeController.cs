using Hathor.Client.Sample.WebApp.Models;
using Hathor.Extensions;
using Hathor.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Hathor.Client.Sample.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string WALLET_ID = "web-sample-wallet";
        private IHathorWalletApi client = HathorClient.GetWalletClient("http://localhost:8000", WALLET_ID);

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel vm = new IndexViewModel();

            try
            {
                var status = await client.GetStatus();
                vm.IsNodeRunning = status.Success;
            }
            catch { }

            if(vm.IsNodeRunning ?? false)
            {
                vm.Address = await client.GetAddress();
                vm.Balance = await client.GetBalance();
                vm.TxHistory = await client.GetTxHistory();
                vm.Addresses = await client.GetAddresses();
            }
            
            return View(vm);
        }

        [HttpGet]
        [Route("transaction/{id}")]
        public async Task<IActionResult> Transaction([FromRoute] string id)
        {
            var tx = await client.GetTransaction(id);

            if (tx == null)
                return NotFound();

            return View(tx);
        }

        [HttpPost]
        public async Task<IActionResult> StartWallet()
        {
            var req = new StartRequest(WALLET_ID, "default");
            var response = await client.Start(req);

            if (response.Success)
            {
                //Wait 2 seconds until the initialization is finished
                await Task.Delay(TimeSpan.FromSeconds(2));

                return RedirectToAction(nameof(Index));
            }

            return new ContentResult() { Content = $"Could not start wallet. Status message: {response.StatusMessage}" };
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromForm]IndexViewModel model)
        {
            var address = model.TransactionModel.Address;
            var amount = model.TransactionModel.Amount.ToHTRCents();

            if (string.IsNullOrWhiteSpace(address))
                throw new Exception("Please fill in an address.");
            if (amount <= 0)
                throw new Exception("Amount should be > 0");

            var req = new SendTransactionSimpleRequest(address, amount);
            var response = await client.SendTransaction(req);

            if (response.Success)
            {

                return RedirectToAction(nameof(Transaction), new { id = response.TxId });
            }

            return new ContentResult() { Content = $"Transaction failed. Error message: {response.Error}" };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
