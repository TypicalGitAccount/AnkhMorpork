using System;

namespace Ankh_Morpork.States
{
    public class AssasinState : GuildCharacterState
    {
        private int minRewardPennies;
        private int maxRewardPennies;
        public int MinRewardPennies {
            get 
            {
                return minRewardPennies;
            }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Interaction cost minimum can\'t be <= 0!");
                }

                minRewardPennies = value;
            } 
        }

        public int MaxRewardPennies
        {
            get
            {
                return maxRewardPennies;
            }
            set
            {
                if (minRewardPennies == default(int))
                {
                    throw new ArgumentOutOfRangeException("interactionCostMin must be initialised before interactionCostMax!");
                }
                if (minRewardPennies > value)
                {
                    throw new ArgumentOutOfRangeException("Max interaction cost can\'t be < minimum");
                }
                maxRewardPennies = value;
            }
        }

        public bool IsOccupied { get; protected set; }
        public AssasinState(int costMinPennies, int costMaxPennies, string characterName, bool isOccupied, int interactionCost=0) : base(characterName, interactionCost)
        {
            MinRewardPennies = costMinPennies;
            MaxRewardPennies = costMaxPennies;
            IsOccupied = isOccupied;
        }
    }
}
