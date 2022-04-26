using Ankh_Morpork.Entities;
using Ankh_Morpork.Events;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;
using Moq;
using NUnit.Framework;

namespace Ankh_Morpork.Tests.Events
{
    public class AssasinEventTest
    {
        private Mock<AssasinEvent> mockEvent;
        private TestInputProcessor inputProcessor;

        [SetUp]
        public void SetUp()
        {
            mockEvent = new Mock<AssasinEvent>() { CallBase = true };
            inputProcessor = new TestInputProcessor();
        }

        [Test]
        public void Run_EventAcceptedAndRewardGuessed_ReturnsTrue()
        {
            var testAssasin = new Assasin(rewardMinPennies: 1, rewardMaxPennies: 1000, "testDummy", false);
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testAssasin);
            inputProcessor.AddUserInput(UserOption.Yes.ToString());
            inputProcessor.AddUserInput("5");

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsTrue(result);
        }

        [Test]
        public void Run_EventAcceptedAndRewardGuessedButNotEnoughMoney_ReturnsFalse()
        {
            var testAssasin = new Assasin(rewardMinPennies: 10, rewardMaxPennies: 1000, "testDummy", false);
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testAssasin);
            inputProcessor.AddUserInput(UserOption.Yes.ToString());
            inputProcessor.AddUserInput("5");

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(startBalancePennies:1), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_EventAcceptedButAssasinOccupied_ReturnsFalse()
        {
            var testAssasin = new Assasin(rewardMinPennies: 10, rewardMaxPennies: 1000, "testDummy", isOccupied: true);
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testAssasin);
            inputProcessor.AddUserInput(UserOption.Yes.ToString());
            inputProcessor.AddUserInput("5.02");

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_EventAcceptedButRewardNotGuessed_ReturnsFalse()
        {
            var testAssasin = new Assasin(rewardMinPennies: 1000, rewardMaxPennies: 1000, "testDummy", isOccupied: true);
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testAssasin);
            inputProcessor.AddUserInput(UserOption.Yes.ToString());
            inputProcessor.AddUserInput("5.02");

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsFalse(result);
        }

        [Test]
        public void Run_EventRegected_ReturnsFalse()
        {
            var testAssasin = new Assasin(rewardMinPennies: 10, rewardMaxPennies: 1000, "testDummy", isOccupied: true);
            mockEvent.Setup(x => x.GenerateGuildCharacter()).Returns(testAssasin);
            inputProcessor.AddUserInput(UserOption.No.ToString());

            var result = mockEvent.Object.Run(new Ankh_Morpork.GameTools.User(), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsFalse(result);
        }
    }
}
