using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;
using System;

namespace Ankh_Morpork.Strategies
{
    public abstract class GuildCharacterStrategy
    {
        protected bool AreNull(GameTools.User user, GuildCharacterState characterState)
        {
            return user == null || characterState == null;
        }

        public virtual InteractionResult Interact(GameTools.User user, GuildCharacterState characterState) 
        { throw new NotImplementedException(); }
    }
}
