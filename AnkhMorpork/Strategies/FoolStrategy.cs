using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;

namespace Ankh_Morpork.Strategies
{
    public class FoolStrategy : GuildCharacterStrategy
    {
        public override InteractionResult Interact(GameTools.User user, GuildCharacterState characterState)
        {
            user.BalancePennies += characterState.InteractionCostPennies;
            return InteractionResult.InteractionSuccessful;
        }
    }
}
