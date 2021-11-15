using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Extensions
{
    public static class ScriptDataHelper
    {
        public static string? GetDataUrl(string data)
        {
            data = data.Trim();

            if (data.StartsWith("L"))
                data = data.Substring(1);

            if (data.Length < 1)
                return null;

            var firstChar = data[0];
            byte[] asciiBytes = Encoding.ASCII.GetBytes(firstChar.ToString());
            int length = asciiBytes.FirstOrDefault();

            if (data.Length < length + 1)
                return null;

            return data.Substring(1, length);

        }
    }
}
