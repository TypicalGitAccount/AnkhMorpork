using Ankh_Morpork.GameTools;
using NUnit.Framework;
using System;

namespace Ankh_Morpork.Tests.GameTools
{
    [TestFixture]
    public class CurrencyConverterTest
    {
        [Test]
        public void CentsToDollars_NegativeValuePassed_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CurrencyConverter.CentsToDollars(-2));
        }

        [Test]
        public void CentsToDollars_CorrectValuePassed_ConvertsCorrectly()
        {
            var result = CurrencyConverter.CentsToDollars(5555);

            Assert.AreEqual(result, 55.55d);
        }

        [Test]
        public void DollarsToCents_NegativeValuePassed_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CurrencyConverter.DollarsToCents(-2));
        }

        [Test]
        public void DollarsToCents_CorrectValuePassed_ConvertsCorrectly()
        {
            var result = CurrencyConverter.DollarsToCents(55.55d);

            Assert.AreEqual(result, 5555);
        }
    }
}
