using System;

namespace Ankh_Morpork.States
{
    public abstract class GuildCharacterState
    {
        private string characterName;
        public string CharacterName
        {
            get
            {
                return characterName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("CharacterName can\'t be null or empty string!");
                }

                characterName = value;
            }
        }
        private int interactionCostPennies;
        public int InteractionCostPennies
        {
            get
            {
                return interactionCostPennies;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Interaction cost can\'t be < 0!");

                interactionCostPennies = value;
            }
        }
        /// <summary>
        /// Base npc state
        /// </summary>
        public GuildCharacterState(string name, int costPennies=0)
        {
            CharacterName = name;
            InteractionCostPennies = costPennies;
        }
    }
}
