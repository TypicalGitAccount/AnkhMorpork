using NUnit.Framework;
using Ankh_Morpork.Strategies;
using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;

namespace Ankh_Morpork.Tests.Strategies
{
    public class BeggarStrategyTest
    {
        private BeggarStrategy strategy;

        [SetUp]
        public void SetUp()
        {
            strategy = new BeggarStrategy();
        }

        [Test]
        public void Interact_ValidInteraction_ReturnsInteractionSuccessfulFlag()
        {
            var user = new Ankh_Morpork.GameTools.User();
            var result = 
                strategy.Interact(user, new BeggarState("TestDummy", 
                BeggarRewardPennies.Twitcher.ToString(), (int)BeggarRewardPennies.Twitcher));

            Assert.AreEqual(result, InteractionResult.InteractionSuccessful);
            Assert.AreEqual((int)PredefinedData.User.StartBalancePennies - (int)BeggarRewardPennies.Twitcher, user.BalancePennies);
        }

        public void Interact_NotEnoughMoney_ReturnsInsufficientBalanceFlag()
        {
            var result =
                strategy.Interact(new Ankh_Morpork.GameTools.User(startBalancePennies: 0), new BeggarState("TestDummy", 
                BeggarRewardPennies.Twitcher.ToString(), (int)BeggarRewardPennies.Twitcher));

            Assert.AreEqual(result, InteractionResult.InsufficientBalance);
        }
    }
}
