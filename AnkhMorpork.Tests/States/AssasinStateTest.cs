using Ankh_Morpork.States;
using NUnit.Framework;
using System;

namespace Ankh_Morpork.Tests.States
{
    public class AssasinStateTest
    {
        private AssasinState state;

        [SetUp]
        public void SetUp()
        {
            state = new AssasinState(10, 100, "TestDummy", false);
        }

        [TestCase(-2)]
        [TestCase(0)]
        public void MinRewardCents_InvalidValuePassed_ThrowsArgumentOutOfRangeException(int reward)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => state.MinRewardCents = reward);
        }

        [Test]
        public void MaxRewardCents_ValueLessThanMinRewardPassed_ThrowsArgumentOutOfRangeException()
        {
            state.MinRewardCents = 20;
            Assert.Throws<ArgumentOutOfRangeException>(() => state.MaxRewardCents = 5);
        }

        [Test]
        public void MaxRewardCents_MinRewardNotInitialisedBeforeMaxReward_ThrowsArgumentOutOfRangeException()
        { 
            Assert.Throws<ArgumentOutOfRangeException>(() => state.MaxRewardCents = 5);
        }
    }
}
