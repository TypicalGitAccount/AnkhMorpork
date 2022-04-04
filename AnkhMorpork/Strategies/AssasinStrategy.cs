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

            if (characterState.InteractionCostCents > user.BalanceCents)
                return InteractionResult.InsufficientBalance;

            var state = (AssasinState)characterState;
            if (state.InteractionCostCents == 0)
                return InteractionResult.InteractionCostNotAssigned;

            if (state.IsOccupied)
                return InteractionResult.AssasinIsOccupied;

            if (state.MinRewardCents > state.InteractionCostCents || state.MaxRewardCents < state.InteractionCostCents)
                return InteractionResult.RewardNotGuessed;

            user.BalanceCents -= state.InteractionCostCents;
            return InteractionResult.InteractionSuccessful;
        }

        public InteractionResult Interact(User user, GuildCharacterState state)
        {
            throw new NotImplementedException();
        }
    }
}
