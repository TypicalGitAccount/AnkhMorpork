using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;
using NUnit.Framework;
using System;

namespace Ankh_Morpork.Tests.States
{
    public class BeggarStateTest
    {
        private BeggarState state;

        [SetUp]
        public void SetUp()
        {
            state = new BeggarState("TestDummy", BeggarRewardPennies.Twitcher.ToString(), (int)BeggarRewardPennies.Twitcher);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CharacterName_InvalidStringPassed_ThrowsArgumentOutOfRangeException(string input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => state.PracticeName = input);
        }
    }
}
