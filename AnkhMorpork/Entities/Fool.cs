using Ankh_Morpork.States;
using Ankh_Morpork.Strategies;

namespace Ankh_Morpork.Entities
{
    public class Fool : GuildCharacter
    {
        public Fool(string name, string practiceName, int rewardPennies) :
            base(new FoolState(name, practiceName, rewardPennies), new FoolStrategy()) {}
    }
}
