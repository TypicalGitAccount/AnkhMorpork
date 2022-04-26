using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;
using System;

namespace Ankh_Morpork.Strategies
{
    public class BeggarStrategy : GuildCharacterStrategy
    {
        public override InteractionResult Interact(GameTools.User user, GuildCharacterState characterState)
        {
            if (AreNull(user, characterState))
                throw new ArgumentException("Arguments can't be null");

            if (user.BalancePennies < characterState.InteractionCostPennies)
                return InteractionResult.InsufficientBalance;

            user.BalancePennies -= characterState.InteractionCostPennies;
            return InteractionResult.InteractionSuccessful;
        }
    }
}
