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

        /// <summary>
        /// To apply npc strategy to user
        /// </summary>
        /// <param name="characterState">Npc which strategy is used</param>
        /// <returns>InteractionResult</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual InteractionResult Interact(GameTools.User user, GuildCharacterState characterState) 
        { throw new NotImplementedException(); }
    }
}
