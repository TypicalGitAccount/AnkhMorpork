using Ankh_Morpork.Events;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ankh_Morpork.Tests.Events
{
    [TestFixture]
    public class GuildCharacterEventTest
    {
        private Mock<GuildCharacterEvent> mockEvent;

        [SetUp]
        public void SetUp()
        {
            mockEvent = new Mock<GuildCharacterEvent>() { CallBase = true };
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("rfs dfdgargth")]
        public void ValiduserAnswer_IncorrectInput_ReturnsFalse(string input)
        {
            Assert.IsFalse(mockEvent.Object.ValidUserAnswer(new ConsoleInputProcessor(), input));
        }

        [TestCase(UserOption.Yes)]
        [TestCase(UserOption.No)]
        public void ValiduserAnswer_CorrectInput_ReturnsTrue(UserOption input)
        {
            Assert.IsTrue(mockEvent.Object.ValidUserAnswer(new ConsoleInputProcessor(), input.ToString()));
        }
    }
}
