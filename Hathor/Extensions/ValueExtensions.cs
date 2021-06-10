using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Extensions
{
    public static class ValueExtensions
    {
        public static decimal ToHTR(this int value)
        {
            return Convert.ToDecimal(value) / 100;
        }

        public static int ToHTRCents(this decimal value)
        {
            return Convert.ToInt32(value * 100);
        }
    }
}
