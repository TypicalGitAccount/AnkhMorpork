using Ankh_Morpork.Entities;
using Ankh_Morpork.Events;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;
using Moq;
using NUnit.Framework;

namespace Ankh_Morpork.Tests.Events
{
    public class ThieveEventTest
    {
        private TestInputProcessor inputProcessor;
        private Mock<ThieveEvent> mockEvent;

        [SetUp]
        public void SetUp()
        {
            inputProcessor = new TestInputProcessor();
            mockEvent = new Mock<ThieveEvent>() { CallBase = true };
        }

        [Test]
        public void Run_UserAcceptedScenario_ReturnsTrue()
        {
            inputProcessor.AddUserInput(UserOption.Yes.ToString());
            var testThieve = new Thieve("TestDummy");
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testThieve);

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsTrue(result);
        }

        [Test]
        public void Run_UserAcceptedScenarioDutNotEnoughMoney_ReturnsFalse()
        {
            inputProcessor.AddUserInput(UserOption.Yes.ToString());
            var testThieve = new Thieve("TestDummy");
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testThieve);

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(startBalanceCents: 1), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_UserRejectedScenario_ReturnsFalse()
        {
            inputProcessor.AddUserInput(UserOption.No.ToString());
            var testThieve = new Thieve("TestDummy");
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testThieve);

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsFalse(result);
        }
    }
}
