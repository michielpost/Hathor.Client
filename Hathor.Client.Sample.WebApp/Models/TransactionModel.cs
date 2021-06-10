using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hathor.Client.Sample.WebApp.Models
{
    public class TransactionModel
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Address { get; set; } = default!;
    }
}
