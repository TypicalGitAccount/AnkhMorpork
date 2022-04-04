using Ankh_Morpork.Entities;
using Ankh_Morpork.Events;
using Ankh_Morpork.IO;
using Ankh_Morpork.PredefinedData;
using Moq;
using NUnit.Framework;

namespace Ankh_Morpork.Tests.Events
{
    public class FoolEventTest
    {
        private TestInputProcessor inputProcessor;

        [SetUp]
        public void SetUp()
        {
            inputProcessor = new TestInputProcessor();
        }

        [TestCase(UserOption.Yes)]
        [TestCase(UserOption.No)]
        public void Run_UserEntersAnswer_ReturnsTrue(UserOption userInput)
        {
            var testFool = new Fool("TestDummy", FoolRewardCents.ArchFool.ToString(), (int)FoolRewardCents.ArchFool);
            var eventMock = new Mock<FoolEvent>() { CallBase = true };
            eventMock.Setup(x => x.GenerateGuildCharacter()).Returns(testFool);
            inputProcessor.AddUserInput(userInput.ToString());

            var result = eventMock.Object.Run( new Ankh_Morpork.GameTools.User(), inputProcessor, new ConsoleOutputProcessor());

            Assert.IsTrue(result);
        }
    }
}
