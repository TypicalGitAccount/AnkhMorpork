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
        private int interactionCostCents;
        public int InteractionCostCents
        {
            get
            {
                return interactionCostCents;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Interaction cost can\'t be < 0!");

                interactionCostCents = value;
            }
        }

        public GuildCharacterState(string name, int costCents=0)
        {
            CharacterName = name;
            InteractionCostCents = costCents;
        }
    }
}
