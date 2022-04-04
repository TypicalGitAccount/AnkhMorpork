using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;
using NUnit.Framework;
using System;

namespace Ankh_Morpork.Tests.States
{
    public class FoolStateTest
    {
        private FoolState state;

        [SetUp]
        public void SetUp()
        {
            state = new FoolState("TestDummy", FoolRewardCents.ArchFool.ToString(), (int)FoolRewardCents.ArchFool);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CharacterName_InvalidStringPassed_ThrowsArgumentOutOfRangeException(string input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => state.PracticeName = input);
        }
    }
}
