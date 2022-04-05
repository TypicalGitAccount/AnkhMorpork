using Ankh_Morpork.Entities;
using Ankh_Morpork.Events;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;
using Moq;
using NUnit.Framework;

namespace Ankh_Morpork.Tests.Events
{
    public class BeggarEventTest 
    {
        private TestInputProcessor inputProcessor;
        private Mock<BeggarEvent> mockEvent;

        [SetUp]
        public void SetUp()
        {
            inputProcessor = new TestInputProcessor();
            mockEvent = new Mock<BeggarEvent>() { CallBase = true };
        }

        [Test]
        public void Run_UserAcceptedScenario_ReturnsTrue()
        {
            inputProcessor.AddUserInput(UserOption.Yes.ToString()); 
            var testBeggar = new Beggar("TestDummy", BeggarRewardPennies.Dribbler.ToString(), (int)BeggarRewardPennies.Dribbler);
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testBeggar);

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsTrue(result);
        }

        [Test]
        public void Run_UserAcceptedScenarioDutNotEnoughMoney_ReturnsFalse()
        {
            inputProcessor.AddUserInput(UserOption.Yes.ToString());
            var testBeggar = new Beggar("TestDummy", BeggarRewardPennies.Dribbler.ToString(), (int)BeggarRewardPennies.Dribbler);
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testBeggar);

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(startBalancePennies:10), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_UserRejectedScenario_ReturnsFalse()
        {
            inputProcessor.AddUserInput(UserOption.No.ToString());
            var testBeggar = new Beggar("TestDummy", BeggarRewardPennies.Dribbler.ToString(), (int)BeggarRewardPennies.Dribbler);
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testBeggar);

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsFalse(result);
        }
    }
}
