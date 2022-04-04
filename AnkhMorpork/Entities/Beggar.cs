﻿using Ankh_Morpork.States;
using Ankh_Morpork.Strategies;

namespace Ankh_Morpork.Entities
{
    public class Beggar : GuildCharacter
    {
        public Beggar(string name, string practiceName, int rewardCents)
            : base(new BeggarState(name, practiceName, rewardCents), new BeggarStrategy())  { }
    }
}
