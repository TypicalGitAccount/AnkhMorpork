using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;
using Ankh_Morpork.Strategies;

namespace Ankh_Morpork.Entities
{
   public abstract class GuildCharacter
   {
        public GuildCharacterState State { get; protected set; }
        public GuildCharacterStrategy Behaviour { get; protected set; }

        /// <summary>
        /// Base game npc
        /// </summary>
        public GuildCharacter(GuildCharacterState state, GuildCharacterStrategy behaviour)
        {
            State = state;
            Behaviour = behaviour;
        }

        /// <summary>
        /// To user npc strategy on user
        /// </summary>
        /// <param name="user">global user</param>
        /// <returns></returns>
        public InteractionResult Interact(GameTools.User user)
        {
            return Behaviour.Interact(user, State);
        }
    }
}
