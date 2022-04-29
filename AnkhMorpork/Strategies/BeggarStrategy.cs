using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;

namespace Ankh_Morpork.Strategies
{
    public class BeggarStrategy : GuildCharacterStrategy
    {
        public override InteractionResult Interact(GameTools.User user, GuildCharacterState characterState)
        {
            if (user.BalancePennies < characterState.InteractionCostPennies)
                return InteractionResult.InsufficientBalance;

            user.BalancePennies -= characterState.InteractionCostPennies;
            return InteractionResult.InteractionSuccessful;
        }
    }
}
