using Hathor.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hathor.Client.Sample.WebApp.Models
{
    public class IndexViewModel
    {
        public bool? IsNodeRunning { get; set; }
        public AddressResponse? Address { get; set; }
        public BalanceResponse? Balance { get; set; }
        public TxHistoryResponse? TxHistory { get; set; }
        public AddressesResponse Addresses { get; set; } = default!;

        public TransactionModel TransactionModel { get; set; } = new TransactionModel();
    }
}
