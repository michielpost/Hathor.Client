using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Models.Responses
{
    public class TxConfirmationBlocksResponse : DefaultResponse
    {
        public long ConfirmationNumber { get; set; }
    }
}
