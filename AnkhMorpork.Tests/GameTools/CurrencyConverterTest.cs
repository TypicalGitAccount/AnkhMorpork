using Ankh_Morpork.GameTools;
using NUnit.Framework;
using System;

namespace Ankh_Morpork.Tests.GameTools
{
    [TestFixture]
    public class CurrencyConverterTest
    {
        [Test]
        public void PenniesToDollars_NegativeValuePassed_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CurrencyConverter.PenniesToDollars(-2));
        }

        [Test]
        public void PenniesToDollars_CorrectValuePassed_ConvertsCorrectly()
        {
            var result = CurrencyConverter.PenniesToDollars(5555);

            Assert.AreEqual(result, 55.55m);
        }

        [Test]
        public void DollarsToPennies_NegativeValuePassed_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CurrencyConverter.DollarsToPennies(-2));
        }

        [Test]
        public void DollarsToPennies_CorrectValuePassed_ConvertsCorrectly()
        {
            var result = CurrencyConverter.DollarsToPennies(55.55m);

            Assert.AreEqual(result, 5555);
        }
    }
}
