using System;
using Ankh_Morpork.States;
using NUnit.Framework;
using Moq;

namespace Ankh_Morpork.Tests.States
{
    public class GuildCharacterStateTest
    {
        private Mock<GuildCharacterState> state;

        [SetUp]
        public void SetUp()
        {
            state = new Mock<GuildCharacterState>("name", 10) { 
                CallBase = true
            };
        }

        [TestCase("")]
        [TestCase(null)]
        public void CharacterName_NullOrEmptyStringPassed_ThrowsArgumentOutOfRangeException(string input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => state.Object.CharacterName = input);
        }

        [Test]
        public void InteractionCost_NegativeValuePassed_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => state.Object.InteractionCostCents = -2);
        }
    }
}
