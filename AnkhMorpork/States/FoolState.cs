using System;

namespace Ankh_Morpork.States
{
    public class FoolState : GuildCharacterState
    {
        protected string practiceName;
        public string PracticeName
        {
            get
            {
                return practiceName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentOutOfRangeException("PracticeName can\'t be null or empty string!");

                practiceName = value;
            }
        }
        public FoolState(string name, string practiceName, int rewardCents) : base(name, rewardCents) 
        {
            PracticeName = practiceName;
        }
    }
}
