using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;
using System;

namespace Ankh_Morpork.Strategies
{
    public class AssasinStrategy : GuildCharacterStrategy
    { 
        public override InteractionResult Interact(GameTools.User user, GuildCharacterState characterState) 
        {
            if (characterState is not AssasinState)
                return InteractionResult.InteractionNotImplemented;

            if (characterState.InteractionCostPennies > user.BalancePennies)
                return InteractionResult.InsufficientBalance;

            var state = (AssasinState)characterState;
            if (state.InteractionCostPennies == 0)
                return InteractionResult.InteractionCostNotAssigned;

            if (state.IsOccupied)
                return InteractionResult.AssasinIsOccupied;

            if (state.MinRewardPennies > state.InteractionCostPennies || state.MaxRewardPennies < state.InteractionCostPennies)
                return InteractionResult.RewardNotGuessed;

            user.BalancePennies -= state.InteractionCostPennies;
            return InteractionResult.InteractionSuccessful;
        }

        public InteractionResult Interact(User user, GuildCharacterState state)
        {
            throw new NotImplementedException();
        }
    }
}
