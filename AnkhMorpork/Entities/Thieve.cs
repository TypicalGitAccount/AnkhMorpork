using Ankh_Morpork.States;
using Ankh_Morpork.Strategies;

namespace Ankh_Morpork.Entities
{
    public class Thieve : GuildCharacter
    {
        public Thieve(string name) : base(new ThieveState(name), new ThieveStrategy()) { }
    }
}
