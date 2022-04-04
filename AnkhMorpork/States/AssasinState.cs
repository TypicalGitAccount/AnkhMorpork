using System;

namespace Ankh_Morpork.States
{
    public class AssasinState : GuildCharacterState
    {
        private int minRewardCents;
        private int maxRewardCents;
        public int MinRewardCents {
            get 
            {
                return minRewardCents;
            }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Interaction cost minimum can\'t be <= 0!");
                }

                minRewardCents = value;
            } 
        }

        public int MaxRewardCents
        {
            get
            {
                return maxRewardCents;
            }
            set
            {
                if (minRewardCents == default(int))
                {
                    throw new ArgumentOutOfRangeException("interactionCostMin must be initialised before interactionCostMax!");
                }
                if (minRewardCents > value)
                {
                    throw new ArgumentOutOfRangeException("Max interaction cost can\'t be < minimum");
                }
                maxRewardCents = value;
            }
        }

        public bool IsOccupied { get; protected set; }
        public AssasinState(int costMinCents, int costMaxCents, string characterName, bool isOccupied, int interactionCost=0) : base(characterName, interactionCost)
        {
            MinRewardCents = costMinCents;
            MaxRewardCents = costMaxCents;
            IsOccupied = isOccupied;
        }
    }
}
