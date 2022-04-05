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
        public void MinRewardPennies_InvalidValuePassed_ThrowsArgumentOutOfRangeException(int reward)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => state.MinRewardPennies = reward);
        }

        [Test]
        public void MaxRewardPennies_ValueLessThanMinRewardPassed_ThrowsArgumentOutOfRangeException()
        {
            state.MinRewardPennies = 20;
            Assert.Throws<ArgumentOutOfRangeException>(() => state.MaxRewardPennies = 5);
        }

        [Test]
        public void MaxRewardPennies_MinRewardNotInitialisedBeforeMaxReward_ThrowsArgumentOutOfRangeException()
        { 
            Assert.Throws<ArgumentOutOfRangeException>(() => state.MaxRewardPennies = 5);
        }
    }
}
