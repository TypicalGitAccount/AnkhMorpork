using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;

namespace Ankh_Morpork.Strategies
{
    public class ThieveStrategy : GuildCharacterStrategy
    {
        public override InteractionResult Interact(GameTools.User user, GuildCharacterState characterState)
        { 
            if (user.BalanceCents < characterState.InteractionCostCents)
                return InteractionResult.InsufficientBalance;

            if ((int)Thieves.AllowedThefts == ThieveState.TheftsHappened)
                return InteractionResult.TooMuchThefts; 

            ThieveState.TheftsHappened += 1;
            user.BalanceCents -= characterState.InteractionCostCents;
            return InteractionResult.InteractionSuccessful;
        }
    }
}
