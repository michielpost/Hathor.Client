using Hathor.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Tests
{
    [TestClass]
    public class ValueConversionTests
    {
        [DataTestMethod]
        [DataRow(1, "0.01")]
        [DataRow(10, "0.10")]
        [DataRow(100, "1.00")]
        [DataRow(1000, "10.00")]
        [DataRow(1234, "12.34")]
        public void FromCentsToHTR(int cents, string htr)
        {
            decimal htrDecimal = Convert.ToDecimal(htr, CultureInfo.InvariantCulture);
            decimal result = cents.ToHTR();

            Assert.AreEqual(htrDecimal, result);
        }

        [DataTestMethod]
        [DataRow(1, "0.01")]
        [DataRow(10, "0.10")]
        [DataRow(15, "0.15")]
        [DataRow(50, "0.50")]
        [DataRow(100, "1")]
        [DataRow(110, "1.10")]
        [DataRow(115, "1.15")]
        [DataRow(1000, "10")]
        [DataRow(1234, "12.34")]
        public void FromCentsToHTRString(int cents, string htr)
        {
            var result = cents.ToHTRString(CultureInfo.InvariantCulture);

            Assert.AreEqual($"{htr} HTR", result);
        }

        [DataTestMethod]
        [DataRow(1, "0.01")]
        [DataRow(10, "0.10")]
        [DataRow(100, "1.00")]
        [DataRow(1000, "10.00")]
        [DataRow(1234, "12.34")]
        public void FromHTRToCents(int cents, string htr)
        {
            decimal htrDecimal = Convert.ToDecimal(htr, CultureInfo.InvariantCulture);
            decimal result = htrDecimal.ToHTRCents();

            Assert.AreEqual(cents, result);
        }
    }
}
