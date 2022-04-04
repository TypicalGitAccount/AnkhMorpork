using Ankh_Morpork.States;
using NUnit.Framework;
using System;

namespace Ankh_Morpork.Tests.States
{
    public class ThieveStateTest
    {
        private ThieveState state;

        [SetUp]
        public void SetUp()
        {
            state = new ThieveState("TestDummy");
        }

        [Test]
        public void TheftsHappened_NegativeValuePassed_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ThieveState.TheftsHappened = -2);
        }
    }
}
