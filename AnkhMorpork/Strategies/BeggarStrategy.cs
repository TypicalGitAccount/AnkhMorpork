using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;

namespace Ankh_Morpork.Strategies
{
    public class BeggarStrategy : GuildCharacterStrategy
    {
        public override InteractionResult Interact(GameTools.User user, GuildCharacterState characterState)
        {
            if (user.BalanceCents < characterState.InteractionCostCents)
                return InteractionResult.InsufficientBalance;

            user.BalanceCents -= characterState.InteractionCostCents;
            return InteractionResult.InteractionSuccessful;
        }
    }
}
