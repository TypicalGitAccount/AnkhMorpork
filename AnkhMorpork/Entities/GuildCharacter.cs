using Ankh_Morpork.PredefinedData;
using Ankh_Morpork.States;
using Ankh_Morpork.Strategies;

namespace Ankh_Morpork.Entities
{
   public abstract class GuildCharacter
   {
        public GuildCharacterState State { get; protected set; }
        public GuildCharacterStrategy Behaviour { get; protected set; }

        public GuildCharacter(GuildCharacterState state, GuildCharacterStrategy behaviour)
        {
            State = state;
            Behaviour = behaviour;
        }

        public InteractionResult Interact(GameTools.User user)
        {
            return Behaviour.Interact(user, State);
        }

        public override string ToString()
        {
            return $"{State}";
        }
    }
}
