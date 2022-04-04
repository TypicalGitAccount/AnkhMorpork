using Ankh_Morpork.GameTools;
using NUnit.Framework;
using System;

namespace Ankh_Morpork.Tests.GameTools
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void Moves_NegativeValuePassed_ThrowsArgumentOutOfRangeException() 
        {
            var user = new User();

            Assert.Throws<ArgumentOutOfRangeException>(() => user.Moves = -2);
        }

        [Test]
        public void BalanceCents_NegativeValuePassed_ThrowsArgumentOutOfRangeException()
        {
            var user = new User();

            Assert.Throws<ArgumentOutOfRangeException>(() => user.BalanceCents = -1);
        }
    }
}
