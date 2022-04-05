using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;
using Ankh_Morpork.Strategies;
using NUnit.Framework;

namespace Ankh_Morpork.Tests.Strategies
{
    public class AssasinStrategyTest
    {
        private AssasinStrategy strategy;

        [SetUp]
        public void SetUp()
        {
            strategy = new AssasinStrategy();
        }

        [Test]
        public void Interact_ValidInteraction_ChargesMoneyAndReturnsInteractionSuccesfulFlag()
        {
            var user = new Ankh_Morpork.GameTools.User();
            GuildCharacterState state = new AssasinState(100, 1000, "Givi", false);
            int guessedRewardPennies = 120;
            state.InteractionCostPennies = guessedRewardPennies;

            InteractionResult result = strategy.Interact(user, state);

            Assert.AreEqual(InteractionResult.InteractionSuccessful, result);
            Assert.AreEqual((int)PredefinedData.User.StartBalancePennies-guessedRewardPennies, user.BalancePennies);
        }

        [Test]
        public void Interact_CharacterHasNotAssasinState_ReturnsInteractionNonImplementedFlag()
        {
            InteractionResult result = strategy.Interact(new Ankh_Morpork.GameTools.User(), new ThieveState("TestDummy"));

            Assert.AreEqual(result, InteractionResult.InteractionNotImplemented);
        }

        [Test]
        public void Interact_AssasinInteractinoCostWasntChosen_ReturnsInteractionCostNotAssignedFlag()
        {
            InteractionResult result = strategy.Interact(new Ankh_Morpork.GameTools.User(), new AssasinState(200, 1000, "Givi", false));

            Assert.AreEqual(result, InteractionResult.InteractionCostNotAssigned);
        }

        [Test]
        public void Interact_AssasinIsOccupied_ReturnsAssasinIsOccupiedFlag()
        {
            GuildCharacterState state = new AssasinState(10, 1000, "Givi", true);
            state.InteractionCostPennies = 100;
            InteractionResult result = strategy.Interact(new Ankh_Morpork.GameTools.User(), state);

            Assert.AreEqual(InteractionResult.AssasinIsOccupied, result);
        }

        [Test]
        public void Interact_WrongRewardGuessed_ReturnsRewardNotGuessedFlag()
        {
            GuildCharacterState state = new AssasinState(450, 500, "Givi", false);
            state.InteractionCostPennies = 150;
            InteractionResult result = strategy.Interact(new Ankh_Morpork.GameTools.User(), state);

            Assert.AreEqual(InteractionResult.RewardNotGuessed, result);
        }
    }
}
