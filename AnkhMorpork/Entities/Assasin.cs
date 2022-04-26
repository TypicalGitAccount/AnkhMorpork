using Ankh_Morpork.States;
using Ankh_Morpork.Strategies;

namespace Ankh_Morpork.Entities
{
    public class Assasin : GuildCharacter
    {
        public Assasin(int rewardMinPennies, int rewardMaxPennies, string characterName, bool isOccupied, int interactionCostPennies=0)
            : base(new AssasinState(rewardMinPennies, rewardMaxPennies, characterName, isOccupied, interactionCostPennies), new AssasinStrategy()) { }
    }
}
