using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;

namespace Ankh_Morpork.Strategies
{
    public class ThieveStrategy : GuildCharacterStrategy
    {
        public override InteractionResult Interact(GameTools.User user, GuildCharacterState characterState)
        { 
            if (user.BalancePennies < characterState.InteractionCostPennies)
                return InteractionResult.InsufficientBalance;

            if ((int)Thieves.AllowedThefts == ThieveState.TheftsHappened)
                return InteractionResult.TooMuchThefts; 

            ThieveState.TheftsHappened += 1;
            user.BalancePennies -= characterState.InteractionCostPennies;
            return InteractionResult.InteractionSuccessful;
        }
    }
}
