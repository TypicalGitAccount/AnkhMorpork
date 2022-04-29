using NUnit.Framework;
using Ankh_Morpork.Strategies;
using Ankh_Morpork.States;
using Ankh_Morpork.PredefinedData;

namespace Ankh_Morpork.Tests.Strategies
{
    public class FoolStrategyTest
    {
        private GuildCharacterStrategy strategy;

        [SetUp]
        public void SetUp()
        {
            strategy = new FoolStrategy();
        }

        [Test]
        public void Interact_ValidInteraction_ReturnsInteractionSuccessfulFlag()
        {
            var user = new Ankh_Morpork.GameTools.User();

            var result = 
                strategy.Interact(user, new FoolState("TestDummy", FoolRewardPennies.ArchFool.ToString(), (int)FoolRewardPennies.ArchFool));

            Assert.AreEqual(InteractionResult.InteractionSuccessful, result);
            Assert.AreEqual((int)PredefinedData.User.StartBalancePennies + (int)FoolRewardPennies.ArchFool, user.BalancePennies);
        }
    }
}
