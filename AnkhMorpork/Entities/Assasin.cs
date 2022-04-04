using Ankh_Morpork.States;
using Ankh_Morpork.Strategies;

namespace Ankh_Morpork.Entities
{
    public class Assasin : GuildCharacter
    {
        public Assasin(int rewardMinCents, int rewardMaxCents, string characterName, bool isOccupied, int interactionCost=0)
            : base(new AssasinState(rewardMinCents, rewardMaxCents, characterName, isOccupied, interactionCost), new AssasinStrategy()) { }
    }
}
